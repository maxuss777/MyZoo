using System.Collections.Generic;


namespace MyZoo.Common.Interfaces
{
    public interface IZooItemsRepository<T>
    {
        void Insert(T items);

        IEnumerable<T> GetAllItems();

        T GetLastCreatedItem();
    }
}
