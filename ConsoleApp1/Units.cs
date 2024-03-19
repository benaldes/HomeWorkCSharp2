// ---- C# II (Dor Ben Dor) ----
// ben aldes
// -----------------------------

namespace ConsoleApp1
{
    public abstract class Unit
    {
        private IRandomProvider damage { get; set; }
        public bool IsDead = false;
        public virtual int HP { get; set; }
        public virtual Race UnitRace { get; set; }
        public int carryingCapacity { get; set; }
        private IRandomProvider hitChance { get; set; }
        private IRandomProvider defenseRating { get; set; }
        public WeatherEffect weatherEffect { get; set; }
        public virtual int Damage { get { return damage.Roll(); } }
        public virtual int HitChance { get { return hitChance.Roll(); } }
        public virtual int DefenseRating { get { return defenseRating.Roll(); } }

        public Unit(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
        {
            this.damage = damage;
            this.hitChance = hitChance;
            this.defenseRating = defenseRating;  
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
            if (HP <= 0)
            {
                IsDead = true;
                Console.WriteLine(this.ToString() + " Is Dead");
            }
        }
    }
    public abstract class NormalUnit : Unit
    {
        protected NormalUnit(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
                            : base(damage, hitChance, defenseRating) { }

        public override void Defense(Unit attacker)
        {
            if (attacker.HitChance > this.DefenseRating)
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
        protected GamblerUnit(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
                            : base(damage, hitChance, defenseRating) { }
        public override void Defense(Unit attacker)
        {
            if (attacker.HitChance > this.DefenseRating)
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
        Dice dice = new Dice(2, 8, 4);
        public HumenWarrior(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating) 
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Humen;
            HP = 10;
            carryingCapacity = 5;
        }
        
    }
    public class HumenGambler : GamblerUnit
    {
        public HumenGambler(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Humen;
            HP = 8;
            carryingCapacity = 6;
        }
    }
    public class HumenSniper : NormalUnit
    {
        Random random = new Random();
        public HumenSniper(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Humen;
            HP = 6;
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
        public FishmanShark(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Fishmen;
            HP = 15;
            carryingCapacity = 9;

        }

    }
    public class FishmanSquid : GamblerUnit
    {
        public FishmanSquid(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Fishmen;
            HP = 5;
            carryingCapacity = 10;

        }
        public override void Attack(Unit defender)
        {
            base.Attack(defender);
            base.Attack(defender);
        }

    }

    public class FishmanFish : NormalUnit
    {
        public FishmanFish(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Fishmen;
            HP = 1;
            carryingCapacity = 0;
        }
        public override void Attack(Unit defender)
        {
            Console.WriteLine("FishmanFish is happy to be here");
        }

    }

    public class GiantFighter : GamblerUnit
    {
        Random random = new Random();

        public GiantFighter(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Giants;
            HP = 30;
            carryingCapacity = 40;

        }

    }

    public class GiantOre : GamblerUnit
    {
        Random random = new Random();

        public GiantOre(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Giants;
            HP = 100;
        }

    }
    public class GiantKid : GamblerUnit
    {
        Random random = new Random();

        public GiantKid(IRandomProvider damage, IRandomProvider hitChance, IRandomProvider defenseRating)
            : base(damage, hitChance, defenseRating)
        {
            UnitRace = Race.Giants;
            HP = 20;
            carryingCapacity = 20;
        }

    }
}