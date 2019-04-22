using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Pilots
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.machines = new List<IMachine>();
            this.Name = name;
        }
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }

        }
        public void AddMachine(IMachine machine)
        {
            if (machine==null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            machines.Add(machine);
        }

        public string Report()
        {

            var pilotInfo = new StringBuilder();
            pilotInfo.AppendLine($"{this.name} - {machines.Count} machines");
            foreach (var machine in machines)
            {
                var fighterInfo = new StringBuilder();
                fighterInfo.AppendLine($"- {machine.Name}");
                fighterInfo.AppendLine($" *Type: {machine.GetType().Name}");
                fighterInfo.AppendLine($" *Health: {machine.HealthPoints:F2}");
                fighterInfo.AppendLine($" *Attack: {machine.AttackPoints:F2}");
                fighterInfo.AppendLine($" *Defense: {machine.DefensePoints:F2}");
                fighterInfo.AppendLine(!machine.Targets.Any()
                    ? $" *Targets: None"
                    : $" *Targets: {string.Join(",", machine.Targets)}");
                pilotInfo.AppendLine(fighterInfo.ToString().TrimEnd());

            }

            return pilotInfo.ToString().TrimEnd();
        }
    }
}
