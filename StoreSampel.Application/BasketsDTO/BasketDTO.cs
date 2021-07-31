using System.Collections.Generic;
using StorSampel.Common;

namespace StoreSampel.Application.BasketsDTO
{
    public class BasketDTO
    {
        public string OrderId { get; set; }
        public string RegisterDate { get; set; }
        public StringExtensions.Status Status { get; set; }
    
        public string BrnadName { get; set; }
        public string ModelName { get; set; }
        public string TypeName { get; set; }
//        public ICollection<ProductOrder> Products { get; set; }

    }

    public class ProductOrder
    {
        public string ProductType { get; set; }
        public long ProductValue { get; set; }

    
        public string OrderId { get; set; }
    }
}