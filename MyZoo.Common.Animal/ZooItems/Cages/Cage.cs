using MyZoo.Common.Interfaces;


namespace MyZoo.Common.ZooItems
{
    public sealed class Cage : ICage
    {
        public Cage(int id, string type)
        {
            Id = id;
            Type = type;
            Length = 0;
            Width = 0;
            Height = 0;
        }
        
        public Cage(int id, string type, int height, int width, int length)
        {
            Id = id;
            Type = type;
            Length = length;
            Width = width;
            Height = height;
        }

        public string Type { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Length { get; private set; }
        public int Id { get; private set; }

        public string[] ShowDetails()
        {
            return new[]
                {
                    Id.ToString(),
                    Type,
                    Height.ToString(),
                    Width.ToString(),
                    Length.ToString()
                };
        }
    }
}