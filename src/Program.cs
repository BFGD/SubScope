using System;
using System.IO;
using System.Text;

namespace SubtitleSearcher
{
    class Program
    {
        public static void Main(string[] args) 
        {
            Subtitle sub = new Subtitle(565, 00, 46, 41, 599, 00, 46, 43, 840, "The Westerosi woman is pleased with them,");

            Console.WriteLine(sub.PrintSubtitle());

            SubtitleWorker ss = new SubtitleWorker(@"SRT_Files\Game of Thrones S03E01.srt");
            ss.ExtractRaw();
        }
    }
}
