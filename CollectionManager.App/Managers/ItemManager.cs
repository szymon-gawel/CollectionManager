using CollectionManager.App.Concrete;
using CollectionManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionManager.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private ItemService _itemService;

        public ItemManager(MenuActionService actionService)
        {
            _itemService = new ItemService();
            _actionService = actionService;
        }

        public int AddNewItem()
        {
            var ItemTypeMenu = _actionService.GetMenuActionsByMenuName("ItemTypeMenu");
            Console.WriteLine("\r\nSelect collection item type:");
            for (int i = 0; i < ItemTypeMenu.Count; i++)
            {
                Console.WriteLine($"{ItemTypeMenu[i].Id}. {ItemTypeMenu[i].Name}");
            }

            var operation = Console.ReadKey();

            int typeId;
            Int32.TryParse(operation.KeyChar.ToString(), out typeId);
            Console.WriteLine("\r\nEnter name of new item:");
            var name = Console.ReadLine();
            Console.WriteLine("\r\nEnter description of new item:");
            var desc = Console.ReadLine();
            if(desc == null)
            {
                desc = "No description";
            }
            Console.WriteLine("\r\nEnter value of new item:");
            var value = Console.ReadLine();
            decimal itemValue;
            Decimal.TryParse(value, out itemValue);
            var lastId = _itemService.GetLastId();
            Item item = new Item(lastId + 1, name, typeId) { Description = desc, Value = itemValue };
            _itemService.AddItem(item);
            return item.Id;
        }

        public void RemoveItem()
        {
            bool isNotEmpty = ShowAllItems();
            if (isNotEmpty == true)
            {
                Console.WriteLine("\r\n");
                foreach (var item in _itemService.Items)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }

                Console.WriteLine("\r\nEnter id of item you want to remove:");
                var itemId = Console.ReadKey();
                int id;
                Int32.TryParse(itemId.KeyChar.ToString(), out id);

                Item itemToRemove = new Item();

                foreach (var item in _itemService.Items)
                {
                    if (item.Id == id)
                    {
                        itemToRemove = item;
                        break;
                    }
                }

                Console.WriteLine("\r\nTo confirm, type yes");
                string confirmation = Console.ReadLine();

                if (confirmation == "yes" || confirmation == "YES" || confirmation == "Yes" || confirmation == "y")
                {
                    _itemService.RemoveItem(itemToRemove);
                    Console.WriteLine("Item removed");
                }
                else
                {
                    Console.WriteLine("You did not confirm, collection item was not deleted\r\n");
                }
            }
            else
            {
                Console.WriteLine("\r\nCollections are empty");
            }
        }

        public bool ShowAllItems()
        {
            if (_itemService.Items.Any())
            {
                return true;
            }
            else
            {  
                return false;
            }
        }

        public void ShowItemsOfOneType()
        {
            Console.WriteLine("\r\nEnter Type Id for items you want to show:");
            var ItemTypeMenu = _actionService.GetMenuActionsByMenuName("ItemTypeMenu");
            for (int i = 0; i < ItemTypeMenu.Count; i++)
            {
                Console.WriteLine($"{ItemTypeMenu[i].Id}. {ItemTypeMenu[i].Name}");
            }
            var typeId = Console.ReadKey();
            int id;
            Int32.TryParse(typeId.KeyChar.ToString(), out id);

            List<Item> toShow = new List<Item>();
            foreach(var item in _itemService.Items)
            {
                if(item.TypeId == id)
                {
                    toShow.Add(item);
                }
            }

            if (toShow.Count == 0)
            {
                Console.WriteLine("\r\nThis collection is empty\r\n");
            }
            else
            {
                Console.WriteLine("\r\nID. Name, Description, Value");
                foreach (var item in toShow)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}, {item.Description}, {item.Value}");
                }
            }
        }

        public void EditExistingItem()
        {
            ShowItemsOfOneType();
            Console.WriteLine("\r\nEnter id of item you want to edit:");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            Item itemToEdit = new Item();

            foreach (var item in _itemService.Items)
            {
                if (id == item.Id)
                {
                    itemToEdit = item;
                    Console.WriteLine("\r\nSet new name:");
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
