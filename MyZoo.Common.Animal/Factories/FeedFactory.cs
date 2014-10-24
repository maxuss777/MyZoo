using System.Collections.Generic;

namespace MyZoo.Common.ZooItems
{
    public abstract class FeedFactory
    {
        public abstract void CreateFeeds(IEnumerable<Feeds.Feeds> feeds);
    }
}
