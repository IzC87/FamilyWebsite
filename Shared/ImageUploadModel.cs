using System;
using System.Collections.Generic;
using System.Text;

namespace Medieval.Shared
{
    public class ImageUploadModel
    {
        public List<ImageData> Images { get; set; }
    }

    public class ImageData
    {
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public DateTime Date { get; set; }
        public long Size { get; set; }
    }
}