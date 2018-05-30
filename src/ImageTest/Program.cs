using CaptchaGen;
using CodeCarvings.Piczard;
using CodeCarvings.Piczard.Filters.Watermarks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MemoryStream ms = ImageFactory.GenerateImage("a1c4",50,100,12,5))
            using (FileStream fs = File.OpenWrite(@"E:\Personal\pic\marriage\0112\0112\gen.jpg"))
            {
                ms.CopyTo(fs);
            }
                //ImageWatermark imgWatermark = new ImageWatermark(@"E:\Personal\pic\marriage\0112\0112\77.jpg");//水印图片路径配置
                //imgWatermark.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;//水印位置
                //imgWatermark.Alpha = 50;//透明度，需要水印图片是背景透明的 png 图片
                //ImageProcessingJob job = new ImageProcessingJob();
                //job.Filters.Add(imgWatermark);//添加水印
                ////job.Filters.Add(new FixedResizeConstraint(600, 600));//限制图片的大小，避免生成大图。如果想原图大小处理，就不用加这个 Filter
                //job.SaveProcessedImageToFileSystem(@"E:\Personal\pic\marriage\0112\0112\5201314.jpg", @"E:\Personal\pic\marriage\0112\0112\778.jpg");

                //ImageProcessingJob job = new ImageProcessingJob();
                //job.Filters.Add(new FixedResizeConstraint(200, 200));
                //job.SaveProcessedImageToFileSystem(@"E:\Personal\pic\marriage\0112\0112\7.jpg", @"E:\Personal\pic\marriage\0112\0112\77.jpg");
                Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
