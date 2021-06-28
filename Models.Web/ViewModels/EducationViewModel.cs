using System.Collections.Generic;

namespace Models.Web.ViewModels
{
    public class EducationViewModel
    {
        public string Period { get; set; }

        public string Specialty { get; set; }

        public string Degree { get; set; }

        public string EducationalInstitution { get; set; }

        public string Location { get; set; }

        public List<SubjectAndCertificatesViewModel> SchoolItems { get; set; }
    }
}
