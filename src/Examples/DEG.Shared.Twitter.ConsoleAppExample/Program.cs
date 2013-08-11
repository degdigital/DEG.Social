using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEG.Shared.Twitter.Authorization;

namespace DEG.Shared.Twitter.ConsoleAppExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            if (string.IsNullOrEmpty(consumerKey))
            {
                Console.Write("Enter the consumer key: ");
                consumerKey = Console.ReadLine();
            }

            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            if (string.IsNullOrEmpty(consumerSecret))
            {
                Console.Write("Enter the consumer secret: ");
                consumerSecret = Console.ReadLine();
            }

            Console.Write("Enter the desired screen name: ");
            var screenName = Console.ReadLine();

            Console.Write("Enter how many tweets to retrieve: ");
            var numberOfTweets = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Retrieving user timeline...");

            var auth = new ApplicationOnlyAuth(consumerKey, consumerSecret);
            var service = new TwitterService(auth);

            var timeline = service.GetUserTimeline(screenName, numberOfTweets);

            foreach (var tweet in timeline.Tweets)
            {
                Console.WriteLine();
                Console.WriteLine("{0:MM-dd-yyyy HH:mm:ss} : {1}", tweet.Created, tweet.Text);
                Console.WriteLine("Retweeted {0} time, favorited {1} times", tweet.RetweetCount.GetValueOrDefault(0),
                                  tweet.FavoriteCount.GetValueOrDefault(0));
            }

            Console.Write("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
