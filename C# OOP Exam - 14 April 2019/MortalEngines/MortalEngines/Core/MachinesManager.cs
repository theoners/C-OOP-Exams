using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;
using MortalEngines.Factories;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private PilotFactory pilotFactory;
        private TankFactory tankFactory;
        private FighterFactory fighterFactory;
        private IList<IPilot> pilots;
        private IList<IMachine> machines;
        private IList<string> machineName;
        private IList<string> pilotName;

        public MachinesManager()
        {
            this.pilotFactory= new PilotFactory();
            this.tankFactory= new TankFactory();
           
            this.fighterFactory= new FighterFactory();
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
            this.machineName= new List<string>();
            this.pilotName = new List<string>();
        }


        public string HirePilot(string name)
        {
            var pilot = pilotFactory.HirePilot(name);
            if (!pilotName.Contains(name))
            {
               pilotName.Add(name);
                pilots.Add(pilot);
                return string.Format(OutputMessages.PilotHired,name);
            }
            else
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = tankFactory.CreateTank(name,attackPoints,defensePoints);
            if (!machineName.Contains(name))
            {
                machineName.Add(name);
                machines.Add(tank);
                return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints,tank.DefensePoints);
            }
            else
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var fighter = fighterFactory.CreateFighter(name, attackPoints, defensePoints);
            if (!machineName.Contains(name))
            {
                machineName.Add(name);
                machines.Add(fighter);
                var aggressive = fighter.AggressiveMode ? "ON" : "OFF";
                return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints,aggressive);
            }
            else
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var currentPilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            if (currentPilot==null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            var currentMachine = machines.FirstOrDefault(x => x.Name == selectedMachineName);
            if (currentMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (currentMachine.Pilot!=null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready,currentMachine.Name);
            }

            currentMachine.Pilot = currentPilot;
            currentPilot.AddMachine(currentMachine);
            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine  = machines.FirstOrDefault(x => x.Name == defendingMachineName);
            if (attackingMachine==null || defendingMachine==null)
            {
                var name = attackingMachine == null ? attackingMachineName : defendingMachineName;
                return string.Format(OutputMessages.MachineNotFound, name);
            }

            if (attackingMachine.HealthPoints <=0 || defendingMachine.HealthPoints <=0)
            {
                var name = attackingMachine.HealthPoints <= 0 ? attackingMachineName :defendingMachineName;
                return string.Format(OutputMessages.DeadMachineCannotAttack, name);
            }
            attackingMachine.Attack(defendingMachine);
           
            
            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName,
                defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var currentPilot = pilots.FirstOrDefault(x => x.Name == pilotReporting);
            return currentPilot?.Report();
        }

        public string MachineReport(string machineName)
        {
            var currentMachine = machines.FirstOrDefault(x => x.Name == machineName);
            return currentMachine?.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var machine =(Fighter)machines.FirstOrDefault(x => x.Name == fighterName && x.GetType().Name=="Fighter");

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            
                machine.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);

           
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var machine = (Tank)machines.FirstOrDefault(x => x.Name == tankName && x.GetType().Name=="Tank");

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            machine.ToggleDefenseMode();
            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}