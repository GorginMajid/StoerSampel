using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using StoreSampel.Domain.Entities.Products;

namespace StoreSampel.Domain.Identity
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Address { get; set; }




        #region NavigationProprty

        public virtual ICollection<Product> Products { get; set; }


        #endregion
    }
}