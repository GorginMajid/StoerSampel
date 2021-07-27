using System.ComponentModel.DataAnnotations;

namespace StoreSampel.UI.Models.OrdersViewModel
{
    public class OrderViewModel
    {
        public int BrnadId { get; set; }
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        [Display(Name = "نوع کالا")]
        [Required(ErrorMessage = "لطفا نوع کال را وارد کنید")]
        public string[] ProductType { get; set; }
        [Display(Name = "تعداد کالا")]
        [Required(ErrorMessage = "لطفا تعداد کالا را وارد کنید")]
        public int[] ProductValues { get; set; }
    }
}