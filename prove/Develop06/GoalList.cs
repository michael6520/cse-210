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

    public void Save(string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (Goal goal in _goals)
            {
                sw.WriteLine(goal.Save());
            }
        }
    }

    public void Load(string filePath)
    {
        StreamReader sr = new(filePath);
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            string[] fields = ParseCsvLine(line);

            string goalType = fields[0];

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal());
                    _goals.Last().Load(fields[1], int.Parse(fields[2]), bool.Parse(fields[3]));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal());
                    _goals.Last().Load(fields[1], int.Parse(fields[2]), bool.Parse(fields[3]));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new EternalGoal());
                    _goals.Last().Load(fields[1], int.Parse(fields[2]), bool.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]), int.Parse(fields[6]));
                    break;
            }
        }
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> fields = [];
        bool inQuotes = false;
        string currentField = "";

        foreach (char c in line)
        {
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }

        if (!string.IsNullOrEmpty(currentField))
        {
            fields.Add(currentField);
        }

        return [..fields];
    }
}