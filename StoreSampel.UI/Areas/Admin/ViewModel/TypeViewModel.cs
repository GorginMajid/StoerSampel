using System.ComponentModel.DataAnnotations;

namespace StoreSampel.UI.Areas.Admin.ViewModel
{
    public class TypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام تیپ")]
        [Required(ErrorMessage = "لطفا تیپ را وارد کنید")]
        public string Name { get; set; }


        public int ModelId { get; set; }
    }
}