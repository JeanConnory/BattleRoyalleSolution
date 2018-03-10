using BattleService.Model;
using RestSharp;
using System;
using System.Management;
using System.Net;
using System.Net.Sockets;

namespace BattleService
{
    public class MachineService
    {
        public bool AntiVirusInstalado()
        {
            var wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter";
            try
            {
                var searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                return instances.Count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private string getHostName() => Dns.GetHostName();

        private string getIp()
        {
            var name = Dns.GetHostName();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "";
        }

        private string getWindowsVersion()
        {
            return Environment.OSVersion.VersionString;
        }

        private string getNetVersion()
        {
            return Environment.Version.ToString();
        }

        public Machine GetInformationMachine()
        {
            var machine = new Machine();
            machine.IpLocal = getIp();
            machine.Nome = getHostName();
            machine.AtivirusInstalado = AntiVirusInstalado();
            machine.VersaoWindows = getWindowsVersion();
            machine.VersaoNet = getNetVersion();
            return machine;
        }

        public void EnviarParaApi(Machine machine)
        {
            var client = new RestClient("http://localhost:60246");
            var request = new RestRequest("/api/BattleRoyalle", Method.POST);
            request.AddJsonBody(machine);
            client.Execute(request);
        }
    }
}
