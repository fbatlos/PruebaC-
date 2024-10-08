namespace ConsoleApp1;

public class Weapon(string name, int damage, TypePerck perck, double ReducemissChance = 0.01, double critChance = 0.3):IItem
{
    public double ReduceMissChance {get;set;}
    public double CritChance {get;set;}
    
    public TypePerck Perck { get; set; }
    

    public int Apply(Character character)
    {
        return damage;
    }
    
}
