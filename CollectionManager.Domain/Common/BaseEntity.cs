using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
