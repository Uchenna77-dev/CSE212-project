public class Person
{
    public readonly string Name;
    public int Turns { get; set; }

    internal Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }

     public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return Name == other.Name && Turns == other.Turns;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Turns);
    }
}