using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiplash_Question_Editor
{

    public class Content
    {
        /// <summary>
        /// whether or not the question is explicit
        /// </summary>
        public bool x { get; set; }

        /// <summary>
        /// Question ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Prompt text
        /// </summary>
        public string prompt { get; set; }
    }

    public class questionJet
    {
        /// <summary>
        /// List of questions
        /// </summary>
        public List<Content> content { get; set; }

        /// <summary>
        /// Worthless
        /// </summary>
        public int episodeid { get; set; }
    }
}
