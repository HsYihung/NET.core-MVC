using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CoreMVCFileUpload.Controllers
{
    public class FilesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string WebRootPath = _webHostEnvironment.WebRootPath;           //wwwroot
            string ProjectPath = _webHostEnvironment.ContentRootPath;       //Project Directory

            DirectoryInfo di = new DirectoryInfo(Path.Combine(WebRootPath, "Uploads"));
            var query = (from f in di.EnumerateFiles("*.*")
                         select f).Select((file, index) =>
                            new DownloadFile
                            {
                                ID = index + 1,
                                FileName = file.Name,
                                FileSize = file.Length,
                                CreationTime = file.CreationTime
                            });
            return View(query);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToActionResult> Upload(IEnumerable<IFormFile> files)
        {
            if (files.First() != null)
            {
                foreach (IFormFile file in files)
                {
                    string WebRootPath = _webHostEnvironment.WebRootPath;           //wwwroot
                    string ProjectPath = _webHostEnvironment.ContentRootPath;       //Project Directory

                    string SourceFilename = Path.GetFileName(file.FileName);
                    string TargetFilename = Path.Combine(WebRootPath, "Uploads", SourceFilename);

                    using (FileStream stream = new FileStream(TargetFilename, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public FileResult Download(string FileName)
        {
            string WebRootPath = _webHostEnvironment.WebRootPath;           //wwwroot
            string ProjectPath = _webHostEnvironment.ContentRootPath;       //Project Directory

            string DownloadFilename = Path.Combine(WebRootPath, "Uploads", FileName);
            ContentDisposition cd = new ContentDisposition
            {
                FileName = FileName,     // 設定下載檔案名稱
                // Inline= false,        // 禁止直接顯示檔案內容
            };
            Response.Headers.Append("Content-Disposition", cd.ToString());
            var fs = System.IO.File.OpenRead(DownloadFilename);
            return File(fs, MediaTypeNames.Application.Octet);
        }

        public FileResult DownloadAll()
        {
            string WebRootPath = _webHostEnvironment.WebRootPath;           //wwwroot
            string ProjectPath = _webHostEnvironment.ContentRootPath;       //Project Directory

            string ZipFilename = "All.zip";
            string UploadsFolder = Path.Combine(WebRootPath, "Uploads");
            string DownloadFileName = Path.Combine(WebRootPath, ZipFilename);
            if (System.IO.File.Exists(DownloadFileName))
            {
                System.IO.File.Delete(DownloadFileName);
            }
            ZipFile.CreateFromDirectory(UploadsFolder, DownloadFileName);
            ContentDisposition cd = new ContentDisposition
            {
                FileName = ZipFilename,
                Inline = false,             //禁止直接顥示
            };
            Response.Headers.Append("Content-Disposition", cd.ToString());
            var fs = System.IO.File.OpenRead(DownloadFileName);
            return File(fs, MediaTypeNames.Application.Octet);
        }

    }
}
