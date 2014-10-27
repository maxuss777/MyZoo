using MyZoo.Common.Interfaces;

namespace MyZoo.Common.ZooItems.BaseClasses
{
    public class Cage : IZooItems<Cage>
    {
        public Cage(string specie, string kind)
        {
            Kind = kind;
            Specie = specie;
        }

        public string Specie { get; private set; }
        public string Kind { get; private set; }
    }
}