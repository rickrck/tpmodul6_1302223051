using Console = System.Console;
using Random = System.Random;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul6_1302223051
{
    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Ricky Renaldi");
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
            this.playCount += playCount;
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("Video Details");
            Console.WriteLine($"ID \t\t: {id} \nTitle \t\t: {title} \nPlay Count \t: {playCount} \n");
        }
    }
}

