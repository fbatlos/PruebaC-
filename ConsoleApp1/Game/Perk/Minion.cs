namespace ConsoleApp1;

public class Minion
{
    public int Damage { get; set; }
    
    public int Health { get; set; }
    
    public int Armor { get; set; }

    public Minion(Character character)
    {
        Damage = (int)(character.damage*0.7);
        Health = 100;
        Armor = (int)(character.armor*0.7);
    }

    public int Attack()
    {
        return Damage;
    }

    public int Defend()
    {
        return (int)(Armor * 0.1);
    }

    public int ReduceHealth(int reduction)
    {
        if (reduction-Defend()<0)
        {
            reduction = 0;
        }
        return Health - (reduction-Defend());
    }
    
    
    
    
}