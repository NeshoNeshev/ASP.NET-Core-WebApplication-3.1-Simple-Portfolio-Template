namespace MyDigitalCV.Factories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using Models.Web.ViewModels;
    public class ProfessionalExperienceFactory : IFactory<IEnumerable<ProfessionalExperienceViewModel>>
    {
        private readonly string inputJson = File.ReadAllText("ViewInformation/ProfessionalExperience.json");

        public IEnumerable<ProfessionalExperienceViewModel> Create()
        {
            var model = JsonSerializer.Deserialize<IEnumerable<ProfessionalExperienceViewModel>>(inputJson);

            return (model ?? throw new InvalidOperationException()).ToList();
        }
       
    }
}
