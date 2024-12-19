class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = [];
        
        Running running = new("14 Apr 2024", 30, 6);
        Cycling cycling = new("05 Sep 2024", 90, 25);
        Swimming swimming = new("22 Nov 2024", 55, 30);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            activity.Summary();
        }
    }
}