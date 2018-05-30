using CaptchaGen;
using CodeCarvings.Piczard;
using CodeCarvings.Piczard.Filters.Watermarks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Framework
{
    public class ImageManager
    {
        public void ResizeImage(int width,int height,string fromPath,string destPath )
        {
            ImageProcessingJob job = new ImageProcessingJob();
            job.Filters.Add(new FixedResizeConstraint(width, height));
            job.SaveProcessedImageToFileSystem(fromPath, destPath);
        }

        public void AddWaterMark(string fromPath, string destPath)
        {
            ImageWatermark imgWatermark = new ImageWatermark(@"E:\Personal\pic\marriage\0112\0112\77.jpg");//水印图片路径配置
            imgWatermark.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;//水印位置
            imgWatermark.Alpha = 50;//透明度，需要水印图片是背景透明的 png 图片
            ImageProcessingJob job = new ImageProcessingJob();
            job.Filters.Add(imgWatermark);//添加水印
            //job.Filters.Add(new FixedResizeConstraint(600, 600));//限制图片的大小，避免生成大图。如果想原图大小处理，就不用加这个 Filter
            job.SaveProcessedImageToFileSystem(fromPath, destPath);
        }

        public Stream GenerateValidImage(string validCode)
        {
            MemoryStream ms = ImageFactory.GenerateImage(validCode, 50, 100, 12, 5);
            return ms;
        }
    }
}
