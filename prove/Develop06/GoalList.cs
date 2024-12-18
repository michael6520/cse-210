class GoalList
{
    private List<Goal> _goals = [];

    public void DisplayGoals()
    {
        Console.Clear();

        int i = 1;
        foreach (Goal goal in _goals)
        {
            goal.DisplayGoal(i);
            i++;
        }
    }
    
    public void AddGoal()
    {
        Console.Clear();
        
        int input;

        while (true)
        {
            Console.WriteLine("What type of goal would you like to add?\n1. Simple\n2. Eternal\n3. Checklist");
            if (!int.TryParse(Console.ReadLine(), out input) || !(input >= 1 && input <= 3))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }
            break;
        }

        switch(input)
        {
            case 1:
                _goals.Add(new SimpleGoal());
                _goals.Last().CreateGoal();
                break;
            case 2:
                _goals.Add(new EternalGoal());
                _goals.Last().CreateGoal();
                break;
            case 3:
                _goals.Add(new ChecklistGoal());
                _goals.Last().CreateGoal();
                break;
        }
    }

    public int CompleteGoal(int i)
    {
        return _goals[i].CompleteGoal();
    }
}