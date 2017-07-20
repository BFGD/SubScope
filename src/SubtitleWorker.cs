using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace SubtitleSearcher 
{
    /// <summary>
    /// The purpose of the SubtitleWorker is to making extracting of subtitle sections possible
    /// by seperating the sections into RawSubtitleContainers. RawSubtitleContainers provide
    /// methods that allow further extraction of the relevant information.
    /// </summary>
    public class SubtitleWorker 
    {
        private string[] _subLines;
        private string _path;

        /// <summary>
        /// Extracts a list of raw subtitle sections.
        /// </summary>
        /// <returns>List of raw subtitle containers.</returns>
        public List<RawSubtitleContainer> ExtractRaw(string path)
        {
            _path = path;

            var subtitles = new List<RawSubtitleContainer>();

            if(!File.Exists(_path)) return subtitles;

            _subLines = File.ReadAllLines(_path);
            subtitles = GroupSubtitles();

            return subtitles;
        }

        /// <summary>
        /// Iterates through all the lines in the subtitle file and delegates the 
        /// appropriate subtitle element. Relevant subtitles will be grouped up and
        /// any unnecessary information left out.
        /// </summary>
        /// <param name="lines">Individual line strings extracted from a subtitle file</param>
        /// <returns>A list of raw subtitles in string format</returns>
        private List<RawSubtitleContainer> GroupSubtitles() 
        {
            var subtitles = new List<RawSubtitleContainer>();

            int currentIndex = 0;

            currentIndex = GetSubtitleSectionStart(currentIndex);

            // Each iteration of this while loop begins at the start of a subtitle section
            while(currentIndex <= _subLines.Length-1)
            {
                var rawSubtitle = new RawSubtitleContainer();

                // Get sequence and timestamp information and increment currentIndex twice
                rawSubtitle.Sequence = _subLines[currentIndex++];
                rawSubtitle.TimeStamp = _subLines[currentIndex++];

                // While there is text, add to the the list of textlines in the RawSubtitleContainer
                // and increment the currentIndex for the amount of lines found.
                while(!string.IsNullOrWhiteSpace(_subLines[currentIndex]))
                {
                    rawSubtitle.TextLines.Add(_subLines[currentIndex]);

                    currentIndex++;
                    if(currentIndex == _subLines.Length) break;
                }

                subtitles.Add(rawSubtitle);

                currentIndex = GetSubtitleSectionStart(currentIndex);
            }
            
            return subtitles;
        }

        /** 
        * Helpers 
        */
        /// <summary>
        /// Places index counter at the start of a subtitle section.
        /// </summary>
        /// <param name="currentIndex">Current index being iterated</param>
        /// <param name="lines"></param>
        /// <returns></returns>
        private int GetSubtitleSectionStart(int currentIndex)
        {
            int newIndex = currentIndex;

            // If the current index is out of the array range, return the max array range to avoid
            // OutOfRange exceptions.
            if(currentIndex >= _subLines.Length)
            {
                return _subLines.Length;
            }
            
            // Iterate through lines where there is no text in order to find a start to a subtitle section.
            while(string.IsNullOrWhiteSpace(_subLines[newIndex]))
            {
                newIndex++;
            }

            return newIndex;
        }
    }
}