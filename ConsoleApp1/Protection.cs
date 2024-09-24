namespace ConsoleApp1;

public class Protection(String name, int armor):IItem
{
    public double ReduceMissChance { get; }
    public double CritChance { get; }

    public int Apply(Character character)
    {
        return armor;
    }
}