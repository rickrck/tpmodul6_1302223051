using Console = System.Console;
using Random = System.Random;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace tpmodul6_1302223051
{
    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Ricky Renaldi");
            video.PrintVideoDetails();

            try
            {
                video.IncreasePlayCount(10000001);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ArgumentException: " + ex.Message);
            }

            for (int i = 0; i < 5; i++)
            {
                video.IncreasePlayCount(200000);
            }

            video.PrintVideoDetails();
        }
    }

    
    internal class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int playCount)
        {
            if (string.IsNullOrEmpty(title) || title.Length > 100)
            {
                throw new ArgumentException("Judul video memiliki panjang maksimal 100 karakter dan tidak berupa null.");
            }

            if (playCount < 0 || playCount > 10000000)
            {
                throw new ArgumentException("play count maksimal 10.000.000 per panggilan method-nya.");
            }

            try
            {
                checked
                {
                    this.playCount += playCount;
                }
            }
            catch (OverflowException pesan)
            {
                Console.WriteLine("Terjadi overflow : " + pesan.Message);
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("Video Details");
            Console.WriteLine($"ID \t\t: {id} \nTitle \t\t: {title} \nPlay Count \t: {playCount} \n");
        }
    }
}

