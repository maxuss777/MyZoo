using MyZoo.Common.ZooItems.Interfaces.Common_Layer_interfaces;

namespace MyZoo.Common.ZooItems.BaseClasses
{
    public class Cage : ICages
    {
        public Cage(string type, int heght, int weght, int length)
        {
            Type = type;
            Length = length;
            Weght = weght;
            Heght = heght;
        }

        public int Heght { get; private set; }
        public int Weght { get; private set; }
        public int Length { get; private set; }
        public string Type { get; private set; }
    }
}