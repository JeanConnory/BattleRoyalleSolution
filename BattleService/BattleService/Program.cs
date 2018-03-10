using BattleService.Job;
using System;
using System.Threading;
using Topshelf;

namespace BattleService
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ws = HostFactory.Run(configurator =>
            {
                configurator.Service<BattleJobService>(settings =>
                {
                    settings.ConstructUsing(service => new BattleJobService());
                    settings.WhenStarted((service, control) => service.Start(control));
                    settings.WhenStopped((service, control) => service.Stop(control));
                });
                configurator.RunAsLocalSystem();
                configurator.AfterInstall(AfterInstall);
                configurator.SetDescription("Serviço para enviar informações da máquina");
                configurator.SetServiceName("BattleService");
                configurator.SetDisplayName("Battle Service");
            });
        }

        private static void AfterInstall()
        {
            Console.WriteLine("Serviço instalado");
        }

    }

}
