using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Scripture
    {
        private Reference _reference; // Scripture reference
        private List<Word> _words;    // List of words in the scripture

        // Constructor to initialize scripture with reference and text
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            SplitText(text);
        }

        // Split text into words and create Word objects
        private void SplitText(string text)
        {
            _words = new List<Word>();
            string[] splitWords = text.Split(' ');
            foreach (var word in splitWords)
            {
                _words.Add(new Word(word));
            }
        }

        // Display the scripture with hidden words represented as dashes
        public string Display()
        {
            string result = $"{_reference.Display()}\n";
            foreach (var word in _words)
            {
                result += word.Display() + " ";
            }
            return result.Trim();
        }

        // Hide random words in the scripture
        public void HideRandomWords()
        {
            Random random = new Random();
            int countToHide = Math.Max(1, _words.Count / 4);

            for (int i = 0; i < countToHide; i++)
            {
                int index = random.Next(_words.Count);
                _words[index].Hide();
            }
        }

        // Check if all words are hidden
        public bool AllWordsHidden()
        {
            foreach (var word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }

        // Get the reference of the scripture
        public string GetReference()
        {
            return _reference.Display();
        }

        // Get the text of the scripture
        public string GetText()
        {
            List<string> wordTexts = new List<string>();
            foreach (var word in _words)
            {
                wordTexts.Add(word.GetText());
            }
            return string.Join(" ", wordTexts);
        }
    }
}
