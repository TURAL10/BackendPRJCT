using System.ComponentModel.DataAnnotations;

namespace BackendPRJCT.ModelViews.Account
{
    public class Login
    {
        [Required, StringLength(50)]
        public string UserNameOrEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
