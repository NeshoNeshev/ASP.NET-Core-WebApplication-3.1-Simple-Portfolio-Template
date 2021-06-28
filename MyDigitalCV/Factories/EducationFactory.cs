namespace MyDigitalCV.Factories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using Models.Web.ViewModels;

    public class EducationFactory : IFactory<IEnumerable<EducationViewModel>>
    {
         
        private readonly string subjectAndCertificate = File.ReadAllText("ViewInformation/EducationAndCertificates.json");
       
        public IEnumerable<EducationViewModel> Create()
        {
            var model = JsonSerializer.Deserialize<IEnumerable<EducationViewModel>>(subjectAndCertificate);
            return model;
        }
        
    }
}
