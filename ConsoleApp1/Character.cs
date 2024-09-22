using ConsoleApp1;

public class Character(string name, int PointsHealth, int? MaxHitPoints, int BaseDamage, int BaseArmor, List<IItem> _inventory)
{
    
    public int Attack()
    {
        if (_inventory.Count == 0)
        {
            return BaseDamage;
        }
        else
        {
            return BaseDamage + (DamegeAllItem(_inventory)/10);
        }
    }

    //
    int DamegeAllItem(List<IItem> _inventory)
    {
        int totalDamege = 0;
        foreach (var weapon in _inventory)
        {
            if (weapon is Weapon)
            {
                totalDamege += weapon.Apply(this);
            }
        }

        return totalDamege;
    }

    int Defend()
    {
        if (_inventory.Count == 0)
        {
            return BaseArmor;
        }
        else
        {
            return BaseArmor + ArmorAllItem(_inventory);
        }
    }
    int ArmorAllItem(List<IItem> _inventory)
    {
        int totalArmor = 0;
        foreach (var protection in _inventory)
        {
            if (protection is Protection)
            {
                totalArmor += protection.Apply(this);
            }
        }

        return totalArmor;
    }
    public int Heal(int amount)
    {
        if(amount+PointsHealth <= 1000){
            return amount+PointsHealth;
        }
        else
        {
            PointsHealth = 1000;
            return PointsHealth;
        }
    }

    public int ReceiveDamage(int damage)
    {
        PointsHealth -= damage - (Defend()/10);
        
        return damage - (Defend()/10);
    }
    
}