namespace MyDigitalCV.Pages
{
    using Models.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;


    public class AboutModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        public PrivacyInformationViewModel PrivacyInformationModel { get; private set; }

        private readonly Factories.IFactory<PrivacyInformationViewModel> privacyFactory;

        public AboutModel(ILogger<IndexModel> logger, Factories.IFactory<PrivacyInformationViewModel> privacyFactory)
        {
            this.logger = logger;
            this.privacyFactory = privacyFactory;
        }

        public void OnGet()
        {

            this.PrivacyInformationModel = privacyFactory.Create();
        }
    }
}
