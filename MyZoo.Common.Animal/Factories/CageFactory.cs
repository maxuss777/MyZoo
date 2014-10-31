using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.ZooItems
{
    public abstract class CageFactory
    {
        public abstract void CreateCages(IEnumerable<ICage> cages);
    }
}