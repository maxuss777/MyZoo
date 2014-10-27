using System.Collections.Generic;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems.BaseClasses;

namespace MyZoo.Common.ZooItems
{
    public abstract class CageFactory
    {
        public abstract void CreateCages(IEnumerable<IZooItems<Cage>> cages);
    }
}