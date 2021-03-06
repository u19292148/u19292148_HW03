using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework3_u19292148.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Homework3_u19292148.Controllers
{
    public class VideoController : Controller
    {
        public ActionResult Video()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Video/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName) 
        {
            string path = Server.MapPath("~/Media/Video/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Video/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Video");
        }
    }
}