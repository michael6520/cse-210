class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        
        Video v1 = new Video("Top 10 Bruce Lee Moments", "WatchMojo.com", 471);
        v1.AddComment(new Comment("Guy", "this is baller"));
        v1.AddComment(new Comment("Fellow", "this is rad"));
        v1.AddComment(new Comment("Individual", "this is epic"));

        Video v2 = new Video("Top 30 Saddest Anime Moments Of The Century (So Far)", "WatchMojo.com", 1842);
        v2.AddComment(new Comment("Guy", "this is kinda baller"));
        v2.AddComment(new Comment("Fellow", "this is kinda rad"));
        v2.AddComment(new Comment("Individual", "this is kinda epic"));

        Video v3 = new Video("Top 20 Most Hilarious Disney Characters", "WatchMojo.com", 1191);
        v3.AddComment(new Comment("Guy", "this is not baller"));
        v3.AddComment(new Comment("Fellow", "this is not rad"));
        v3.AddComment(new Comment("Individual", "this is not epic"));

        videos.AddRange(new List<Video> { v1, v2, v3 });

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments ({video.CountComments()}):");

            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}