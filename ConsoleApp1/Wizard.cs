using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Wizard : IWizard
    {
        Random rnd = new Random();
        public string Name { get; private set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public bool Concentration { get; private set; }

        public int HealthLost { get; set; }
        public int SpeedLost { get; set; }

        public bool Dodged{ get; set; }

        public int HealthGained { get; set; }

        public int DamageNegated { get; set; }

        public int SpeedGained { get; set; }
        public Wizard(string name) 
        {
            Name = name;
            Console.WriteLine($"The Wizard {Name} was born");
            Health = 15;
            Speed = rnd.Next(1, 5);
            Console.WriteLine($"Has {Health} health");
        }

        public void Attack(Wizard enemy)
        {
            if(!Concentration) { enemy.HealthLost += rnd.Next(1, 4); }
            else { enemy.HealthLost += rnd.Next(2, 7); }
            Speed = 2;
        }

        public void Defend()
        {
            if (!Concentration) {DamageNegated += rnd.Next(2, 4); }
            else { Dodged = true; }
            Speed = 1;
            Concentration = false;


        }

        public void Dodge()
        {
            if (!Concentration)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    Dodged = true;
                }
            }
            else
            {
                if (rnd.Next(0, 4) > 0)
                {
                    Dodged = false;
                }
                
            }

            Speed = 3;
            Concentration = false;
        }

        public void Hinder(Wizard enemy)
        {
            if (!Concentration) { enemy.SpeedLost += rnd.Next(1, 4); }
            else { enemy.SpeedLost += rnd.Next(2, 7); }

           
            Speed = 2;
            Concentration = false;
        }

        public void Concentrate()
        {
            Concentration = true;
            Speed = 4;
        }

        public void WildMagic()
        {
            
            if(!Concentration)
            {
                Console.WriteLine($"{Name} Casts Wild Magic Without Concentration");
                if (rnd.Next(0,4) == 3) 
                {
                    Dodged = true;
                    WildMagicRoll();
                }
                else
                {
                    Console.WriteLine("it fails!");
                }
            }

            else
            {
                Concentration = false;
                Console.WriteLine($"{Name} Casts Wild Magic With Concentration");
                if (rnd.Next(0,4) >= 2)
                {
                    Dodged = true;
                    WildMagicRoll();
                }
                else
                {
                    Console.WriteLine("it fails!");
                }
            }

            Speed = 2;
            
        }

        public void WildMagicRoll()
        {
            Console.WriteLine($"{Name} successfully casted wildMagic!");
           int roll =  rnd.Next(0,3);

            if(roll == 0) { SpeedGained += 3; Console.WriteLine($"Speed!"); }
            if(roll == 1) { Concentration = true; Console.WriteLine($"Concentration!"); }
            if(roll == 2) { HealthGained += rnd.Next(1, 4); Console.WriteLine($"Health!"); }
        }

        public void Describe()
        {
            Console.WriteLine($"\n {Name}'s Stats:");
            
            Console.WriteLine($"Speed - {Speed} \n Speed Lost - {SpeedLost} \n Dodged - {Dodged} \n Health Lost - {HealthLost}  \n Damage Negated - {DamageNegated}\n Health Gained - {HealthGained} \n Concentration - {Concentration} \n");
        }

        public void EndRound()
        {
            if(!Dodged)
            {
                Console.WriteLine($"{Name} took {Math.Clamp(HealthLost - DamageNegated, 0, 10)} damage!");
                Health = (Health - Math.Clamp(HealthLost - DamageNegated, 0, 10) + HealthGained);
                Speed = (Speed -  SpeedLost + SpeedGained);

            }
            else
            {
                Console.WriteLine($"{Name} dodged!");
                Health += HealthGained;
                Speed += SpeedGained;
            }
            Console.WriteLine($"{Name} Gained {HealthGained} health from wild magic!");
            Console.WriteLine($"{Name} Gained {SpeedGained} speed from wild magic!");
            Describe();


        }

    }
}
