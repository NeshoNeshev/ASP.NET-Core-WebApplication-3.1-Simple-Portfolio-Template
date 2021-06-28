namespace MyDigitalCV.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using Models.Web.ViewModels;
    public class ProfessionalExperience : PageModel
    {
        private readonly ILogger<ProfessionalExperienceViewModel> logger;
        
        private readonly Factories.IFactory<IEnumerable<ProfessionalExperienceViewModel>> professionalFactory;
        public List<ProfessionalExperienceViewModel> ProfessionalExperienceModels { get; private set; }
        public ProfessionalExperience(ILogger<ProfessionalExperienceViewModel> logger, Factories.IFactory<IEnumerable<ProfessionalExperienceViewModel>> professionalFactory)
        {
            this.logger = logger;
            this.professionalFactory = professionalFactory;
        }

        public void OnGet()
        {

            this.ProfessionalExperienceModels = this.professionalFactory.Create().ToList();

        }

    }
}
