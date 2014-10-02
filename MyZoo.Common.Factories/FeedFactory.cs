using System.Collections.Generic;

namespace MyZoo.Common.Factories
{
    public abstract class FeedFactory
    {
        public abstract void CreateFeed(List<Feeds.Feeds> feeds);
    }
}
