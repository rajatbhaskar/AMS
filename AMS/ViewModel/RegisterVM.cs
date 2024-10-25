using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class RegisterVM
    {

        [Required(ErrorMessage ="Name is Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(40,MinimumLength =8)]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="Password Donot Match")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


}
}
