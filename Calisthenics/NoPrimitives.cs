namespace CursoRefactoring.Calisthenics;

public class User
{
    private readonly string name;
    private string email;

    public User(string name, string email)
    {
        this.name = name;
        this.email = email;
    }

    public void ChangeEmail(string newEmail)
    {
        if (!newEmail.Contains('@'))
        {
            throw new ArgumentException("Invalid email");
        }
        this.email = newEmail;
    }
}