using System.ComponentModel.DataAnnotations.Schema;
using StoreSampel.Domain.BaseEntities;
using StoreSampel.Domain.Entities.Brands;
using StoreSampel.Domain.Entities.Models;
using StoreSampel.Domain.Entities.Types;
using StoreSampel.Domain.Identity;

namespace StoreSampel.Domain.Entities.Orders
{
    public class Order:BaseEntites<string>
    {

        public Status Status { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Brand")]

        public long BrandId { get; set; }

        [ForeignKey("Model")]

        public int ModelId { get; set; }

        [ForeignKey("Type")]

        public int TypeId { get; set; }

        #region NavigationProprty

        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public Type Type { get; set; }

        public ApplicationUser User { get; set; }

      
        #endregion
    }

    public enum Status
    {
        Success=1,
        Pending=2,
        NotApproved=3
    }
}