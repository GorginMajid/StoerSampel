using System.ComponentModel.DataAnnotations;

namespace StoreSampel.UI.Models.AccountViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "نام و نام حانوادگی")]
        [Required(ErrorMessage = "لطفا نام و نام حانوادگی را وارد کنید")]
      
      
        public string FullName { get; set; }
        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا گذرواژه را وارد کنید")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Display(Name = "تکرار گذرواژه")]
        [Required(ErrorMessage = "لطفا تکرار گذرواژه را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "گذرواژه و تکرار گذرواژه یکی نمی باشد")]
        public string RePassword { get; set; }
    }
}