using CollectionManager.App.Abstract;
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
        private IService<Item> _itemService;

        public ItemManager(MenuActionService actionService, IService<Item> itemService)
        {
            _itemService = itemService;
            _actionService = actionService;
        }

        public Item CreateItem()
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
            if (desc == null)
            {
                desc = "No description";
            }
            Console.WriteLine("\r\nEnter value of new item:");
            var value = Console.ReadLine();
            decimal itemValue;
            Decimal.TryParse(value, out itemValue);
            var lastId = _itemService.GetLastId();
            Item item = new Item(lastId + 1, name, typeId) { Description = desc, Value = itemValue };
            return item;
        }

        public List<Item> GetAllItems()
        {
            var items = _itemService.GetItems();
            return items;
        }

        public int AddItem(Item item)
        {
            _itemService.AddItem(item);
            return item.Id;  
        }

        public Item ChooseRemoveItem()
        {
            bool isNotEmpty = CollectionIsNotEmpty();
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
                    return itemToRemove;
                }
                else
                {
                    Console.WriteLine("You did not confirm, collection item was not deleted\r\n");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("\r\nCollections are empty");
                return null;
            }
        }

        public int RemoveItem(Item itemToRemove)
        {
            _itemService.RemoveItem(itemToRemove);
            return itemToRemove.Id;
        }

        public bool CollectionIsNotEmpty()
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

        public int GetItemsTypeId()
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
            return id;
        }

        public List<Item> GetItemsOfTheSameType(int typeId)
        {
            List<Item> toShow = new List<Item>();
            foreach (var item in _itemService.Items)
            {
                if (item.TypeId == typeId)
                {
                    toShow.Add(item);
                }
            }
            return toShow;
        }

        public void ShowItemsOfSameType(List<Item> toShow)
        {
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
            var typeId = GetItemsTypeId();
            var toShow = GetItemsOfTheSameType(typeId);
            ShowItemsOfSameType(toShow);
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
