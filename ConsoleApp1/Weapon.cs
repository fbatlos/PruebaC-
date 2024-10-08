namespace ConsoleApp1;

public class Weapon : IItem
{
    public string Name { get; }
    public int Damage { get; }
    public TypePerck Perck { get; set; }
    public double ReduceMissChance { get; }
    public double CritChance { get; set; }

    // Constructor
    public Weapon(string name, int damage, TypePerck perck, double reduceMissChance = 0.01, double critChance = 0.03)
    {
        Name = name;
        Damage = damage;
        Perck = perck;
        ReduceMissChance = reduceMissChance;
        CritChance = critChance;
    }

    public int Apply(Character character)
    {
        // Aquí puedes implementar la lógica para aplicar el daño al personaje
        return Damage;
    }
}

