namespace ConsoleApp1;

public class Protection : IItem
{
    public string Name { get; }
    public int Armor { get; }
    public TypePerck Perck { get; set; }

    public double CritChance { get; set; }
    public double ReduceMissChance { get; }

    // Constructor
    public Protection(string name, int armor, TypePerck perck)
    {
        Name = name;
        Armor = armor;
        Perck = perck;
    }

    public int Apply(Character character)
    {
        // Aquí puedes implementar la lógica para aplicar el daño al personaje
        return Armor;
    }
}
