using MyZoo.Common.Interfaces;

namespace MyZoo.Common.ZooItems.BaseClasses
{
    public class Animal : IZooItems<Animal>
    {
        public Animal(string specie, string kind)
        {
            Specie = specie;
            Kind = kind;
        }

        public string Specie { get; private set; }
        public string Kind { get; private set; }
    }
}
