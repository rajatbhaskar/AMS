using Microsoft.AspNetCore.Identity;

namespace AMS.Models
{
    public class Users:IdentityUser
    {

        public string? FullName {  get; set; }

        public string? EnrollNumber { get; set; }
    }
}
