using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.Feeds
{
    public sealed class Feed : IFeed
    {
        public Feed(string type, int gross)
        {
            Type = type;
            Gross = gross;
            ForWhom = string.Empty;
        }

        public Feed(string type, int gross, string forWhom)
        {
            Type = type;
            Gross = gross;            
            ForWhom = forWhom;
        }

        public string Type { get; private set; }
        public int Gross { get; private set; }
        public string ForWhom { get; private set; }

        public string[] ShowDetails()
        {
            return new string[]
                {
                    Type,
                    Gross.ToString(),
                    ForWhom
                };
        }
    }
}