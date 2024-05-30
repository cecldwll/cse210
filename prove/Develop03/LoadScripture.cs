using System;

namespace ScriptureMemorizer
{
    class LoadScripture
    {
        // Method to load scripture using user input
        public Scripture Load(GetScripture getScripture)
        {
            string reference = getScripture.GetReferenceFromUser();
            string text = getScripture.GetTextFromUser();
            return new Scripture(new Reference(reference), text);
        }
    }
}
