using System;
using System.Collections.Generic;
using MyZoo.Common.Factories;
using MyZoo.Common.Feeds;
using MyZoo.DataAccess.Core;

namespace MyZoo.Business.Services
{
    public class FeedsServices : FeedFactory
    {
        readonly FeedsRepository _feedsRepository = new FeedsRepository();

        public override void CreateFeed(List<Feeds> feeds)
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
                }
            }
        }

        public List<Feeds> GetAllExistinfFeeds()
        {
            return _feedsRepository.GetAll();
        }
        
    }
}