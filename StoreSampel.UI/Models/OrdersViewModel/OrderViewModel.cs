using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreSampel.UI.Models.OrdersViewModel
{
    public class OrderViewModel
    {
        [Display(Name = "برند")]
        [Required(ErrorMessage = "لطفا برند را وارد کنید")]
        public int BrnadId { get; set; }
        [Display(Name = "مدل")]
        [Required(ErrorMessage = "لطفا مدل را وارد کنید")]
        public int ModelId { get; set; }
        [Display(Name = "تیپ")]
        [Required(ErrorMessage = "لطفا تیپ را وارد کنید")]
        public int TypeId { get; set; }

      
   
    }

  


}