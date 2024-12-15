class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new();
        ReflectionActivity reflectionActivity = new();
        ListingActivity listingActivity = new();
        
        Console.Clear();
        int input = -1;
        while (true)
        {
            Console.WriteLine("1. Breathing Activity\n2. Reflection Activity\n3. Listening Activity");
            if (!int.TryParse(Console.ReadLine(), out input) || !(input >= 1 && input <=3))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
            break;
        }
        switch(input)
        {
            case 1:
                breathingActivity.Run().GetAwaiter().GetResult();
                break;
            case 2:
                reflectionActivity.Run().GetAwaiter().GetResult();
                break;
            case 3:
                listingActivity.Run().GetAwaiter().GetResult();
                break;
        }
    }
}