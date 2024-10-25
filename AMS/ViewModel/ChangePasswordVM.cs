using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(40, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "NewPassword Donot Match")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "ConfirmNewPassword is Required")]
        [DataType(DataType.Password)]
        public string? ConfirmNewPassword { get; set; }
    }
}
