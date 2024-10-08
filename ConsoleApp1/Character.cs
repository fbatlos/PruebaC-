﻿using System;
using ConsoleApp1;

public class Character(
    string Name,
    int? MaxHitPoints,
    int BaseDamage,
    int BaseArmor,
    int PointsHealth,
    List<IItem> _inventory )
{
    public List<TypePerck> affected = [TypePerck.None];
    
    public string Name = Name;
    public int PointsHealth = PointsHealth;
    public int BaseDamage = BaseDamage;
    public int BaseArmor = BaseArmor;
    public int? MaxHitPoints = MaxHitPoints;

    private int damage = 0;
    private int armor = 0;
   
    public int Attack(Random random)
    {
        double rand = random.NextDouble();

        List<double> stats = DamegeAllItem(_inventory);

        if (_inventory.Count == 0)
        {
            return BaseDamage;
        }
        else
        {
             if (rand < 0.1-stats[1])
            {//No hacer los WriteLine , recordar
                Console.WriteLine($"{Name} intentó atacar pero falló.");
                damage = 0;
                return 0; // Ataque fallido
            }

            rand = random.NextDouble();

            if (rand < 0.3+stats[2])
            {
                int critDamage = (BaseDamage +  (int)stats[0])*2; // Doble daño en crítico
                damage = critDamage;
                Console.WriteLine($"{Name} hizo un golpe crítico causando {critDamage} de daño.");
                return critDamage;
            }

            damage = BaseDamage + (int)stats[0];
            return damage;
        }
    }


    public List<TypePerck> GetAffected()
    {
        var listPerck = new List<TypePerck>((int)TypePerck.None);
        foreach (var weapon in _inventory)
        {
            if (GetPosibility(weapon.Perck))
            {
                listPerck.Add(weapon.Perck);
            }
        }
        
        return listPerck;
        
    }

    public bool GetPosibility(TypePerck perck){
        var random = new Random();
        switch (perck)
        {
            case TypePerck.Burn:
                if (random.Next(0, 7) == 0)
                {
                    return true;
                }
                break;
            
            case TypePerck.Paralysis :
                if (random.Next(0, 5) == 0)
                {
                    return true;
                }
                break;
            case TypePerck.Poison:
                if (random.Next(0, 10) == 0)
                {
                    return true;
                }
                break;
        }

        return false;
    }
    //
    List<double> DamegeAllItem(List<IItem> _inventory)
    {
        double totalDamege = 0;
        double totalReduceMissChance = 0;
        double totalCritChance = 0 ;

        foreach (var weapon in _inventory)
        {
            if (weapon is Weapon)
            {
                totalDamege += weapon.Apply(this);
                totalReduceMissChance += weapon.ReduceMissChance;
                totalCritChance += weapon.CritChance;
            }
        }

        return [totalDamege,totalReduceMissChance,totalCritChance];
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
    public string Heal(int amount)
    {
        if(amount+PointsHealth <= 1000){
            return $"{Name} se curó {amount}. Vida actual: {amount+PointsHealth}.";
        }
        else
        {
            PointsHealth = 1000;
            return $"{Name} se curó {amount}. Vida actual: {PointsHealth}.";
        }
    }

    public string ReceiveDamage(int damage)
    {
        if (damage==0)
        {
            return "No ha recivido daño";
        }

        armor = Defend() / 10;

        PointsHealth -= damage - armor + DamageBurn();
        int damageTaken = damage - armor + DamageBurn();

        if (PointsHealth < 0) PointsHealth = 0;

        if (affected.Contains(TypePerck.Burn))
        {
            return $"{Name} se defendió y redujo el daño en {armor} puntos , pero recibió {damageTaken} de daño y 40 de quemadura . Vida restante: {PointsHealth}.";
        }

        return $"{Name} recibió {damageTaken} de daño. Vida restante: {PointsHealth}.";
    }

    private int DamageBurn()
    {
        if (affected.Contains(TypePerck.Burn))
        {
            return 40;

        }

        return 0;
    }

     public bool IsDead()
    {
        return PointsHealth <= 0;
    }
     
     //ToString no es nada mala
     public override string ToString()
     {
         return base.ToString();
     }
}