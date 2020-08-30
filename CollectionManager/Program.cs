using CollectionManager.App.Abstract;
using CollectionManager.App.Concrete;
using CollectionManager.App.Managers;
using CollectionManager.Domain.Entity;
using System;
using System.ComponentModel.Design;
using System.Linq;

namespace CollectionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            IService<Item> itemService = new ItemService();
            ItemManager itemManager = new ItemManager(actionService, itemService);
            SavingService savingService = new SavingService();

            //Welcome User
            Console.WriteLine("Welcome to the Collection Manager!");
            while (true)
            {
                //Giving user a choice what to do next
                Console.WriteLine("\r\nPlease, choose your next action:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();

                //Proccessing users decision
                switch (operation.KeyChar)
                {
                    case '1':
                        var item = itemManager.CreateItem();
                       itemManager.AddItem(item);
                        break;
                    case '2':
                        var itemToRemove = itemManager.ChooseRemoveItem();
                        itemManager.RemoveItem(itemToRemove);
                        break;
                    case '3':
                        itemManager.EditExistingItem();
                        break;
                    case '4':
                        var typeId = itemManager.GetItemsTypeId();
                        var toShow = itemManager.GetItemsOfTheSameType(typeId);
                        if (toShow.Any())
                        {
                            itemManager.ShowItemsOfSameType(toShow);
                        }
                        else
                        {
                            Console.WriteLine("\r\nCollection is empty");
                        }
                        break;
                    case '5':
                        var items = itemManager.GetAllItems();
                        savingService.SaveToFile(items);
                        break;
                    default:
                        Console.WriteLine("\r\nAction you entered does not exist");
                        break;
                }
            }
        }
    }
}
