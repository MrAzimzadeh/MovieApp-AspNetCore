using MovieApp.Business.DependencyResolvers.OwnDependency;
using MovieApp.Business.Policys;
using MovieApp.DataAccess.DataSeeding.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ! dependecyInjection
builder.Services.CreateScoped();
// Property 
builder.Services.AddControllers()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
        option.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

    });



var app = builder.Build();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
