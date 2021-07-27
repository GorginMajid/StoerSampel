using System;

namespace StoreSampel.Domain.BaseEntities
{
    public class BaseEnities
    {
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }

    public class BaseEntites<TModelId>
    {
        public TModelId Id { get; set; }
        public DateTime? CreateDate { get; set; }=DateTime.Now;
    }
}