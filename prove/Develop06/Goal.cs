abstract class Goal()
{
    protected string _content;
    protected int _points;
    protected bool _completed = false;
    
    public abstract void CreateGoal();

    public abstract int CompleteGoal();

    public abstract void DisplayGoal(int i);
}

class SimpleGoal : Goal
{
    public override void CreateGoal()
    {   
        Console.WriteLine("What is the goal you would like to complete?");
        _content = Console.ReadLine();

        Console.WriteLine("How many points is this goal worth?");
        _points = int.Parse(Console.ReadLine());
    }

    public override int CompleteGoal()
    {
        _completed = true;
        return _points;
    }

    public override void DisplayGoal(int i)
    {
        if (_completed)
        {
            Console.WriteLine($"{i}. [X] {_content}\n");
        }
        else
        {
            Console.WriteLine($"{i}. [ ] {_content}\n");
        }
    }
}

class EternalGoal : Goal
{
    public override void CreateGoal()
    {
        Console.WriteLine("What is the goal you would like to complete?");
        _content = Console.ReadLine();

        Console.WriteLine("How many points is this goal worth?");
        _points = int.Parse(Console.ReadLine());
    }

    public override int CompleteGoal()
    {
        return _points;
    }

    public override void DisplayGoal(int i)
    {
        Console.WriteLine($"{i}. {_content}\n");
    }
}

class ChecklistGoal : Goal
{
    private int _length;
    private int _checklistPoints;
    private int _amountCompleted = 0;

    public override void CreateGoal()
    {
        Console.WriteLine("What is the goal you would like to complete?");
        _content = Console.ReadLine();

        Console.WriteLine("How many times does it have to be completed?");
        _length = int.Parse(Console.ReadLine());

        Console.WriteLine("How many points do you get each time you complete a single entry on the list?");
        _checklistPoints = int.Parse(Console.ReadLine());

        Console.WriteLine("How many points do you get once all tasks are completed?");
        _points = int.Parse(Console.ReadLine());
    }

    public override int CompleteGoal()
    {
        _amountCompleted++;
        if (_amountCompleted == _length)
        {
            _completed = true;
            return _points;
        }
        return _checklistPoints;
    }

    public override void DisplayGoal(int i)
    {
        Console.WriteLine($"{i}. [{_amountCompleted}/{_length}] {_content}\n");
    }
}