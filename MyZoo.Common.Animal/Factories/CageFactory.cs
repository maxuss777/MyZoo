using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common_Layer_interfaces;

namespace MyZoo.Common.ZooItems
{
    public abstract class CageFactory
    {
        public abstract void CreateCages(IEnumerable<ICages> cages);
    }
}