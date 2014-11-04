using MyZoo.Common.Interfaces;


namespace MyZoo.Common.ZooItems
{
    public sealed class Feed : IFeed
    {
        public Feed(int id, string forWhom)
        {
            Id = id;
            ForWhom = forWhom;
            Type = string.Empty;
            Gross = 0;
        }

        public Feed(int id, string type, int gross, string forWhom)
        {
            Id = id;
            Type = type;
            Gross = gross;            
            ForWhom = forWhom;
        }

        public string Type { get; private set; }
        public int Gross { get; private set; }
        public string ForWhom { get; private set; }
        public int Id { get; private set; }

        public string[] ShowDetails()
        {
            return new[]
                {
                    Id.ToString(),
                    Type,
                    Gross.ToString(),
                    ForWhom
                };
        }
    }
}