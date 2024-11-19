using System;

public class Entry {
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Content { get; set; }

    public Entry() { }
    
    public Entry(string prompt, string content) {
        Date = DateTime.Now;
        Prompt = prompt;
        Content = content;
    }

    public void DisplayEntry() {
        Console.WriteLine(Date.ToShortDateString());
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"- {Content}");
    }
}