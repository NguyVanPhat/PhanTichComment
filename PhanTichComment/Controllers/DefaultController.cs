using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhanTichComment.Models;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using System.Net;

namespace PhanTichComment.Controllers
{
    public class DefaultController : Controller
    {
        KetQuaPhanTichDataContext db = new KetQuaPhanTichDataContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var tenDuongDan = collection["tenDuongDan"];
            if (String.IsNullOrEmpty(tenDuongDan))
            {
                ViewData["Loi1"] = "";
            }
            else
            {
                Session["linkWeb"] = tenDuongDan;
            }
            return RedirectToAction("TaiBinhLuan", "Default");
        }
        public ActionResult TaiBinhLuan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaiBinhLuan(FormCollection collection)
        {
            var tenComment = collection["tenComment"];
            if (String.IsNullOrEmpty(tenComment))
            {
                ViewData["Loi1"] = "";
            }
            else
            {
                KetQuaPhanTich kq = new KetQuaPhanTich();
                kq.NoiDung = tenComment;
                string ketQuaPhanTich = PhanTich(tenComment);
                if(ketQuaPhanTich== "MIXED")
                {
                    kq.KetQua = "Vừa tích cực, vừa tiêu cực";
                }
                else if (ketQuaPhanTich == "POSITIVE")
                {
                    kq.KetQua = "Tích cực";
                }
                else if (ketQuaPhanTich == "NEUTRAL")
                {
                    kq.KetQua = "Trung lập";
                }
                else if (ketQuaPhanTich == "NEGATIVE")
                {
                    kq.KetQua = "Tiêu cực";
                }
                db.KetQuaPhanTiches.InsertOnSubmit(kq);
                db.SubmitChanges();
                return RedirectToAction("KetQua", "Default");
            }
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
        public ActionResult KetQua()
        {
            var ketQua = db.KetQuaPhanTiches.ToList(); 
            return View(ketQua);
        }

        // POST: QLTaiKhoan/Delete/5
        public ActionResult Delete(int Id)
        {
            KetQuaPhanTich kq = db.KetQuaPhanTiches.SingleOrDefault(n => n.Id == Id);
            db.KetQuaPhanTiches.DeleteOnSubmit(kq);
            db.SubmitChanges();
            return RedirectToAction("KetQua", "Default"); 
        }
        public ActionResult DeletaAll()
        {
            db.KetQuaPhanTiches.DeleteAllOnSubmit(db.KetQuaPhanTiches);
            db.SubmitChanges();
            return RedirectToAction("KetQua", "Default"); 
        }
    }
}