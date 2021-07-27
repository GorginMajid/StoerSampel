using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using StoreSampel.Domain.BaseEntities;
using StoreSampel.Domain.Entities.Brands;
using StoreSampel.Domain.Entities.Orders;
using StoreSampel.Domain.Entities.Types;

namespace StoreSampel.Domain.Entities.Models
{
    public class Model:BaseEntites<int>
    {
        public string Name { get; set; }

        [ForeignKey("Brand")]
        public long BrandId { get; set; }

      

        #region NavigationProprty

        public Brand Brand { get; set; }
        public ICollection<Type> Types{ get; set; }
        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}