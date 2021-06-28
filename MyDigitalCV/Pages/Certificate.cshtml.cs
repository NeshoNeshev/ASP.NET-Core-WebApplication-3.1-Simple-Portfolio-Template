namespace MyDigitalCV.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using Models.Web.ViewModels;
    public class CertificateViewModel : PageModel
    {
        private readonly Factories.IFactory<IEnumerable<EducationViewModel>> educationFactory;

        private  IEnumerable<EducationViewModel> educationViewModel;

        private readonly ILogger<EducationViewModel> logger;
        

        public List<SubjectAndCertificatesViewModel> SubjectsModels { get; set; }

        public CertificateViewModel(ILogger<EducationViewModel> logger, Factories.IFactory<IEnumerable<EducationViewModel>> educationFactory)
        {
            this.educationFactory = educationFactory;
            logger = logger;
        }

        public void OnGet()
        {
            this.educationViewModel = this.educationFactory.Create().ToList();
            foreach (var item in this.educationViewModel)
            {
                this.SubjectsModels = item.SchoolItems;
            }
        }
    }
}
