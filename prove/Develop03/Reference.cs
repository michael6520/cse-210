public class Reference(string book, int chapter, int verseStart, int verseEnd)
{
    public string _book { get; set; } = book;
    public int _chapter { get; set; } = chapter;
    public int _verseStart { get; set; } = verseStart;
    public int _verseEnd { get; set; } = verseEnd;

    public void DisplayReference()
    {
        if (_verseStart == _verseEnd)
        {
            Console.Write($"{_book} {_chapter}:{_verseStart}");
        }
        else
        {
            Console.Write($"{_book} {_chapter}:{_verseStart}-{_verseEnd}");
        }
    }
}