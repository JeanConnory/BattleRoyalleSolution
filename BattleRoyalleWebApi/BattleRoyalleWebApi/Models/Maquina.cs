using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleRoyalleWebApi.Models
{
    public class Maquina
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string IpLocal { get; set; }

        public bool AtivirusInstalado { get; set; }

        public bool FirewallInstalado { get; set; }

        public string VersaoWindows { get; set; }

        public string VersaoNet { get; set; }

        public decimal TamanhoHD { get; set; }

        public decimal DisponivelHD { get; set; }
    }
}