using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;

namespace MortalEngines.Factories
{
    public class FighterFactory
    {
        public IFighter CreateFighter(string name, double attackPoints, double defensePoints)
        {
            var fighter = new Fighter(name, attackPoints, defensePoints);
            return fighter;
        }
    }
}
