namespace ConsoleApp1;

public interface IItem
{
    
    int Apply(Character character);
    TypePerk Perk { get; set; }
    double CritChance{ get; set; }
    
    double ReduceMissChance{ get; }
    
    
}