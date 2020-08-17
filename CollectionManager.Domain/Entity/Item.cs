using CollectionManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager.Domain.Entity
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int TypeId { get; set; }

        public Item(int id, string name, int typeId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
        }

        public Item()
        {

        }
    }
}
