using System.Globalization;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.ZooItems.BaseClasses
{
    public sealed class Cage : ICage
    {
        public Cage(string type)
        {
            Type = type;
            Length = 0;
            Width = 0;
            Height = 0;
        }
        
        public Cage(string type, int height, int width, int length)
        {
            Type = type;
            Length = length;
            Width = width;
            Height = height;
        }

        public string Type { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Length { get; private set; }
        
        public string[] ShowDetails()
        {
            return new[]
                {
                    Type,
                    Height.ToString(CultureInfo.InvariantCulture),
                    Width.ToString(CultureInfo.InvariantCulture),
                    Length.ToString(CultureInfo.InvariantCulture)
                };
        }
    }
}