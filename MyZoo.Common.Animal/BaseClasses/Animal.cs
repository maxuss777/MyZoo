using MyZoo.Common.Interfaces;

namespace MyZoo.Common.ZooItems.BaseClasses
{
    public abstract class Animal : IAnimals
    {
        protected Animal(string specie, string kind)
        {
            Specie = specie;
            Kind = kind;
        }

        public string Specie { get; private set; }
        public string Kind { get; private set; }
    }
}
