public class Scripture
{
    public Reference _reference { get; set; }
    public List<Word> _verse { get; set; }
    private List<Word> _shuffledVerse;
    private int _shuffleIndex = 0;

    public Scripture(string book, int chapter, int verseStart, int verseEnd, string verse)
    {
        _reference = new Reference(book, chapter, verseStart, verseEnd);
        _verse = [];

        string[] words = verse.Split([' ', '\n', '\t', '\r'], StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            _verse.Add(new Word(word));
        }

        Random rand = new();
        _shuffledVerse = [.. _verse];
        _shuffledVerse.RemoveAll(word => int.TryParse(word._text, out _));
        for (int i = _shuffledVerse.Count - 1; i >= 0; i--)
        {
            int j = rand.Next(i + 1);
            (_shuffledVerse[j], _shuffledVerse[i]) = (_shuffledVerse[i], _shuffledVerse[j]);
        }
    }

    public void DisplayVerse()
    {
        Console.Clear();
        _reference.DisplayReference();
        foreach (var word in _verse)
        {
            if (int.TryParse(word._text, out _))
            {
                Console.Write($"\n{word._text} ");
            }
            else
            {
                Console.Write(word._text + " ");
            }
        }
    }

    public bool HideRandomWord()
    {
        _shuffledVerse[_shuffleIndex].Hide();
        _shuffleIndex++;
        if (_shuffleIndex == _shuffledVerse.Count)
        {
            return true;
        }
        return false;
    }
}