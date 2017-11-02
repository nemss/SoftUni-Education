using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Thea_The_Photographer
{
     public class Program
    {
        public static void Main(string[] args)
        {
            int pictures = int.Parse(Console.ReadLine());
            int filtarTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            long overallFilterTime = (long)pictures * filtarTime;
            long filteredPictures =(int)Math.Ceiling((double)pictures * filterFactor / 100);
            long overallUploadTime = filteredPictures * uploadTime;

            long time = overallFilterTime + overallUploadTime;

            TimeSpan timeSpan = TimeSpan.FromSeconds(time);

            Console.WriteLine("{0:d1}:{1:d2}:{2:d2}:{3:d2}",
                timeSpan.Days,
                timeSpan.Hours,
                timeSpan.Minutes,
                timeSpan.Seconds
                );

          
        }
    }
}
