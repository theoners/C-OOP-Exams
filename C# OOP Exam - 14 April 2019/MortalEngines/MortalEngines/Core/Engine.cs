using System;
using System.Linq;
using MortalEngines.Core.Contracts;

namespace MortalEngines.Core
{
    public class Engine:IEngine
    {
        public void Run()
        {
            var machineManager = new MachinesManager();
            var input = Console.ReadLine();
            while (input!="Quit")
            {
                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = inputArgs[0];
                var args = inputArgs.Skip(1).ToArray();
                var result = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                          result=  machineManager.HirePilot(args[0]);
                            break;
                        case "PilotReport":
                            result = machineManager.PilotReport(args[0]);
                            break;
                        case "ManufactureTank":
                            result = machineManager.ManufactureTank(args[0], double.Parse(args[1]), double.Parse(args[2]));
                            break;
                        case "ManufactureFighter":
                            result = machineManager.ManufactureFighter(args[0], double.Parse(args[1]), double.Parse(args[2]));
                            break;
                        case "MachineReport":
                            result = machineManager.MachineReport(args[0]);
                            break;
                        case "AggressiveMode":
                            result = machineManager.ToggleFighterAggressiveMode(args[0]);
                            break;
                        case "DefenseMode":
                            result = machineManager.ToggleTankDefenseMode(args[0]);
                            break;
                        case "Engage":
                            result = machineManager.EngageMachine(args[0], args[1]);
                            break;
                        case "Attack":
                            result = machineManager.AttackMachines(args[0], args[1]);
                            break;

                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:"+ ex.Message);
                }
             
                input = Console.ReadLine();
            }
        }
    }
}
