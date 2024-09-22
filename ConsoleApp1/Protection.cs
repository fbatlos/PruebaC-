namespace ConsoleApp1;

public class Protection(String name, int armor):IItem
{
    public int Apply(Character character)
    {
        return armor;
    }
}