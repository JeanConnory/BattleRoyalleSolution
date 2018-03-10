using System;
using Topshelf;

namespace BattleService.Job
{
    public class BattleJobService : ServiceControl
    {
        private readonly BattleWorker battleWorker;

        public BattleJobService()
        {
            battleWorker = new BattleWorker();
        }

        public bool Start(HostControl hostControl)
        {
            battleWorker.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("Serviço finalizado");
            return true;
        }
    }
}
