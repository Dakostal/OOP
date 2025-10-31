namespace School.Models;

public class Pupil
{
    protected Random rand = new();

    public virtual void Study() => Console.WriteLine("Ученик учится.");
    public virtual void Read() => Console.WriteLine("Ученик читает.");
    public virtual void Write() => Console.WriteLine("Ученик пишет.");
    public virtual void Relax() => Console.WriteLine("Ученик отдыхает.");

    public virtual int GetCurrentGrade => rand.Next(2, 6);
}