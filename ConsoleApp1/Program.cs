// ---- C# II (Dor Ben Dor) ----
// ben aldes
// -----------------------------
using ConsoleApp1;
using static System.Net.Mime.MediaTypeNames;

public abstract class Unit
{
    private Dice damage;
    public bool IsDead = false;
    public virtual int HP { get; set; }
    public virtual Race UnitRace { get; set; }
    public int carryingCapacity { get; set; }
    public  Dice hitChance { get; set; }
    public  Dice defenseRating { get; set; }
    public  WeatherEffect weatherEffect { get; set; }
    public virtual int Damage { get { return damage.roll(); } }
    public virtual void SetDamageDice(int scalar, int basedie, int modifier)
    {
        damage = new Dice(scalar,basedie,modifier);
    }
    public virtual void SetHitChance(int scalar, int basedie, int modifier)
    {
        hitChance = new Dice(scalar, basedie, modifier);
    }
    public virtual void SetDefenseChance(int scalar, int basedie, int modifier)
    {
        defenseRating = new Dice(scalar, basedie, modifier);
    }

    public virtual void Attack(Unit defender)
    {
        defender.Defense(this);
    }
    public virtual void ApplyWeatherEffects(WeatherEffect weather)
    {
        weatherEffect = weather;
    }
    public abstract void Defense(Unit attacker);
    protected void ApplyDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            IsDead = true;
            Console.WriteLine(this.ToString() + " Is Dead");
        }
    }
}
public abstract class NormalUnit : Unit
{

    public override void Defense(Unit attacker)
    {
        if(attacker.hitChance.roll() > this.defenseRating.roll())
        {
            int damage = attacker.Damage;
            Console.WriteLine($"{attacker.ToString()} attacked {this.ToString()} for {damage}");
            ApplyDamage(damage);
        }
        else
        {
            Console.WriteLine($"{attacker.ToString()} missed {this.ToString()} ");
        }
        
    }
}
public abstract class GamblerUnit : Unit
{
    Random random = new Random();

    public override void Defense(Unit attacker)
    {
        if (attacker.hitChance.roll() > this.defenseRating.roll())
        {
            int damage = attacker.Damage;
            Console.WriteLine($"{attacker.ToString()} attacked {this.ToString()} for {damage}");
            ApplyDamage(damage);
        }
        else
        {
            Console.WriteLine($"{attacker.ToString()} missed {this.ToString()} ");
        }
    }
  
}

public enum Race
{
    Humen,
    Fishmen,
    Giants
}
public enum WeatherEffect
{
    Rain,
    Snow,
    Thunderstorm,
    Heatwave

}

public class HumenWarrior : NormalUnit
{
    public HumenWarrior() 
    {
        UnitRace = Race.Humen;
        HP = 10;
        carryingCapacity = 5;
        SetDamageDice(2, 8, 4);
        SetHitChance(2, 8, 4);
        SetDefenseChance(2, 8, 4);
        
    }
}
public class HumenGambler : GamblerUnit
{
    public HumenGambler()
    {
        UnitRace = Race.Humen;
        HP = 8;
        carryingCapacity = 6;
        SetDamageDice(2, 8, 4);
    }
}
public class HumenSniper : NormalUnit
{
    Random random = new Random();
    public HumenSniper()
    {
        UnitRace = Race.Humen;
        HP = 6;
        carryingCapacity = 2;
        SetDamageDice(2, 8, 4);
        SetHitChance(2, 8, 4);
        SetDefenseChance(2, 8, 4);
    }
    public override void Attack(Unit defender)
    {
        int chance = random.Next(0, 3);
        if (chance == 0) return;
        base.Attack(defender);
    }
}

public class FishmanShark : NormalUnit
{
    public FishmanShark()
    {
        UnitRace = Race.Fishmen;
        HP = 15;
        carryingCapacity = 9;
        SetDamageDice(2, 8, 4);
        SetHitChance(2, 8, 4);
        SetDefenseChance(2, 8, 4);
    }
  
}
public class FishmanSquid : GamblerUnit
{
    public FishmanSquid()
    {
        UnitRace = Race.Fishmen;
        HP = 5;
        carryingCapacity = 10;
        SetDamageDice(2, 8, 4);
        SetHitChance(2, 8, 4);
        SetDefenseChance(2, 8, 4);
    }
    public override void Attack(Unit defender)
    {
        base.Attack(defender);
        base.Attack(defender);
    }

}

public class FishmanFish : NormalUnit
{
    public FishmanFish()
    {
        UnitRace = Race.Fishmen;
        HP = 1;
        carryingCapacity = 0;
        SetDamageDice(0, 0, 0);
        SetHitChance(0,0,0);
        SetDefenseChance(0,0,0);
    }
    public override void Attack(Unit defender) 
    {
        Console.WriteLine("FishmanFish is happy to be here");
    }

}

public class GiantFighter : GamblerUnit
{
    Random random = new Random();

    public GiantFighter()
    {
        UnitRace = Race.Giants;
        HP = 30;
        carryingCapacity = 40;
        SetDamageDice(2, 8, 4);
        SetHitChance(2, 8, 4);
        SetDefenseChance(2, 8, 4);
    }

}

public class GiantOre : GamblerUnit
{
    Random random = new Random();

    public GiantOre()
    {
        UnitRace = Race.Giants;
        HP = 100;
        carryingCapacity = 50;
        SetDamageDice(2, 8, 4);
        SetHitChance(2, 8, 4);
        SetDefenseChance(2, 8, 4);
    }
  
}
public class GiantKid : GamblerUnit
{
    Random random = new Random();

    public GiantKid()
    {
        UnitRace = Race.Giants;
        HP = 20;
        carryingCapacity = 20;
        SetDamageDice(2, 8, 4);
        SetHitChance(2, 8, 4);
        SetDefenseChance(2, 8, 4);
    }

}
