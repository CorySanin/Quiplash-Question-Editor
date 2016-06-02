namespace Quiplash_Question_Editor
{
    static class unicodeInterface
    {
        /// <summary>
        /// replaces punctuation with unicode stuff. I have no idea if this works.
        /// </summary>
        /// <param name="s">String to replace punctuation of</param>
        /// <returns>String with replaced punctuation</returns>
        public static string replacePunctuation(string s)
        {
            return s.Replace("'", "\u2019").Replace("’", "\u2019").Replace("…", "\u2026");
        }
    }
}
