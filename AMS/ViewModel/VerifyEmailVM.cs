using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class VerifyEmailVM
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]

        public string? Email { get; set; }
    }
}
