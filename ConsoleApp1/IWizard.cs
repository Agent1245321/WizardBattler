using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IWizard
    {
        public int Health { get; }
        public string Name { get; }
        public int Speed { get; }
        public int HealthLost { get; }

        public bool Concentration { get; }

        //public void Attack();
        //deals 1-3 damage concentrate(2 - 6)
        public void Defend();
        // negates 2-3 damage, concentrate(all)
        public void Dodge();
        // 50%  chance to negate all damage and speeds up user concentrate (75%)
        public void Concentrate();
        //increases stats for other spells
       // public void Hinder();
        //slows enemy down 1-3 Concentrate(2-6)
        public void WildMagic();
        //25% Chance of success concentrate(%50), if successful, negates all damage and or effects, and then random selects 1 of the three,
        //speed,
        //health,
        //concentration

    }
}
