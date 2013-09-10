using System.Configuration;
using DEG.Service.Core.Authentication;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Service.Core.Tests
{
    [TestFixture]
    [Category("Integration")]
    public class ApplicationOnlyAuthTests
    {
        [TestCase("twitterConsumerKey", "twitterConsumerSecret", "https://api.twitter.com/oauth2/token", TestName = "CanRetrieveTwitterBearerToken")]
        public void CanRetrieveBearerTokens(string keyConfigId, string secretConfigId, string authTokenUrl)
        {
            var consumerKey = ConfigurationManager.AppSettings[keyConfigId];
            var consumerSecret = ConfigurationManager.AppSettings[secretConfigId];

            if (string.IsNullOrEmpty(consumerKey))
                Assert.Inconclusive("You must set the consumer key for integration tests to run.");
            if (string.IsNullOrEmpty(consumerSecret))
                Assert.Inconclusive("You must set the consumer secret for integration tests to run.");

            var auth = new BearerTokenAuthWrapper(consumerKey, consumerSecret, authTokenUrl);
            auth.GetBearerToken().Should().NotBeNullOrEmpty();
        }

        private class BearerTokenAuthWrapper : ApplicationOnlyAuth
        {
            public BearerTokenAuthWrapper(string consumerKey, string consumerSecret, string authTokenUrl) 
                : base(consumerKey, consumerSecret, authTokenUrl)
            {
            }

            public string GetBearerToken()
            {
                return RetrieveBearerToken();
            }
        }
    }
}
