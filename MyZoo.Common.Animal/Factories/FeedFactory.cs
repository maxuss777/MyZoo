using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.ZooItems
{
    public abstract class FeedFactory
    {
        public abstract void CreateFeeds(IEnumerable<IFeed> feeds);
    }
}
