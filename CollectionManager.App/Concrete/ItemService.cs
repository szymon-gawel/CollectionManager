using CollectionManager.App.Common;
using CollectionManager.Domain;
using CollectionManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager.App.Concrete
{
    public class ItemService : BaseService<Item>
    {

        /*

        
        */
        public void EditExistingItemView()
        {
            Item itemToEdit = new Item();
            Console.WriteLine("\r\nEnter id of item you want to edit:");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            foreach (var item in Items)
            {
                if (id == item.Id)
                {
                    itemToEdit = item;
                    Console.WriteLine("Set new name:");
                    var newName = Console.ReadLine();
                    Console.WriteLine("Set new description:");
                    var newDesc = Console.ReadLine();
                    Console.WriteLine("Set new value:");
                    var newValue = Console.ReadLine();
                    decimal newItemValue;
                    Decimal.TryParse(newValue, out newItemValue);
                    item.Name = newName;
                    item.Description = newDesc;
                    item.Value = newItemValue;
                    break;
                }
            }
        }
    }
}
