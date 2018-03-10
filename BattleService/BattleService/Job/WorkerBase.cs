using System;
using System.Threading.Tasks;

namespace BattleService.Job
{
    public abstract class WorkerBase
    {
        protected const int DELAY_PADRAO = 10000;
        
        public void Start() => Task.Run(() => DoLoop());

        protected abstract Task DoWork();
        
        private async Task DoLoop()
        {
            while (true)
            {
                try
                {
                    await DoWork();
                }
                catch (Exception)
                {
                    throw;
                }
                await Task.Delay(DELAY_PADRAO);
            }
        }
    }
}
