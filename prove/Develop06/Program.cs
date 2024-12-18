class Program
{
    static void Main(string[] args)
    {
        GoalList goalList = new();
        
        int points = 0;
        int menuInput = -1;
        int goalInput;
        
        Console.Clear();
        while (menuInput != 4)
        {
            while (true)
            {
                Console.WriteLine($"1. Add a goal.\n2. List all goals.\n3. Complete a goal.\n4. Exit\n\nPoints: {points}\n");
                if (!int.TryParse(Console.ReadLine(), out menuInput) || !(menuInput >= 1 && menuInput <= 4))
                {
                    Console.WriteLine("Enter a valid number.");
                    continue;
                }
                break;
            }

            switch(menuInput)
            {
                case 1:
                    goalList.AddGoal();
                    break;
                case 2:
                    goalList.DisplayGoals();
                    break;
                case 3:
                    goalList.DisplayGoals();
                    Console.WriteLine("Which goal have you completed?");
                    goalInput = int.Parse(Console.ReadLine());
                    goalInput--;
                    points += goalList.CompleteGoal(goalInput);
                    break;
            }
        }
    }
}