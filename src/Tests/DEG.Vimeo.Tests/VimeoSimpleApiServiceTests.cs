using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEG.Vimeo.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Vimeo.Tests
{
    [TestFixture]
    public class VimeoSimpleApiServiceTests
    {
        private readonly VimeoSimpleApiService _service;
        private IEnumerable<Video> _results;

        public VimeoSimpleApiServiceTests()
        {
            _service = new VimeoSimpleApiService();
            _results = _service.GetAlbumVideos("2339218");
        }

        [Test]
        public void CanGetVideos()
        {
            _results.Should().NotBeEmpty();
        }
    }
}
