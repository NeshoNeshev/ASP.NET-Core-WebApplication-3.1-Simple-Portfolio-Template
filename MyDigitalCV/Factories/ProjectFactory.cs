namespace MyDigitalCV.Factories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using Models.Web.ViewModels;
    public class ProjectFactory : IFactory<IEnumerable<ProjectViewModel>>
    { 
        private readonly string inputJson = File.ReadAllText("ViewInformation/Projects.json");

        public IEnumerable<ProjectViewModel> Create()
        {
            var model = JsonSerializer.Deserialize<List<ProjectViewModel>>(inputJson);
            return model;
        }
        
    }
}
