using BackendPRJCT.Models;
using Microsoft.AspNetCore.Identity;

namespace BackendPRJCT.ModelViews.AdminRole
{
    public class UpdateRoleVM
    {
        public List<IdentityRole> Roles { get; set; }

        public IList<string> UserRoles { get; set; }

        public AppUser User { get; set; }
    }
}
