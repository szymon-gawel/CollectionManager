using CollectionManager.App.Abstract;
using CollectionManager.App.Concrete;
using CollectionManager.App.Managers;
using CollectionManager.Domain.Entity;
using System;
using System.ComponentModel.Design;

namespace CollectionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            ItemManager itemManager = new ItemManager(actionService);

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
                        var itemId = itemManager.AddNewItem();
                        break;
                    case '2':
                        itemManager.RemoveItem();
                        break;
                    case '3':
                        itemManager.EditExistingItem();
                        break;
                    case '4':
                        itemManager.ShowItemsOfOneType();
                        break;
                    default:
                        Console.WriteLine("\r\nAction you entered does not exist");
                        break;
                }
            }
        }
    }
}
