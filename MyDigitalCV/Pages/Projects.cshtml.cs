namespace MyDigitalCV.Pages
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using Models.Web.ViewModels;
    public class ProjectsModel : PageModel
    {
        private readonly ILogger<ProjectViewModel> logger;
        private readonly Factories.IFactory<IEnumerable<ProjectViewModel>> projectFactory;
        public IEnumerable<ProjectViewModel> ProjectViewModels { get;private set; }

        public ProjectsModel(ILogger<ProjectViewModel> logger, Factories.IFactory<IEnumerable<ProjectViewModel>>projectFactory)
        {
            this.logger = logger;
            this.projectFactory = projectFactory;
        }
        public void OnGet()
        {
            this.ProjectViewModels = projectFactory.Create();
        }
    }
}
