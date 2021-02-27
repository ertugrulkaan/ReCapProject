using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private const string filePath = "C:\\Users\\Ertuğrul\\Desktop\\YoutubeEgitim\\ReCapProject\\Images\\CarImages\\";
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, filePath + result);
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(filePath + path);
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(filePath + result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(filePath + sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            var newPath = Guid.NewGuid().ToString() + "_" +DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + fileExtension;
            string result = $@"{newPath}";
            return result;
        }
    }
}
