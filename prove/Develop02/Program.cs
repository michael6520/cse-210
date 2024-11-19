using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using Microsoft.VisualBasic;

class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();
        bool stop = true;
        while (stop) {
            Console.Write("Please select one of the following choices:\n" + 
                          "1. Write\n" +
                          "2. Display\n" +
                          "3. Save\n" +
                          "4. Load\n" +
                          "5. Quit\n" +
                          "What would you like to do? ");
            int input = int.Parse(Console.ReadLine());

            switch (input) {
                case 1: // Write
                    string prompt = GetPrompt();
                    Console.WriteLine(prompt);
                    string content = Console.ReadLine();

                    Entry entry = new Entry(prompt, content);
                    journal.AddEntry(entry);

                    break;
                case 2: // Display
                    journal.DisplayEntries();

                    break;
                case 3:
                    Console.WriteLine("What would you like the save file to be named? ");
                    string write_filename = Console.ReadLine();

                    journal.SaveJournalToCsv(write_filename);

                    break;
                case 4:
                    Console.WriteLine("What is the name of the file you would like to load from? ");
                    string read_filename = Console.ReadLine();

                    journal.LoadJournalFromCsv(read_filename);

                    break;
                case 5:
                    stop = false;
                    
                    break;
                default:
                    Console.WriteLine("Enter a number from 1 to 5.");
                    break;
            }
        }
    }

    static string GetPrompt() {
        List<string> prompts = ["What was the highlight of your day?",
                                "Did you face any challenges today?",
                                "What did you learn today?",
                                "What was an interesting thing that happened today?",
                                "What do you wish you could do differently?"];

        Random rand = new Random();
        int random_index = rand.Next (prompts.Count);
        string random_prompt = prompts[random_index];

        return random_prompt;
    }
}