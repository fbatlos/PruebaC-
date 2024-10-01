namespace ConsoleApp1;

public class Weapon(String name, int damage, double ReducemissChance = 0.01, double critChance = 0.3):IItem
{
    public double ReduceMissChance {get;set;}
    public double CritChance {get;set;}

    public int Apply(Character character)
    {
        return damage;
    }
}
