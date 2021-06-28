namespace MyDigitalCV.Pages
{
    using Models.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> logger;
        public PrivacyInformationViewModel PrivacyInformationModel { get; private set; }
        public HomeViewModel HomeModel{ get;private set; }
        private readonly Factories.IFactory<PrivacyInformationViewModel> privacyFactory;
        private readonly Factories.IFactory<HomeViewModel> indexFactory;

        public IndexModel(ILogger<IndexModel> logger, Factories.IFactory<PrivacyInformationViewModel> privacyFactory, Factories.IFactory<HomeViewModel> indexFactory)
        {
            this.logger = logger;
            this.privacyFactory = privacyFactory;
            this.indexFactory = indexFactory;
        }

        public void OnGet()
        {
            this.HomeModel = indexFactory.Create();
            this.PrivacyInformationModel = privacyFactory.Create();
        }
    }
}
