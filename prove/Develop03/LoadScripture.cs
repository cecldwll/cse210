using System;

class LoadScripture
{
    public Scripture Load(GetScripture getScripture)
    {
        string reference = getScripture.GetReferenceFromUser();
        string text = getScripture.GetTextFromUser();
        return new Scripture(reference, text);
    }
}
