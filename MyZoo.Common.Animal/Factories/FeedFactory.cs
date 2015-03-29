using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.Animal.Factories
{
    public abstract class FeedFactory
    {
        public abstract void CreateFeeds(IEnumerable<IFeed> feeds);
    }
}
