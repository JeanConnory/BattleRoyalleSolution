using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleRoyalleApp.Models
{
    public class Maquina
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "IP")]
        public string IpLocal { get; set; }

        [Display(Name = "Tem Antivírus")]
        public bool AtivirusInstalado { get; set; }

        [Display(Name = "Tem Firewall")]
        public bool FirewallInstalado { get; set; }

        [Display(Name = "Versão do Windows")]
        public string VersaoWindows { get; set; }

        [Display(Name = "Versão do .NET")]
        public string  VersaoNet { get; set; }

        [Display(Name = "Tamanho do HD")]
        public decimal TamanhoHD { get; set; }

        [Display(Name = "Espaço Disponível")]
        public decimal DisponivelHD { get; set; }
    }
}