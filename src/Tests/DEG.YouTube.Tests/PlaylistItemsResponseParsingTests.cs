using System.IO;
using DEG.ServiceCore.Helpers;
using DEG.YouTube.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.YouTube.Tests
{
    [TestFixture]
    public class PlaylistItemsResponseParsingTests
    {
        private readonly PlaylistItemsResults _results;

        public PlaylistItemsResponseParsingTests()
        {
            var file = File.OpenText(@".\Data\Response1.json");

            _results = JsonHelper.Parse<PlaylistItemsResults>(file.ReadToEnd());
        }

        [Test]
        public void ParsedCorrectNumberOfResponses()
        {
            _results.Items.Should().HaveCount(4);
        }
    }
}
