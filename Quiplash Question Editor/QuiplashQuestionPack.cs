using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiplash_Question_Editor
{
    public class items
    {
        /// <summary>
        /// Prompt
        /// </summary>
        public string prompt { get; set; }

        /// <summary>
        /// audio filename
        /// </summary>
        public string audio { get; set; }

        public string jokekeys { get; set; }

        public string jokeresponse { get; set; }

        public string jokeaudio { get; set; }

        public bool explicitq {get;set;}
    }
    class QuiplashQuestionPack
    {
        public List<items> items { get; set; }
    }
}
