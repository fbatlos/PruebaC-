using ConsoleApp1;


Weapon weapon1 = new Weapon("Axe", 120);
Weapon weapon2 = new Weapon("Sword", 150);
Protection protection1 = new Protection("Shield", 150);
Protection protection2 = new Protection("Helmet", 100);

List<IItem> inventory = [weapon1,weapon2,protection1,protection2];




Character player = new Character("Player", 1000,100, 100,inventory);

Console.WriteLine(player.Attack());

Console.WriteLine(player.ReceiveDamage(100));