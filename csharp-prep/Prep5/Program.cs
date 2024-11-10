using System;
using System.Net;

class Program {
    static void Main(string[] args) {
        display_welcome();
        string name = prompt_user_name();
        int number = prompt_user_number();
        number = square_number(number);
        display_result(name, number);
    }

    static void display_welcome() { Console.WriteLine("Welcome to the program!"); }

    static string prompt_user_name() {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }

    static int prompt_user_number() {
        Console.Write("What is your favorite number? ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int square_number(int number) { return number * number; }

    static void display_result(string name, int number) { Console.WriteLine($"{name}, the square of your number is {number}"); }
}