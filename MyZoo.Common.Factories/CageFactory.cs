using System.Collections.Generic;

namespace MyZoo.Common.Factories
{
    public abstract class CageFactory
    {
        public abstract void CreateCages(List<Cages.Cages> cages);
    }
}