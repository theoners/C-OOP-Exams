using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public class Tank:BaseMachine, ITank
    {
        private const int InitialHealth = 100;
        private const int AttackPoint = 40;
        private const int DefensePoint = 30;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints- AttackPoint, defensePoints+ DefensePoint, InitialHealth)
        {
            this.DefenseMode = true;
        }


        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.AttackPoints += AttackPoint;
                this.DefensePoints -= DefensePoint;
                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints -= AttackPoint;
                this.DefensePoints += DefensePoint;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            var defenseMode = this.DefenseMode
                ? "ON"
                : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {defenseMode}";
        }
    }
}
