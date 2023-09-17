using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Business.AutoMapper;
using MovieApp.Business.DependencyResolvers.Autofac;
using MovieApp.Business.DependencyResolvers.OwnDependency;
using MovieApp.Business.Policys;
using MovieApp.DataAccess.DataSeeding.Abstract;
using MovieApp.WebApi.EventBus;
using static MovieApp.WebApi.Commands.CommandsMessages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ! dependecyInjection
//builder.Services.CreateScoped();


// todo   Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));



// *  token  
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    var key = Encoding.ASCII.GetBytes("nmDLKAna9f9WEKPPH7z3tgwnQ433FAtrdP5c9AmDnmuJp9rzwTPwJ9yUu");
    var issuer = "ComparAcademy";
    var audience = "ComparAcademy";

    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        RequireExpirationTime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = audience,
        ValidIssuer = issuer,
    };
});

var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get < RabbitMqSettings > ();
builder.Services.AddMassTransit(mt => mt.UsingRabbitMq((cntxt, cfg) => {
    cfg.Host(rabbitMqSettings.Uri, "/", c => {
        c.Username(rabbitMqSettings.UserName);
        c.Password(rabbitMqSettings.Password);
    });
    cfg.ReceiveEndpoint("samplequeue", (c) => {
        c.Consumer < CommandMessageConsumer > ();
    });
}));
//auto map 
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


// Property 
builder.Services.AddControllers()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
        option.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

    });



var app = builder.Build();

app.MapPost("/sendmessage", (long id, string message, IPublishEndpoint publishEndPoint) =>
{
    publishEndPoint.Publish(new CommandMessage(id, message)); ;
});




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // acilan zaman  db elave etsin 
    var dataSeeder = app.Services.GetRequiredService<IDataSeeder>();
    dataSeeder.AddData();

}



app.UseHttpsRedirection();

// bura olmalidir 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
