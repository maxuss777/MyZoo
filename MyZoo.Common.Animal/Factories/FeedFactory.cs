using System.Collections.Generic;

namespace MyZoo.Common.Factories
{
    public abstract class FeedFactory
    {
        public abstract void CreateFeeds(List<Feeds.Feeds> feeds);
    }
}
