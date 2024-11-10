using System;

class Program {
    static void Main(string[] args) {
        while (true) {
            Console.Write("Enter the numeric grade (0-100): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int grade) && grade >= 0 && grade <= 100) {
                string letter_grade = grade >= 90 ? "A" :
                                      grade >= 80 ? "B" :
                                      grade >= 70 ? "C" :
                                      grade >= 60 ? "D" : "F";

                int grade_mod = grade % 10;
                if (grade == 100) grade_mod = 5; // So with 100% grade it doesn't output A-

                if (grade_mod >= 7) {
                    if (letter_grade == "A" || letter_grade == "F") { Console.WriteLine($"The letter grade is: {letter_grade}"); }
                    else Console.WriteLine($"The letter grade is: {letter_grade}+");
                }
                else if (grade_mod <= 3) {
                    if (letter_grade == "F") Console.WriteLine("The letter grade is: F");
                    else Console.WriteLine($"The letter grade is: {letter_grade}-");
                }
                else Console.WriteLine($"The letter grade is: {letter_grade}");
                break;
            }
            else {
                Console.WriteLine("Invalid input! Enter a number between 0 and 100.");
                continue;
            }            
        }
    }
}