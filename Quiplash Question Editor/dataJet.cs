using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiplash_Question_Editor
{
    public class Field
    {
        /// <summary>
        /// type (B for bool, S for string, and A for audio)
        /// </summary>
        public string t { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string v { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string n { get; set; }
    }

    /// <summary>
    /// The root class
    /// </summary>
    public class dataJet
    {
        public List<Field> fields { get; set; }
    }
}
