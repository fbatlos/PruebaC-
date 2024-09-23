namespace ConsoleApp1;

public interface IItem
{
     double ReduceMissChance{get;}
     double CritChance {get;}
    int Apply(Character character);
}