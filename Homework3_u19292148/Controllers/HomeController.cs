using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Homework3_u19292148.Models;
using System.ComponentModel.DataAnnotations;

namespace Homework3_u19292148.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

       
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            var rad1 = Request.Form["file"];
            var rad2 = Request.Form["image"];
            var rad3 = Request.Form["video"];
 
            if (files != null && files.ContentLength > 0)
            {

                if (rad1 == "file")
                {
                    var fileName = Path.GetFileName(files.FileName);

                    var path = Path.Combine(Server.MapPath("~/Media/Document/"), fileName);

                    files.SaveAs(path);
                }
                else if (rad2 == "image")
                {
                    var fileName = Path.GetFileName(files.FileName);

                    var path = Path.Combine(Server.MapPath("~/Media/Image"), fileName);

                    files.SaveAs(path);
                }
                else if (rad3 == "video")
                {
                    var fileName = Path.GetFileName(files.FileName);

                    var path = Path.Combine(Server.MapPath("~/Media/Video"), fileName);

                    files.SaveAs(path);


                }



            }
            return RedirectToAction("Index");



        }

       
        public ActionResult About()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/About_Image/Images/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);

        }

        
    }
}