using System.Collections.Generic;

namespace MyZoo.Common.Animal.Interfaces.DataAccess.Core.Interfaces
{
    public interface IZooItemsRepository<T>
    {
        void Insert(T items);
        IEnumerable<T> GetAllItems();
        T GetLastCreatedItem();
    }
}