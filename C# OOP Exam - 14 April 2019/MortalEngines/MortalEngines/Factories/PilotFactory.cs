using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Pilots;

namespace MortalEngines.Factories
{
   public class PilotFactory
    {
        public IPilot HirePilot(string name)
        {
            var pilot = new Pilot(name);

            return pilot;
        }
    }
}
