using System.Collections.Generic;

namespace Models.Web.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.IndexContent = new Dictionary<string, string>();
        }
        public Dictionary<string, string> IndexContent { get; set; }
    }
}
