using System.IO;
using System.Linq;
using DEG.Service.Core.Helpers;
using DEG.Twitter.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Twitter.Tests
{
    [TestFixture]
    public class SearchParsingTests
    {
        private readonly SearchResults _results;

        public SearchParsingTests()
        {
            var file = File.OpenText(@".\Data\TwitterTestSearchJson.json");

            _results = JsonHelper.Parse<SearchResults>(file.ReadToEnd());
        }

        [Test]
        public void ParsedBothTweets()
        {
            _results.Tweets.Should().HaveCount(4);
        }

        [Test]
        public void ParsedId()
        {
            _results.Tweets.First().Id.Should().Be(250075927172759552);
        }

        [Test]
        public void ParsedFavorited()
        {
            _results.Tweets.First().Favorited.Should().BeFalse();
        }

        [Test]
        public void ParsedCount()
        {
            _results.Metadata.Count.Should().Be(4);
        }

        public void ParsedQuery()
        {
            _results.Metadata.Query.Should().Be("%23freebandnames");
        }
    }
}
