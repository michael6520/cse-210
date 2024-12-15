using System;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

class Activity(string activity, string description)
{
    private string _activity = activity;
    private string _description = description;
    protected int _duration;
    protected int _elapsedTime;

    protected void Start()
    {
        Console.Clear();
        Console.WriteLine($"You are about to begin the {_activity}. {_description}\n");
        while (true)
        {
            Console.WriteLine("How long do you want the activity to be in seconds?");
            if (!int.TryParse(Console.ReadLine(), out _duration)) { continue; }
            break;
        }
    }

    protected async Task End()
    {
        Console.WriteLine("Well done, you completed the activity.");
        await Pause();
        Console.WriteLine($"You have completed the {_activity}, and you spent {_duration} seconds on it.");
        await Pause();
    }

    private static async Task Pause()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        var animationTask = ShowEllipsisAnimation(cts.Token);

        await Task.Delay(10000);

        cts.Cancel();
        await animationTask;
    }

    private static async Task ShowEllipsisAnimation(CancellationToken token)
    {
        int dotCount = 0;
        while (!token.IsCancellationRequested)
        {
            Console.Write(".");
            dotCount++;

            if (dotCount > 3)
            {
                Console.Write("\b\b\b   \b\b\b\b");
                dotCount = 0;
            }

            await Task.Delay(500);
        }
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity is meant to help you feel calm and relaxed by focussing on your breathing.") { }

    public async Task Run()
    {
        base.Start();
        await StartBreathingActivity();
        await base.End();
    }

    private async Task StartBreathingActivity()
    {
        _elapsedTime = 0;
        int cycleTime = 5;

        while (_elapsedTime < _duration)
        {
            await DisplayMessageWithCountdown("Breathe in...", cycleTime);
            if (_elapsedTime >= _duration) break;
            Console.Clear();

            await DisplayMessageWithCountdown("Breathe out...", cycleTime);
            Console.Clear();
        }
    }

    private async Task DisplayMessageWithCountdown(string message, int countdownTime)
    {
        Console.WriteLine(message);
        for (int i = countdownTime; i > 0; i--)
        {
            Console.Write($"{i}... ");
            await Task.Delay(1000);
            _elapsedTime++;
            if (_elapsedTime >= _duration)
            {
                return;
            }
            Console.Write("\b\b\b\b\b");
        }
        Console.WriteLine();
    }
}

class ReflectionActivity : Activity
{
    public ReflectionActivity()
        : base("Reflection Activity", "This activity is meant to help you reflect on your life to help you realize just how far you've come.") { }

    public async Task Run()
    {
        base.Start();
        await StartReflectionActivity();
        await base.End();
    }

    private async Task StartReflectionActivity()
    {
        string[] prompts = ["Think of a time when you stood up for someone else.",
                            "Think of a time when you did something really difficult",
                            "Think of a time when you helped someone in need.",
                            "Think of a time when you did something truly selfless."];
        Random random = new();
        int randomIndex = random.Next(prompts.Length);
        string prompt = prompts[randomIndex];
        Console.WriteLine(prompt);

        await PauseWithSpinner(5);

        await AskQuestions();
    }

    private static async Task PauseWithSpinner(int pauseTimeInSeconds)
    {
        char[] spinner = ['|', '/', '-', '\\'];
        int spinnerIndex = 0;
        int totalTime = pauseTimeInSeconds * 1000;
        int interval = 100;
        int elapsed = 0;

        while (elapsed < totalTime)
        {
            Console.Write(spinner[spinnerIndex]);
            await Task.Delay(interval);
            Console.Write("\b");

            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
            elapsed += interval;
        }

        Console.WriteLine();
    }

    private async Task AskQuestions()
    {
        string[] questions = ["Why was this experience meaningful to you?",
                              "What is your favorite thing about this experience?",
                              "What could you learn from this experience?",
                              "What could others learn from this experience?",
                              "Is there anything you wish you did differently?",
                              "What can you do to remember this experience?"];
        Random random = new();
        _elapsedTime = 0;
        while (_elapsedTime < _duration)
        {
            int randomIndex = random.Next(questions.Length);
            Console.WriteLine(questions[randomIndex]);
            await PauseWithSpinner(5);
            _elapsedTime += 5;
            Console.Clear();
        }
    }
}

class ListingActivity : Activity
{
    private System.Timers.Timer _timer;

    public ListingActivity()
        : base("Listing Activity", "This activity is meant to help you realize how many good things are in your life.") { }

    public async Task Run()
    {
        base.Start();
        await StartListingActivity();
        await base.End();
    }

    private async Task StartListingActivity()
    {
        string[] prompts = { "Who are people that you appreciate?",
                            "What are some of your personal strengths?",
                            "Who are people you've helped this week?",
                            "When have you felt the Holy Ghost this month?",
                            "Who are some of your personal heroes?" };
        Random random = new();
        int randomIndex = random.Next(prompts.Length);
        Console.WriteLine(prompts[randomIndex]);

        await Countdown();

        Console.WriteLine(prompts[new Random().Next(prompts.Length)]);

        int count = 0;

        var durationTask = Task.Delay(_duration * 1000);

        while (!durationTask.IsCompleted)
        {
            if (!string.IsNullOrEmpty(Console.ReadLine()))
            {
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items!");
    }

    private async Task Countdown()
    {
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"{i}\b");
            await Task.Delay(1000);
        }
    }
}