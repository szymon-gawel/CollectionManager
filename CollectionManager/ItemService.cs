﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager
{
    public class ItemService
    {
        public List<Item> Items { get; set; }

        public ItemService()
        {
            Items = new List<Item>();
        }

        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            var addNewItemMenu = actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("\r\nSelect collection item type:");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public void AddNewItem(char itemType)
        {
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item item = new Item(1, "");
            item.TypeId = itemTypeId;
            Console.WriteLine("Enter name for new collection item:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description for new collection item:");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter value of new collection item:");
            var value = Console.ReadLine();
            decimal itemValue;
            Decimal.TryParse(value, out itemValue);

            item.Name = name;
            item.Description = desc;
            item.Value = itemValue;

            Items.Add(item);

            Console.WriteLine($"Added collection item {item.Name} \r\n");
        }

        public int RemoveItemView()
        {
            Console.WriteLine("\r\nEnter id of collection item you want to remove:");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            Console.WriteLine("\r\nTo confirm, type yes");
            string confirmation = Console.ReadLine();

            if(confirmation == "yes" || confirmation == "YES" || confirmation == "Yes" || confirmation == "y")
            {
                return id;
            }
            else
            {
                Console.WriteLine("You did not confirm, collection item was not deleted\r\n");
                return 0;
            }
            
        }

        public void RemoveItem(int removeId)
        {
            Item itemToRemove = new Item(1, "");
            foreach (var item in Items)
            {
                if (item.Id == removeId)
                {
                    itemToRemove = item;
                    break;
                }
            }
            Items.Remove(itemToRemove);
        }

        public void ItemsShowByTypeIdView(int typeId)
        {
            List<Item> toShow = new List<Item>();
            foreach (var item in Items)
            {
                if (item.TypeId == typeId)
                {
                    toShow.Add(item);
                }
            }

            if(toShow.Count == 0)
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

        public int ItemTypeSelectionView()
        {
            Console.WriteLine("\r\nEnter Type Id for item type you want to show:");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }

        public void EditExistingItemView()
        {
            Item itemToEdit = new Item();
            Console.WriteLine("\r\nEnter id of item you want to edit:");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            foreach(var item in Items)
            {
                if(id == item.Id)
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
