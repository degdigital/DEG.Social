using System;
using System.Configuration;
using System.Linq;
using DEG.Shared.Twitter;
using DEG.Twitter.Authentication;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Twitter.Tests
{
    [TestFixture]
    [Category("Integration")]
    public class TwitterServiceTests
    {
        private TwitterService _sut;

        [SetUp]
        public void TestSetup()
        {
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];

            if (string.IsNullOrEmpty(consumerKey))
                Assert.Inconclusive("You must set the consumer key for integration tests to run.");
            if (string.IsNullOrEmpty(consumerSecret))
                Assert.Inconclusive("You must set the consumer secret for integration tests to run.");

            var auth = new TwitterApplicationOnlyAuth(consumerKey, consumerSecret);
            _sut = new TwitterService(auth);

        }

        [Test]
        public void CanRetrieveNumberOfTweetsRequested()
        {
            var timeline = _sut.GetUserTimeline("DEGDigital", 3);
            timeline.Tweets.Should().HaveCount(3);
        }

        [Test]
        public void CanParseTweetCreatedDateTime()
        {
            var timeline = _sut.GetUserTimeline("DEGDigital", 3);
            timeline.Tweets.First().Created.Should().BeAfter(default(DateTime));
        }

        [Test]
        public void CanRetrieveTweetContent()
        {
            var timeline = _sut.GetUserTimeline("DEGDigital", 3);
            timeline.Tweets.First().Text.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void CanRetrieveMentions()
        {
            var mentions = _sut.GetMentions("deg", 3);
            mentions.Should().NotBeEmpty();
        }

        [Test]
        public void CanRetrieveHashtagTweets()
        {
            var tweets = _sut.GetTweetsWithHashtag("deg");
            tweets.Should().NotBeEmpty();
        }

        [Test]
        public void CanReadScreenName()
        {
            var timeline = _sut.GetUserTimeline("DEGDigital", 3);
            timeline.Tweets.First().TwitterUser.ScreenName.Should().NotBeNullOrEmpty();
        }
    }
}
