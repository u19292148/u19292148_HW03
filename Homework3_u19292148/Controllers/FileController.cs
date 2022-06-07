using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Homework3_u19292148.Models;

namespace Homework3_u19292148.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public ActionResult File()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Document/"));

            List<FileModel> files = new List<FileModel>();

            foreach(string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Document/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            
            string path = Server.MapPath("~/Media/Document/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("File");
        }


    }
}