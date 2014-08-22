using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DEG.ServiceCore.Helpers;
using DEG.Vimeo.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Vimeo.Tests
{
    [TestFixture]
    public class AlbumVideosParsingTests
    {
        private readonly IEnumerable<Video> _results;

        public AlbumVideosParsingTests()
        {
            var file = File.OpenText(@".\Data\album-videos.json");

            _results = JsonHelper.Parse<IEnumerable<Video>>(file.ReadToEnd());             
        }

        [Test]
        public void CanParseAlbumVideos()
        {
            _results.Should().NotBeEmpty();
        }
        [Test]
        public void CanParseVideoId()
        {
            _results.First().Id.Should().NotBeNullOrEmpty();
        }
        [Test]
        public void CanParseVideoUploadDate()
        {
            _results.First().UploadDate.Should().Be(new DateTime(2014,06,03,12,40,30));
        }
    }
}
