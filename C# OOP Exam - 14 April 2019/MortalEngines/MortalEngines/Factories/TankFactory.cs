using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;

namespace MortalEngines.Factories
{
    public class TankFactory
    {
        public ITank CreateTank(string name, double attackPoints, double defensePoints)
        {
            var tank = new Tank(name, attackPoints, defensePoints);
            return tank;
        }
    }
}
