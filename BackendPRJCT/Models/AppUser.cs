using Microsoft.AspNetCore.Identity;

namespace BackendPRJCT.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
