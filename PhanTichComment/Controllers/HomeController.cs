using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace PhanTichComment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                return View();
        }

        public string PhanTich(string tenomment)
        {
            string text = tenomment;

            AmazonComprehendClient comprehendClient = new AmazonComprehendClient(Amazon.RegionEndpoint.USWest2);

            // Call DetectKeyPhrases API
            //Console.WriteLine("Calling DetectSentiment");
            DetectSentimentRequest detectSentimentRequest = new DetectSentimentRequest()
            {
                Text = text,
                LanguageCode = "en"
            };
            DetectSentimentResponse detectSentimentResponse = comprehendClient.DetectSentiment(detectSentimentRequest);
            return detectSentimentResponse.Sentiment;
            //Console.WriteLine("Done");
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var tencmt = collection["tenComment"];
            if (String.IsNullOrEmpty(tencmt))
            {
                //ViewData["Loi1"] = "Bạn phải nhập tên file";
                ViewData["Loi1"] = "";
            }
            else
            {
                //fileName = tenfile;
                Session["PTComment"] = PhanTich(tencmt);
               /*It is raining today in Seattle*/
            }
            return View();
        }
    }
}