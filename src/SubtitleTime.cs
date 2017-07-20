using System;

namespace SubtitleSearcher 
{
    public class SubtitleTime 
    {
        public string TimeStamp { get; private set; }
        public int Hours { get; private set; } = 00;
        public int Minutes { get; private set; } = 00;
        public int Seconds { get; private set; } = 00;
        public int Milliseconds { get; private set; } = 000;

        public SubtitleTime(int Hours, int Minutes, int Seconds, int Milliseconds)
        {
            this.Hours = Hours;
            this.Minutes = Minutes;
            this.Seconds = Seconds;
            this.Milliseconds = Milliseconds;
            this.TimeStamp = ConvertToTimeStamp();
        }

        private string ConvertToTimeStamp()
        {
            string timestamp = null;

            string h = "00";
            string m = "00";
            string s = "00";
            string ms = "000";

            /**
                Conversion Checkers
            */
            // Reject invalid integer values
            if  (   this.Hours > 60 && this.Hours < 0 ||
                    this.Minutes > 60 && this.Minutes < 0 ||
                    this.Seconds > 60 && this.Seconds < 0 ||
                    this.Milliseconds > 999 && this.Milliseconds < 000
                ) return timestamp;

            // Convert anomalous integer values to double/triple digit representation
            h = this.Hours.ToString("00");
            m = this.Minutes.ToString("00");
            s = this.Seconds.ToString("00");
            ms = this.Milliseconds.ToString("000");

            timestamp = string.Format("{0}:{1}:{2},{3}", h, m, s, ms);

            return timestamp;
        }
    }
}