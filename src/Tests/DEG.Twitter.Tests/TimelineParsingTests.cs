using System;
using System.IO;
using System.Linq;
using DEG.Service.Core.Helpers;
using DEG.Shared.Twitter.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Twitter.Tests
{
    [TestFixture]
    public class TimelineParsingTests
    {
        private readonly Timeline _timeline;

        public TimelineParsingTests()
        {
            var file = File.OpenText(@".\Data\TwitterTestTimelineJson.json");

            _timeline = new Timeline {Tweets = JsonHelper.Parse<Tweet[]>(file.ReadToEnd())};
        }

        [Test]
        public void ParsedBothTweets()
        {
            _timeline.Tweets.Should().HaveCount(2);
        }

        [Test]
        public void ParsedCreatedDateTime()
        {
            //Wed Aug 29 17:12:58 +0000 2012
            _timeline.Tweets.First().Created.Should().Be(DateTime.Parse("2012-08-29 17:12:58 Z"));
        }

        [Test]
        public void ParsedId()
        {
            _timeline.Tweets.First().Id.Should().Be(240859602684612608);
        }

        [Test]
        public void ParsedFavoritesCount()
        {
            _timeline.Tweets.First().FavoriteCount.Should().Be(12);
        }

        [Test]
        public void ParsedFavorited()
        {
            _timeline.Tweets.First().Favorited.Should().BeTrue();
        }

        [Test]
        public void ParsedRetweetCount()
        {
            _timeline.Tweets.First().RetweetCount.Should().Be(121);
        }

        public void ParsedRetweeted()
        {
            _timeline.Tweets.First().Retweeted.Should().BeTrue();
        }
    }
}
