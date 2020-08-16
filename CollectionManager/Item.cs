using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int TypeId { get; set; }

        public Item(int id, string name)
        {

        }
    }
}
