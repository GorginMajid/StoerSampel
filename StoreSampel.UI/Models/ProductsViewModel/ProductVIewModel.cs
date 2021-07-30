using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreSampel.UI.Models.ProductsViewModel
{
    public class ProductVIewModel
    {
        [Display(Name = "نوع کالا")]
        [Required(ErrorMessage = "لطفا نوع کال را وارد کنید")]
        public string[] ProductType { get; set; }
        [Display(Name = "تعداد کالا")]
        [Required(ErrorMessage = "لطفا تعداد کالا را وارد کنید")]
        public long[] ProductValues { get; set; }
    }
}
