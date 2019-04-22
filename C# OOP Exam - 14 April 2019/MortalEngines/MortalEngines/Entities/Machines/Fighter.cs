using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
   public class Fighter  :BaseMachine, IFighter
    {
        private const int InitialHealth = 200;
        private const int attackPoint = 50;
        private const int defensePoint = 25;
        public Fighter(string name, double attackPoints, double defensePoints) :
            base(name, attackPoints+attackPoint, defensePoints-defensePoint, InitialHealth)
        {
            this.AggressiveMode = true;

        }


        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                this.AttackPoints -= attackPoint;
                this.DefensePoints += defensePoint;
                this.AggressiveMode = false;
            }
            else
            {
                this.AttackPoints += attackPoint;
                this.DefensePoints -= defensePoint;
                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            var aggressiveMode = this.AggressiveMode 
                ? "ON"
                :"OFF";

            return base.ToString()+Environment.NewLine+ $" *Aggressive: {aggressiveMode}";
        }
    }
}
