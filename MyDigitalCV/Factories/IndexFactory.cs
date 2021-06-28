namespace MyDigitalCV.Factories
{
    using Models.Web.ViewModels;
    public class IndexFactory : IFactory<HomeViewModel>
    {
        private HomeViewModel indexModel;
       
        public HomeViewModel Create()
        {
            this.indexModel = new HomeViewModel();
           
           this.indexModel.IndexContent.Add("Certificate", "In this section you can see my certificates.");

           this.indexModel.IndexContent.Add("Projects", "In this section you can see my projects.");

           this.indexModel.IndexContent.Add("ProfessionalExperience", "In this section you can see my professional experience.");

           this.indexModel.IndexContent.Add("Contact", "Contact me, I will be happy if I can be useful to you.");

            return this.indexModel;
        }
    }
}
