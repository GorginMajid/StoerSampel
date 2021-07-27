using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using StoreSampel.Domain.BaseEntities;
using StoreSampel.Domain.Entities.Models;
using StoreSampel.Domain.Entities.Orders;

namespace StoreSampel.Domain.Entities.Types
{
    public class Type:BaseEntites<int>
    {
        public string Name { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }

        #region NavigationProprty

        public Model Model { get; set; }
        public ICollection<Order> Orders { get; set; }  
        #endregion
    }
}