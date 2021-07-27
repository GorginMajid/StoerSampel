using System.ComponentModel.DataAnnotations;

namespace StoreSampel.UI.Models.AccountViewModel
{
    public class SignInViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا گذرواژه را وارد کنید")]
        public string Password { get; set; }
        [Display(Name = "مرا بخاطر بسپار؟")]

        public bool RememberMe { get; set; }
    }
}