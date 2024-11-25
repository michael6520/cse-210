// To exceed the requirements, I made it so the function that hides a random word never chooses the same word twice.

class Program
{
    static void Main(string[] args)
    {
        string book = "1 Nephi";
        int chapter = 2;
        int verseStart = 15;
        int verseEnd = 16;
        string verse = "15 And my father dwelt in a tent.";
        var scripture = new Scripture(book, chapter, verseStart, verseEnd, verse);
        bool quit = true;
        while (quit)
        {
            scripture.DisplayVerse();
            Console.WriteLine("\nType 'quit' to end the program, press enter to hide a random word.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                quit = false;
            }
            else if (scripture.HideRandomWord())
            {
                scripture.DisplayVerse();
                quit = false;
            }
        }
    }
}