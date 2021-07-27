using System.ComponentModel.DataAnnotations;

namespace StoreSampel.UI.Areas.Admin.ViewModel
{
    public class BrandViewModel
    {
        public long Id { get; set; }
        [Display(Name = "نام برند")]
        [Required(ErrorMessage = "لطفا برند را وارد کنید")]
        public string Name { get; set; }
    }
}