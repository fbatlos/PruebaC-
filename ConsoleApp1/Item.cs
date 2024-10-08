namespace ConsoleApp1;

public interface IItem
{
    
    int Apply(Character character);
    TypePerck Perck { get; set; }
    double CritChance{ get; set; }
    
    double ReduceMissChance{ get; }
    
    
}