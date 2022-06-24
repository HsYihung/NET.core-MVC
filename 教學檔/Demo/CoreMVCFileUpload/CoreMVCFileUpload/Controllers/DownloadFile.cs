using System;
using System.ComponentModel.DataAnnotations;

namespace CoreMVCFileUpload.Controllers
{
    public class DownloadFile
    {
        [Display(Name = "編號")]
        public int ID { get; set; }

        [Display(Name = "檔案名稱")]
        public string FileName { get; set; }

        [Display(Name = "檔案大小")]
        public long FileSize { get; set; }

        [Display(Name = "上傳日期")]
        public DateTime CreationTime { get; set; }

    }
}