using System;
using ConsoleApp1;


Weapon weapon1 = new Weapon("Axe", 120,0.01,0.5);
Weapon weapon2 = new Weapon("Sword", 150);
Protection protection1 = new Protection("Shield", 150);
Protection protection2 = new Protection("Helmet", 100);


List<IItem> inventory = [weapon1,weapon2,protection1,protection2];


Character player = new Character("Player",1000, null,100, 100,inventory);

Character monster = new Character("Monster", 500, null, 80, 20, new List<IItem>());


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

            // Leer la acción del jugador
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": // Atacar
                    int damageToMonster = player.Attack(random: new Random());
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
                    continue;  // Volver a mostrar el menú sin que el monstruo ataque
            }

            // Después del turno del jugador, el monstruo ataca si no ha muerto
            if (!monster.IsDead())
            {
                int damageToPlayer = monster.Attack(random: new Random());
                Console.WriteLine($"¡El monstruo te ataca y te causa {damageToPlayer} de daño!");
                Console.WriteLine(player.ReceiveDamage(damageToPlayer));
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
    
