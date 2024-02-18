using System;

class Stats
{
    public string name;
    public int damage;
    public string description;
    public int penetration;
    public int cost;
    public int heal;

    public Stats(int damage, int penetration, int heal, int cost, string description) // public Stats with the parameters
    {
        this.damage = damage;
        this.penetration = penetration;
        this.heal = heal;
        this.cost = cost;
        this.description = description;
    }
}

class Player // class of the player 
{
    public int hp;
    public int maxHp;
    public int energy;
    public int maxEnergy;
    public int armor;
    public string name;
    public Stats skillStatistics;

    public Player(string name, int health, int energy, int armor)
    {
        this.name = name;
        this.hp = health;
        this.maxHp = health;
        this.energy = energy;
        this.maxEnergy = energy;
        this.armor = armor;
    }

    public void UpdateHealth(int value) // update health logic 
    {
        this.hp += value;
        if (this.hp < 0)
            this.hp = 0;
        else if (this.hp > this.maxHp)
            this.hp = this.maxHp;
    }

    public void UpdateEnergy(int value)
    {
        this.energy += value;
        if (this.energy < 0)
            this.energy = 0;
        else if (this.energy > this.maxEnergy)
            this.energy = this.maxEnergy;
    }

    public void UpdateArmor(int value)
    {
        this.armor += value;
        if (this.armor < 0)
            this.armor = 0;
    }

    public void UpdateName(string newName)
    {
        this.name = newName;
    }

    public void LearnSkill(Stats skillStats)
    {
        skillStatistics = skillStats;
    }

    public string Attack(Player target)
    {
        if (skillStatistics == null)
            return "No skill learned yet.";

        int effectiveArmor = Math.Max(0, target.armor - skillStatistics.penetration); // for calculating effective armor 
        double effectiveDamage = skillStatistics.damage * ((100.0 - effectiveArmor) / 100.0);

        if (energy < skillStatistics.cost)
            return $"{name} attempted to use {skillStatistics.name}, but didn't have enough energy!";

        target.UpdateHealth((int)-effectiveDamage);
        UpdateHealth(skillStatistics.heal);
        UpdateEnergy(-skillStatistics.cost);

        string attackString = $"{name} used {skillStatistics.name}, {skillStatistics.description}, against {target.name}, doing {effectiveDamage:F2} damage!";

        if (skillStatistics.heal > 0)
            attackString += $" {name} healed for {skillStatistics.heal} health!";

        if (target.hp <= 0)
            attackString += $" {target.name} died.";
        else
        {
            double targetHpPerc = (target.hp * 100.0) / target.maxHp;
            attackString += $" {target.name} is at {targetHpPerc:F2}% health.";
        }

        return attackString;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter information for Player 1:");
        Player player1 = GetPlayerInformation();

        Console.WriteLine("\nEnter information for Player 2:");
        Player player2 = GetPlayerInformation();

        Console.WriteLine("\nPlayers ready for battle!");

        Console.WriteLine("\nLearning a skill for Player 1:");
        Stats skill1 = GetSkillInformation();
        player1.LearnSkill(skill1);

        Console.WriteLine("\nLearning a skill for Player 2:");
        Stats skill2 = GetSkillInformation();
        player2.LearnSkill(skill2);

        Console.WriteLine("\nBattle begins!\n");

        Console.WriteLine(player1.Attack(player2));
    }

    static Player GetPlayerInformation()
    {
        Console.Write("Enter player name: ");
        string name = Console.ReadLine();

        Console.Write("Enter player health: ");
        int health = int.Parse(Console.ReadLine());

        Console.Write("Enter player energy: ");
        int energy = int.Parse(Console.ReadLine());

        Console.Write("Enter player armor: ");
        int armor = int.Parse(Console.ReadLine());


        return new Player(name, health, energy, armor);
    }

    static Stats GetSkillInformation()
    {
        Console.Write("Enter skill name: ");
        string name = Console.ReadLine();

        Console.Write("Enter skill damage: ");
        int damage = int.Parse(Console.ReadLine());

        Console.Write("Enter skill penetration: ");
        int penetration = int.Parse(Console.ReadLine()); // parse is used to change string to another datatype 

        Console.Write("Enter skill heal: ");
        int heal = int.Parse(Console.ReadLine());

        Console.Write("Enter skill cost: ");
        int cost = int.Parse(Console.ReadLine());

        Console.Write("Enter skill description: ");
        string description = Console.ReadLine();

        return new Stats(damage, penetration, heal, cost, description);
    }
}
