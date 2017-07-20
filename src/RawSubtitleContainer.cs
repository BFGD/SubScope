using System.Collections.Generic;

namespace SubtitleSearcher 
{
    public class RawSubtitleContainer
    {
        public string Sequence { get; set; }
        public string TimeStamp { get; set; }
        public List<string> TextLines { get; set; } = new List<string>();
    }
}