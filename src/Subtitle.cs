namespace SubtitleSearcher
{
    public class Subtitle 
    {
        public int Sequence { get; private set; }
        public SubtitleTime Begin { get; private set; }
        public SubtitleTime End { get; private set; }
        public string Text { get; private set; }

        public string MasterTimeStamp { get; private set; }

        public Subtitle(int id, int startHours, int startMinutes, int startSeconds, int startMilliseconds,
                        int endHours, int endMinutes, int endSeconds, int endMilliseconds, string text)
        {
            this.Sequence = id;
            this.Begin = new SubtitleTime(startHours, startMinutes, startSeconds, startMilliseconds);
            this.End = new SubtitleTime(endHours, endMinutes, endSeconds, endMilliseconds);
            this.Text = text;

            this.MasterTimeStamp = string.Format("{0} --> {1}", Begin.TimeStamp, End.TimeStamp);
        }

        public string PrintSubtitle() 
        {
            return string.Format("{0}\n{1}\n{2}\n", Sequence, MasterTimeStamp, Text);
        }
    }
}