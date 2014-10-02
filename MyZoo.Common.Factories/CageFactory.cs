using System.Collections.Generic;

namespace MyZoo.Common.Factories
{
    public abstract class CageFactory
    {
        public abstract void CreateCage(List<Cages.Cages> cages);
    }
}