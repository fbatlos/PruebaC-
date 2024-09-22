namespace ConsoleApp1;

public class Weapon(String name, int damage):IItem
{
    public int Apply(Character character)
    {
        return damage;
    }
}