using System.ComponentModel.DataAnnotations;

namespace BackendPRJCT.ModelViews.AdminUser
{
    public class UpdateUserVM
    {
        public string Id { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
