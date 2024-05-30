using System;

namespace ScriptureMemorizer
{
    class Word
    {
        private string _text;  // The actual word text
        private bool _hidden;  // Flag indicating whether the word is hidden

        // Constructor to initialize word with text
        public Word(string text)
        {
            _text = text;
            _hidden = false;
        }

        // Method to hide the word
        public void Hide()
        {
            _hidden = true;
        }

        // Display the word (hidden words are shown as dashes)
        public string Display()
        {
            return _hidden ? new string('_', _text.Length) : _text;
        }

        // Check if the word is hidden
        public bool IsHidden()
        {
            return _hidden;
        }

        // Get the text of the word
        public string GetText()
        {
            return _text;
        }
    }
}
