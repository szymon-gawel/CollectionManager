using System;
using System.ComponentModel.Design;

namespace CollectionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            ItemService itemService = new ItemService();
            actionService = Initialize(actionService);

            //Welcome User
            Console.WriteLine("Welcome to the Collection Manager!");
            while (true)
            {
                //Give user a choice what to do next
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
                        var keyInfo = itemService.AddNewItemView(actionService);
                        var id = itemService.AddNewItem(keyInfo.KeyChar);
                        break;
                    case '2':
                        var removeId = itemService.RemoveItemView();
                        itemService.RemoveItem(removeId);
                        break;
                    case '3':
                        var idTypeToShow = itemService.ItemTypeSelectionView();
                        itemService.ItemsByTypeIdView(idTypeToShow);
                        break;
                    default:
                        Console.WriteLine("\r\nAction you entered does not exist");
                        break;


                }
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add item", "Main");
            actionService.AddNewAction(2, "Remove item", "Main");
            actionService.AddNewAction(3, "List all items", "Main");

            actionService.AddNewAction(1, "Coins", "AddNewItemMenu");
            actionService.AddNewAction(2, "Post Cards", "AddNewItemMenu");

            return actionService;
        }
    }
}
