using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Models.Web.ViewModels;

namespace MyDigitalCV.Factories
{
    public class PrivacyInformationFactory : IFactory<PrivacyInformationViewModel>
    {
        private readonly string inputJson = File.ReadAllText("ViewInformation/PrivacyInformation.json");
        public PrivacyInformationViewModel Create()
        {
            var model = JsonSerializer.Deserialize<PrivacyInformationViewModel>(inputJson);
            model.Age = GetAge(model.Birthday);
            return (model);
        }
        private string GetAge(string date)
        {
            var birthday = DateTime.Parse(date);
            var result = (DateTime.UtcNow.Date.Year - DateTime.Parse(date).Year);

            if (birthday.Date.Month > DateTime.UtcNow.Month)
            {
                result -= 1;
            }
            else if (birthday.Date.Month == DateTime.UtcNow.Month)
            {
                if (birthday.Day >= DateTime.UtcNow.Day)
                {
                    result -= 1;
                }
            }
            return result.ToString();
        }
       
    }
}
