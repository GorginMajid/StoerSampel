using Microsoft.AspNetCore.Identity;

namespace StoreSampel.Domain.Identity
{
    public class ApplicationRole:IdentityRole<int>
    {
        public ApplicationRole(string name) : base(name)
        {

        }

        public override string ConcurrencyStamp { get; set; }
    }
}