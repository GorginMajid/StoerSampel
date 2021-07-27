using System.ComponentModel.DataAnnotations;

namespace StoreSampel.UI.Areas.Admin.ViewModel
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام مدل")]
        [Required(ErrorMessage = "لطفا مدل را وارد کنید")]
        public string Name { get; set; }


        public long BrandId { get; set; }
    }
}