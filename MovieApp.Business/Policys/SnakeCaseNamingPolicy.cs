using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApp.Business.Policys
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            // Uppdar case leri 
            // userPhotoUrl = user_photo_url
            return string.Concat(name.Select((character, index) =>
                index > 0 && char.IsUpper(character)
                ? "_" + character.ToString()
                : character.ToString()
                )).ToLower();
        }
    }
}
