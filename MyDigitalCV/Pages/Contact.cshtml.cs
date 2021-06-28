namespace MyDigitalCV.Pages
{
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using GoogleReCaptcha;
    using Messaging;
    public class ContactModel : PageModel
    {

        private readonly IEmailSender emailSender;

        [Required]
        [Display(Name = "Your Name")]
        [BindProperty]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Your Email")]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Subject")]
        [BindProperty]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Message")]
        [BindProperty]
        public string Message { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
        public ContactModel(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
        public void OnGet()
        {

        }
        
        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await emailSender.SendEmailAsync(
                 GlobalConstants.SenderEmail,
                 Name,
                 GlobalConstants.Email,
                 Subject,
                 ModifyContentMessage(this.Message, this.Email));
            return RedirectToPage("/ThankYou");
        }
        private string ModifyContentMessage(string content, string email)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(content);
            sb.AppendLine(email);
            return sb.ToString();
        }
    }
}
