using CollectionManager.App.Common;
using CollectionManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach(var menuAction in Items)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add item", "Main"));
            AddItem(new MenuAction(2, "Remove item", "Main"));
            AddItem(new MenuAction(3, "Edit item", "Main"));
            AddItem(new MenuAction(4, "List all items", "Main"));

            AddItem(new MenuAction(1, "Coins", "ItemTypeMenu"));
            AddItem(new MenuAction(2, "Post Cards", "ItemTypeMenu"));
        }
    }
}
