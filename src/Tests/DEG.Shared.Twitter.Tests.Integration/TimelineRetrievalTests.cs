using System;
using System.Configuration;
using System.Linq;
using DEG.Shared.Twitter.Authorization;
using DEG.Shared.Twitter.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Shared.Twitter.Tests.Integration
{
    [TestFixture]
    [Category("Integration")]
    public class TimelineRetrievalTests
    {
        private readonly Timeline _timeline;

        public TimelineRetrievalTests()
        {
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];

            consumerKey.Should().NotBeNullOrEmpty();
            consumerSecret.Should().NotBeNullOrEmpty();

            var auth = new ApplicationOnlyAuth(consumerKey, consumerSecret);
            var service = new TwitterService(auth);

            _timeline = service.GetUserTimeline("PatrickDelancy", 3);
        }

        [Test]
        public void CanRetrieveTweets()
        {
            _timeline.Tweets.Should().HaveCount(3);
        }

        [Test]
        public void CanParseTweetCreatedDateTime()
        {
            _timeline.Tweets.First().Created.Should().BeAfter(default(DateTime));
        }
    }
}
