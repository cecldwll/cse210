using System;

namespace ScriptureMemorizer
{
    class Reference
    {
        private string _referenceText;  // The reference text (e.g., John 3:16)

        // Constructor to initialize reference with text
        public Reference(string referenceText)
        {
            _referenceText = referenceText;
        }

        // Display the reference
        public string Display()
        {
            return _referenceText;
        }
    }
}
