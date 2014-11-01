using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.Feeds
{
    public sealed class Feed : IFeed
    {
        public Feed(string forWhom, string type, int gross)
        {
            Gross = gross;
            Type = type;
            ForWhom = forWhom;
        }

        public string ForWhom { get; private set; }
        public string Type { get; private set; }
        public int Gross { get; private set; }
    }
}