namespace CursoRefactoring.Calisthenics;

public class Report
{
    private readonly string title;
    private readonly string author;
    private readonly string content;
    private readonly DateTime createdAt;
    private readonly string[] tags;

    public Report(string title, string author, string content, DateTime createdAt, string[] tags)
    {
        this.title = title;
        this.author = author;
        this.content = content;
        this.createdAt = createdAt;
        this.tags = tags;
    }

    public void PrintSummary()
    {
        Console.WriteLine($"Report: {title} by {author} ({createdAt:yyyy-MM-dd})");
    }
}