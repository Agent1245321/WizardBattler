using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PyroMancer : Wizard, IWizard
    {
        Random rnd = new Random();
        public PyroMancer(string name)
        {
            Name = name;
            Console.WriteLine($"The Wizard {Name} was born");
            Health = 15;
            Speed = rnd.Next(1, 5);
            Console.WriteLine($"{Name} has {Health} health");
        }

        public void Firestorm(Wizard enemy)
        {

            int roll = rnd.Next(2, 4);

            enemy.HealthLost += roll; Console.WriteLine($"\n {Name} cast FIRESTORM! it deals {roll} damage!");

            Speed -= 3;


        }

        public void Burn(Wizard enemy)
        {
            enemy.BurnCount = rnd.Next(1, 5);
            Speed -= 1;

        }

        public void Smoke()
        {
            DamageNegated += 1;
        }

    }

}





