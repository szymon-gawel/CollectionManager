using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().GetHashCode();
            this.CreatedAt = DateTime.Now;
        }
    }
}
