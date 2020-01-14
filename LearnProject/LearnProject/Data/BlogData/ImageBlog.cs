using System;

namespace LearnProject.Data.BlogData
{
    public class ImageBlog
    {
        public ImageBlog()
        {
            UploadTime = DateTime.Now;
        }
        public int ImageBlogId { get; set; }
        public byte[] DataBytes { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
