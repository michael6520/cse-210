public class Word(string word)
{
    public string _text { get; set; } = word;

    public void Hide()
    {
        _text = new string('_', _text.Length);
    }
}