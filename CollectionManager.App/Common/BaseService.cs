using CollectionManager.App.Abstract;
using CollectionManager.App.Concrete;
using CollectionManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionManager.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }

            return lastId;
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public int EditItem(T item)
        {
            var itemToEdit = Items.FirstOrDefault(p => p.Id == item.Id);
            if(itemToEdit != null)
            {
                itemToEdit = item;
            }
            return itemToEdit.Id;
        }

        public List<T> GetItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }
    }
}
