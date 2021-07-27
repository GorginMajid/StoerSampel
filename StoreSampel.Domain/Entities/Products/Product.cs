using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreSampel.Domain.BaseEntities;
using StoreSampel.Domain.Entities.Orders;
using StoreSampel.Domain.Identity;

namespace StoreSampel.Domain.Entities.Products
{
    public class Product:BaseEnities
    {
        public string ProductType { get; set; }
        public long ProductValue { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        #region NavigationProprty

        public ApplicationUser User { get; set; }
      

        #endregion
    }
}