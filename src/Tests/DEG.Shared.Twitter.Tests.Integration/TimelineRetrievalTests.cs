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
        private Timeline _timeline;

        [SetUp]
        public void TestSetup()
        {
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];

            if (string.IsNullOrEmpty(consumerKey))
                Assert.Inconclusive("You must set the consumer key for integration tests to run.");
            if (string.IsNullOrEmpty(consumerSecret))
                Assert.Inconclusive("You must set the consumer secret for integration tests to run.");

            var auth = new ApplicationOnlyAuth(consumerKey, consumerSecret);
            var service = new TwitterService(auth);

            _timeline = service.GetUserTimeline("PatrickDelancy", 3);
        }

        [Test]
        public void CanRetrieveNumberOfTweetsRequested()
        {
            _timeline.Tweets.Should().HaveCount(3);
        }

        [Test]
        public void CanParseTweetCreatedDateTime()
        {
            _timeline.Tweets.First().Created.Should().BeAfter(default(DateTime));
        }

        [Test]
        public void CanRetrieveTweetContent()
        {
            _timeline.Tweets.First().Text.Should().NotBeNullOrEmpty();
        }
    }
}
