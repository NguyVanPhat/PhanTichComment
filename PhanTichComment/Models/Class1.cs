using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;



namespace PhanTichComment.Models
{
    public class Class1
    {
        static void Main(string[] args)
        {
            String text = "It is raining today in Seattle";

            AmazonComprehendClient comprehendClient = new AmazonComprehendClient(Amazon.RegionEndpoint.USWest2);

            // Call DetectKeyPhrases API
            Console.WriteLine("Calling DetectSentiment");
            DetectSentimentRequest detectSentimentRequest = new DetectSentimentRequest()
            {
                Text = text,
                LanguageCode = "en"
            };
            DetectSentimentResponse detectSentimentResponse = comprehendClient.DetectSentiment(detectSentimentRequest);
            Console.WriteLine(detectSentimentResponse.Sentiment);
            Console.WriteLine("Done");
        }
    }
}