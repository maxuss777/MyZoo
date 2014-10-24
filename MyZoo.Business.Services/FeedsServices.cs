using System;
using System.Collections.Generic;
using MyZoo.Common.ZooItems;
using MyZoo.Common.Feeds;
using MyZoo.DataAccess.Core;

namespace MyZoo.Business.Services
{
    public class FeedsServices : FeedFactory
    {
        readonly FeedsRepository _feedsRepository = new FeedsRepository();

        public override void CreateFeeds(IEnumerable<Feeds> feeds)
        {
            if (feeds == null)
                throw new Exception("Feeds list musn't be empty!");

            foreach (var feed in feeds)
            {
                switch (feed)
                {
                    case Feeds.ForBird:
                        _feedsRepository.Insert(Feeds.ForBird);
                        break;
                    case Feeds.ForMammal:
                        _feedsRepository.Insert(Feeds.ForMammal);
                        break;
                    case Feeds.ForReptile:
                        _feedsRepository.Insert(Feeds.ForReptile);
                        break;
                    case Feeds.ForFish:
                        _feedsRepository.Insert(Feeds.ForFish);
                        break;
                }
            }
        }

        public List<Feeds> CreateRandomFilledFeedsList()
        {
            var array = Enum.GetValues(typeof(Feeds));
            var feedsList = new List<Feeds>();
            var random = new Random();

            for (byte i = 0; i < (byte)Feeds.NoOne; i++)
            {
                feedsList.Add((Feeds)array.GetValue(random.Next(array.Length - 1)));
            }

            return feedsList;
        }

        public List<Feeds> GetAllExistinfFeeds()
        {
            return _feedsRepository.GetAll();
        }
        
    }
}