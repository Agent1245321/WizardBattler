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

        public int LastMove { get; set; }
        public Wizard(string name) 
        {
            Name = name;
            Console.WriteLine($"The Wizard {Name} was born");
            Health = 15;
            Speed = rnd.Next(1, 5);
            Console.WriteLine($"{Name} has {Health} health");
        }

        public void Attack(Wizard enemy)
        {
            int roll = rnd.Next(1, 4);
            int croll = rnd.Next(2, 7);
            if (!Concentration) { enemy.HealthLost += roll; Console.WriteLine($"\n {Name} cast Fireball! it deals {roll} damage!"); }
            else { enemy.HealthLost += croll; Console.WriteLine($"\n {Name} cast FIRESTORM! it deals {croll} damage!"); }
            Speed = 2;
            Concentration = false;
        }

        public void Defend()
        {
            int roll = rnd.Next(2, 4);
            if (!Concentration) { DamageNegated += roll; Console.WriteLine($"\n {Name} cast Shield! it negates {roll} damage!"); }
            else { Dodged = true; Console.WriteLine($"\n {Name} casts IronSkin! It negates all damage!"); }
            Speed = 1;
            Concentration = false;


        }

        public void Dodge()
        {
            if (!Concentration)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    Console.WriteLine($"\n {Name} Dodges all damage!");
                    Dodged = true;
                }
            }
            else
            {
                if (rnd.Next(0, 4) > 0)
                {
                    Console.WriteLine($"\n {Name} Dodges all damage!");
                    Dodged = true;
                }
                
            }

            Speed = 3;
            Concentration = false;
        }

        public void Hinder(Wizard enemy)
        {
            int roll = rnd.Next(1, 4);
            int croll = rnd.Next(2, 7);
            if (!Concentration) { enemy.SpeedLost += roll; Console.WriteLine($"\n {Name} casts Frost Ray! It slows the enemy down a little!"); }
            else { enemy.SpeedLost += croll; Console.WriteLine($"\n {Name} casts Time Dialation! It slows the enemy down a lot!"); }

           
            Speed = 2;
            Concentration = false;
        }

        public void Concentrate()
        {
            Console.WriteLine($"\n {Name} is Concentrating on his next move!");
            Concentration = true;
            Speed = 4;
        }

        public void WildMagic()
        {
            
            if(!Concentration)
            {
                Console.WriteLine($"\n {Name} Casts Wild Magic Without Concentration");
                if (rnd.Next(0,4) == 3) 
                {
                    Dodged = true;
                    WildMagicRoll();
                }
                else
                {
                    Console.WriteLine("Nothing Happens!");
                }
            }

            else
            {
                Concentration = false;
                Console.WriteLine($"\n {Name} Casts Wild Magic With Concentration");
                if (rnd.Next(0,4) >= 2)
                {
                    Console.WriteLine($"It Works!");
                    Dodged = true;
                    WildMagicRoll();
                }
                else
                {
                    Console.WriteLine("Nothing Happens!");
                }
            }

            Speed = 2;
            
        }

        public void WildMagicRoll()
        {
           int roll =  rnd.Next(0,3);

            if(roll == 0) { SpeedGained += 3; Console.WriteLine($"Gained 3 Speed!"); }
            if(roll == 1) { Concentration = true; Console.WriteLine($"Gained Concentration!"); }
            if(roll == 2) { HealthGained += roll; Console.WriteLine($"Gained {roll} Health!"); }
        }

        public void Describe()
        {
           
            
            Console.WriteLine($"\n {Name}'s Health - {Health}");
        }

        public void EndRound()
        {
            if(!Dodged)
            {
                if (Math.Clamp(HealthLost - DamageNegated, 0, 10) > 0)
                {
                    Console.WriteLine($"\n {Name} took {Math.Clamp(HealthLost - DamageNegated, 0, 10)} damage!");
                    
                }

                Health = (Health - Math.Clamp(HealthLost - DamageNegated, 0, 10) + HealthGained);
                Speed = (Speed -  SpeedLost + SpeedGained);

                if(Math.Clamp(HealthLost - DamageNegated, 0, 10) + HealthGained != 0)
                {
                    Describe();
                }
            }
            else
            {
                Console.WriteLine($"{Name} dodged!");
                Health += HealthGained;
                Speed += SpeedGained;

                if (Math.Clamp(HealthLost - DamageNegated, 0, 10) + HealthGained != 0)
                {
                    Describe();
                }
            }
            

            HealthGained = 0;
            HealthLost = 0;
            DamageNegated = 0;
            SpeedLost = 0;
            SpeedGained = 0;
            Dodged = false;
            


        }

    }
}
