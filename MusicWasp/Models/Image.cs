using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int Width_px { get; set; }
        public int Height_px { get; set; }
        public int FileSize_Bytes { get; set; }
        public DateOnly UploadDate { get; set; }

        public Image()
        {
            
        }

        public void AddImage(string filePath)
        {

        }

        public void RemoveImage()
        {

        }

        public bool IsFileTooBig()
        {
            return false;
        }

        public override string ToString()
        {
            return "This is an image";
        }
    }
}
