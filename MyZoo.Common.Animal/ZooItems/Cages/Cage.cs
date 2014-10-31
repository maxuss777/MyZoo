using System.Globalization;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.ZooItems.BaseClasses
{
    public sealed class Cage : ICage
    {
        public Cage(int whomBelongs)
        {
            WhomBelongs = whomBelongs;
        }
        
        public Cage(int height, int width, int length, int whomBelongs)
        {
            WhomBelongs = whomBelongs;
            Length = length;
            Width = width;
            Height = height;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Length { get; private set; }
        public int WhomBelongs { get; private set; }

        public string[] ShowDetails()
        {
            return new[]
                {
                    WhomBelongs.ToString(CultureInfo.InvariantCulture),
                    Height.ToString(CultureInfo.InvariantCulture),
                    Width.ToString(CultureInfo.InvariantCulture),
                    Length.ToString(CultureInfo.InvariantCulture)
                };
        }
    }
}