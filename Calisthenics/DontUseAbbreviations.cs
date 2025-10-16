namespace CursoRefactoring.Calisthenics
{

public class Emp
{
    private readonly double sal;
    private readonly int yrsExp;

    public Emp(double sal, int yrsExp)
    {
        this.sal = sal;
        this.yrsExp = yrsExp;
    }

    public double CalcBon()
    {
        if (yrsExp > 5)
        {
            return sal * 0.2;
        }
        return sal * 0.1;
    }
}
}
