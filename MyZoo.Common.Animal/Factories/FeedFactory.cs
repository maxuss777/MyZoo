using System.Collections.Generic;
using MyZoo.Common.Interfaces;


namespace MyZoo.Common.ZooItems
{
    public abstract class FeedFactory
    {
        public abstract void CreateFeeds(IEnumerable<IFeed> feeds);
    }
}
