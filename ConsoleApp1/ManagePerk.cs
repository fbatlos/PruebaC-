namespace ConsoleApp1;

public class ManagePerk(Character character)
{
    private int poison = 40;
    
    public List<TypePerk> GetAffected()
    {
        var listPerck = new List<TypePerk>((int)TypePerk.None);
        foreach (var weapon in character._Inventory)
        {
            if (GetPosibility(weapon.Perk))
            {
                listPerck.Add(weapon.Perk);
            }
        }
        
        return listPerck;
        
    }
    
    private bool GetPosibility(TypePerk perk){
        var random = new Random();
        switch (perk)
        {
            case TypePerk.Minion:
                return true;
            case TypePerk.Burn:
                if (random.Next(0, 7) == 0)
                {
                    return true;
                }
                break;
            
            case TypePerk.Paralysis :
                if (random.Next(0, 5) == 0)
                {
                    return true;
                }
                break;
            case TypePerk.Poison:
                if (random.Next(0, 10) == 0)
                {
                    return true;
                }
                break;
        }

        return false;
    }
    
    public int DamagePerk()
    {
        if (character.affected.Contains(TypePerk.Burn))
        {
            return 40;

        }

        if (character.affected.Contains(TypePerk.Poison))
        {
            poison -= 10;
            return poison;
        }

        return 0;
    }
}