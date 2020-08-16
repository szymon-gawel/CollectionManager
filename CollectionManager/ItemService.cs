using System;
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

        public int AddNewItem(char itemType)
        {
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item item = new Item(1, "");
            item.TypeId = itemTypeId;
            Console.WriteLine("\r\nEnter id for new collection item:");
            var id = Console.ReadLine();
            int itemId;
            Int32.TryParse(id, out itemId);
            Console.WriteLine("Enter name for new collection item:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description for new collection item:");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter value of new collection item:");
            var value = Console.ReadLine();
            decimal itemValue;
            Decimal.TryParse(value, out itemValue);

            item.Id = itemId;
            item.Name = name;
            item.Description = desc;
            item.Value = itemValue;

            Items.Add(item);

            Console.WriteLine($"Added collection item {item.Name} \r\n");
            return itemId;
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
            Item productToRemove = new Item(1, "");
            foreach (var item in Items)
            {
                if (item.Id == removeId)
                {
                    productToRemove = item;
                    break;
                }
            }
            Items.Remove(productToRemove);
        }

        public void ItemsByTypeIdView(int typeId)
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
                Console.WriteLine("This collection is empty\r\n");
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
            Console.WriteLine("\r\nPlease enter Type Id for item type you want to show:");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }

    }
}
