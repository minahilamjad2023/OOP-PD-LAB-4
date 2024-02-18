using System;
using System.Collections.Generic;

class Stats
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Penetration { get; set; }
    public int Heal { get; set; }
    public int Cost { get; set; }
    public string Description { get; set; }

    public Stats(string name, int damage, int penetration, int heal, int cost, string description)
    {
        Name = name;
        Damage = damage;
        Penetration = penetration;
        Heal = heal;
        Cost = cost;
        Description = description;
    }
}

class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Energy { get; set; }
    public int MaxEnergy { get; set; }
    public int Armor { get; set; }

    public Player(string name, int health, int maxHealth, int energy, int maxEnergy, int armor)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Energy = energy;
        MaxEnergy = maxEnergy;
        Armor = armor;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Player: {Name}");
        Console.WriteLine($"Health: {Health}/{MaxHealth}");
        Console.WriteLine($"Energy: {Energy}/{MaxEnergy}");
        Console.WriteLine($"Armor: {Armor}");
    }

    public void Attack(Player target, Stats skill)
    {
        int effectiveArmor = Math.Max(0, target.Armor - skill.Penetration);
        double effectiveDamage = skill.Damage * ((100.0 - effectiveArmor) / 100.0);

        if (Energy < skill.Cost)
        {
            Console.WriteLine($"{Name} attempted to use {skill.Name}, but didn't have enough energy!");
            return;
        }

        target.Health -= (int)effectiveDamage;
        Health += skill.Heal;
        Energy -= skill.Cost;

        Console.WriteLine($"{Name} used {skill.Name}, {skill.Description}, against {target.Name}, doing {effectiveDamage:F2} damage!");

        if (skill.Heal > 0)
            Console.WriteLine($"{Name} healed for {skill.Heal} health!");

        if (target.Health <= 0)
            Console.WriteLine($"{target.Name} died.");
        else
            Console.WriteLine($"{target.Name} is at {(double)target.Health / target.MaxHealth * 100:F2}% health.");
    }
}

class Program
{
    static List<Player> players = new List<Player>();
    static List<Stats> skills = new List<Stats>();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Add Skill Statistics");
            Console.WriteLine("3. Display Player Info");
            Console.WriteLine("4. Learn a Skill");
            Console.WriteLine("5. Attack");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddPlayer();
                    break;
                case 2:
                    AddSkill();
                    break;
                case 3:
                    DisplayPlayerInfo();
                    break;
                case 4:
                    LearnSkill();
                    break;
                case 5:
                    Attack();
                    break;
                case 6:
                    exit = true;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    static void AddPlayer()
    {
        Console.Write("Enter player name: ");
        string name = Console.ReadLine();

        Console.Write("Enter player health: ");
        int health = int.Parse(Console.ReadLine());

        Console.Write("Enter player max health: ");
        int maxHealth = int.Parse(Console.ReadLine());

        Console.Write("Enter player energy: ");
        int energy = int.Parse(Console.ReadLine());

        Console.Write("Enter player max energy: ");
        int maxEnergy = int.Parse(Console.ReadLine());

        Console.Write("Enter player armor: ");
        int armor = int.Parse(Console.ReadLine());

        players.Add(new Player(name, health, maxHealth, energy, maxEnergy, armor));
        Console.WriteLine("Player added successfully.");
    }

    static void AddSkill()
    {
        Console.Write("Enter skill name: ");
        string name = Console.ReadLine();

        Console.Write("Enter skill damage: ");
        int damage = int.Parse(Console.ReadLine());

        Console.Write("Enter skill penetration: ");
        int penetration = int.Parse(Console.ReadLine());

        Console.Write("Enter skill heal: ");
        int heal = int.Parse(Console.ReadLine());

        Console.Write("Enter skill cost: ");
        int cost = int.Parse(Console.ReadLine());

        Console.Write("Enter skill description: ");
        string description = Console.ReadLine();

        skills.Add(new Stats(name, damage, penetration, heal, cost, description));
        Console.WriteLine("Skill statistics added successfully.");
    }

    static void DisplayPlayerInfo()
    {
        foreach (var player in players)
        {
            player.DisplayInfo();
            Console.WriteLine();
        }
    }

    static void LearnSkill()
    {
        Console.Write("Enter player name: ");
        string playerName = Console.ReadLine();

        Console.Write("Enter skill name: ");
        string skillName = Console.ReadLine();

        Player player = players.Find(p => p.Name == playerName);
        if (player == null)
        {
            Console.WriteLine($"Player {playerName} not found.");
            return;
        }

        Stats skill = skills.Find(s => s.Name == skillName);
        if (skill == null)
        {
            Console.WriteLine($"Skill {skillName} not found.");
            return;
        }

        player.LearnSkill(skill);
        Console.WriteLine($"{playerName} learned {skillName} skill.");
    }

    static void Attack()
    {
        Console.Write("Enter attacking player name: ");
        string attackerName = Console.ReadLine();

        Console.Write("Enter target player name: ");
        string targetName = Console.ReadLine();

        Player attacker = players.Find(p => p.Name == attackerName);
        Player target = players.Find(p => p.Name == targetName);

        if (attacker == null || target == null)
        {
            Console.WriteLine("Invalid player names. Check the player list.");
            return;
        }

        Console.WriteLine($"{attacker.Name} is attacking {target.Name}.");
        Console.WriteLine("Choose a skill:");

        for (int i = 0; i < skills.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {skills[i].Name}");
        }

        int skillIndex;
        if (!int.TryParse(Console.ReadLine(), out skillIndex) || skillIndex < 1 || skillIndex > skills.Count)
        {
            Console.WriteLine("Invalid skill choice.");
            return;
        }

        attacker.Attack(target, skills[skillIndex - 1]);
    }
}

