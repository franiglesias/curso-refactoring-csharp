namespace CursoRefactoring.Calisthenics;

public class Project
{
    private readonly List<string> tasks = new();

    public void AddTask(string task)
    {
        tasks.Add(task);
    }

    public IReadOnlyList<string> GetTasks()
    {
        return tasks.AsReadOnly();
    }
}

public class ProjectExample
{
    public static void RunExample()
    {
        var project = new Project();
        project.AddTask("Design UI");
        // project.GetTasks().Add("Hack the system"); // This would not compile in C# due to readonly return
    }
}