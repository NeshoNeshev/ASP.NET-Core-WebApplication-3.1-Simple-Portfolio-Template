namespace MyDigitalCV.Pages
{
    using Models.Web.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;


    public class Education : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        private readonly Factories.IFactory<IEnumerable<EducationViewModel>> educationFactory;
        public IEnumerable<EducationViewModel> EducationModel { get; private set; }

        public Education(ILogger<IndexModel> logger, Factories.IFactory<IEnumerable<EducationViewModel>> educationFactory)
        {
            this.logger = logger;
            this.educationFactory = educationFactory;
        }

        public void OnGet()
        {
            this.EducationModel = this.educationFactory.Create().ToList();
        }
    }
}
