using System;
using ConsoleApp1;

var weapon1 = new Weapon("Axe", 120, TypePerck.Burn);
var weapon2 = new Weapon("Sword Fire", 80, TypePerck.Burn);

List<IItem> inventory = [weapon1,weapon2];

Character player = new Character("Player", null, 100, 100, 1000, inventory);

Character monster = new Character("Monster", null, 80, 20, 500,inventory);

/*Ver acciones y eventos.
 * Refactorizar el codigo.
 * Hacer test .
 * Realizar perck :
 * 1º UML
 */

Console.WriteLine(player.GetAffected());
bool playerHealed = false;


Console.WriteLine("¡Te enfrentas a un monstruo!");

while (!player.IsDead() && !monster.IsDead())
        {
            // Mostrar el estado actual
            Console.WriteLine($"\n{player.Name}: {player.PointsHealth} HP");
            Console.WriteLine($"{monster.Name}: {monster.PointsHealth} HP");

            // Mostrar menú de acciones
            Console.WriteLine("\n¿Qué quieres hacer?");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Curarse (solo puedes hacerlo una vez por enfrentamiento)");

           
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": // Atacar
                    int damageToMonster = player.Attack(random: new Random());
                    monster.affected = player.GetAffected();
                    Console.WriteLine($"¡Atacas al monstruo y le causas {damageToMonster} de daño!");
                    Console.WriteLine(monster.ReceiveDamage(damageToMonster));
                    break;

                case "2": // Curarse
                    if (!playerHealed)
                    {
                        Console.WriteLine(player.Heal(200)); // Curarse 200 puntos de vida
                        playerHealed = true;
                    }
                    else
                    {
                        Console.WriteLine("¡Ya te has curado una vez en este enfrentamiento! No puedes curarte más.");
                    }
                    break;

                default:
                    Console.WriteLine("Opción no válida, intenta de nuevo.");
                    continue; 
            }

            if (!monster.IsDead())
            {
                int damageToPlayer = monster.Attack(random: new Random());
                player.affected = monster.GetAffected();
                Console.WriteLine($"¡El monstruo te ataca y te causa {damageToPlayer} de daño!");
                Console.WriteLine(player.ReceiveDamage(damageToPlayer));
            }
            else
            {
                if(monster.affected.Contains(TypePerck.Paralysis))Console.WriteLine($"El mounstruo esta paralizado .");
            }
        }

        // Verificar el resultado del combate
        if (player.IsDead())
        {
            Console.WriteLine("\nHas sido derrotado por el monstruo...");
        }
        else if (monster.IsDead())
        {
            Console.WriteLine("\n¡Has derrotado al monstruo!");
        }
    
