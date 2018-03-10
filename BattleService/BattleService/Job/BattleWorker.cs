using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BattleService.Job
{
    public class BattleWorker : WorkerBase
    {
        public const string WORKERSERVICE = "Battle Service";
        public MachineService machineService;
        public BattleWorker()
        {
            machineService = new MachineService();
        }

        protected override async Task DoWork()
        {
            try
            {
                Console.WriteLine($"Informando que job está rodando as {DateTime.Now}");
                var machine = machineService.GetInformationMachine();
                Console.WriteLine(machine.Nome + "  " + machine.IpLocal + "  " + machine.VersaoNet + "  " + machine.VersaoWindows + "  " + machine.AtivirusInstalado);
                machineService.EnviarParaApi(machine);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível informar que o job está rodando - Exception => {e.Message}");
            }
        }
    }
}
