using System;
using System.Collections;
using System.Collections.Generic;
using StoreSampel.Domain.BaseEntities;
using StoreSampel.Domain.Entities.Models;
using StoreSampel.Domain.Entities.Orders;

namespace StoreSampel.Domain.Entities.Brands
{
    public class Brand:BaseEnities
    {
        public string Name { get; set; }


        #region NavigationProprty

        public ICollection<Model> Models { get; set; }
        public ICollection<Order> Orders { get; set; }
        #endregion
    }
}