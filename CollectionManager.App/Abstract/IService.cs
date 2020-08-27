using CollectionManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionManager.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetItems();

        int GetLastId();

        int AddItem(T item);

        int EditItem(T item);

        void RemoveItem(T item);
    }
}
