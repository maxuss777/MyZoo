using MyZoo.Common.Animal.Interfaces.Common_Layer_interfaces;

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
