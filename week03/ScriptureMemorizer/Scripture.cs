using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words = new List<Word>();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            string[] wordArray = text.Split(' ');
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            int wordsHidden = 0;

            while (wordsHidden < numberToHide && !IsCompletelyHidden())
            {
                int index = random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    wordsHidden++;
                }
            }
        }

        public string GetDisplayText()
        {
            string displayText = $"{_reference.GetDisplayText()}\n\n";
            foreach (Word word in _words)
            {
                displayText += word.GetDisplayText() + " ";
            }
            return displayText;
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                    return false;
            }
            return true;
        }
    }
}
