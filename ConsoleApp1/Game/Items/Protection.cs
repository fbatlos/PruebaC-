namespace ConsoleApp1;

public class Protection : IItem
{
    public string Name { get; }
    public int Armor { get; }
    public TypePerk Perk { get; set; }

    public double CritChance { get; set; }
    public double ReduceMissChance { get; }

    // Constructor
    public Protection(string name, int armor, TypePerk perk)
    {
        Name = name;
        Armor = armor;
        Perk = perk;
    }

    public int Apply(Character character)
    {
        // Aquí puedes implementar la lógica para aplicar el daño al personaje
        return Armor;
    }
}
