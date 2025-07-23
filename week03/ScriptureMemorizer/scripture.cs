using System;
using System.Collections.Generic;
using System.Linq; 

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random; 

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] rawWords = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string rawWord in rawWords)
        {
            _words.Add(new Word(rawWord));
        }
    }

    public void HideRandomWords(int countToHide)
    {
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

        if (unhiddenWords.Count == 0)
        {
            return;
        }

        for (int i = 0; i < countToHide; i++)
        {
            if (unhiddenWords.Count == 0)
                break; 

            int indexToHide = _random.Next(0, unhiddenWords.Count);
            unhiddenWords[indexToHide].Hide();

            unhiddenWords.RemoveAt(indexToHide);
        }
    }


    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}