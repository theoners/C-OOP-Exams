using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public abstract class BaseMachine:IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            Name = name;
           this.HealthPoints = healthPoints;
           this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }

        }
        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value.Name==null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target==null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            this.Targets.Add(target.Name);
            if (target.DefensePoints<this.AttackPoints)
            {
                target.HealthPoints -= (this.AttackPoints - target.DefensePoints);
            }

            if (target.HealthPoints<0)
            {
                target.HealthPoints = 0;
            }
        }

        public override string ToString()
        {
            var fighterInfo = new StringBuilder();
            fighterInfo.AppendLine($"- {this.Name}");
            fighterInfo.AppendLine($" *Type: {this.GetType().Name}");
            fighterInfo.AppendLine($" *Health: {this.HealthPoints:F2}");
            fighterInfo.AppendLine($" *Attack: {this.AttackPoints:F2}");
            fighterInfo.AppendLine($" *Defense: {this.DefensePoints:F2}");
            fighterInfo.AppendLine(!this.Targets.Any()
                ? $" *Targets: None"
                : $" *Targets: {string.Join(",", Targets)}");

            return fighterInfo.ToString().TrimEnd();
        }
    }
}
