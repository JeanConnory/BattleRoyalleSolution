using BattleRoyalleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BattleRoyalleWebApi.Controllers
{
    public class BattleRoyalleController : ApiController
    {
        public static List<Maquina> maquinas = new List<Maquina>
        {
            new Maquina { Id = 1, Nome = "Maquina 1", IpLocal = "127.0.0.1", AtivirusInstalado = true, FirewallInstalado = true,
                VersaoWindows = "10", VersaoNet = "4.5", TamanhoHD = 750, DisponivelHD = 520 },

            new Maquina { Id = 2, Nome = "Maquina 2", IpLocal = "127.0.0.2", AtivirusInstalado = true, FirewallInstalado = false,
                VersaoWindows = "8", VersaoNet = "4.5", TamanhoHD = 750, DisponivelHD = 520 },

            new Maquina { Id = 3, Nome = "Maquina 3", IpLocal = "127.0.0.3", AtivirusInstalado = false, FirewallInstalado = false,
                VersaoWindows = "7", VersaoNet = "4.5", TamanhoHD = 1000, DisponivelHD = 250 },
        };

        [HttpGet]
        public List<Maquina> GetMaquina()
        {
            return maquinas;
        }

        [HttpGet]
        public Maquina GetMaquina(int id)
        {
            return maquinas.Find(m => m.Id == id);
        }

        [HttpPost]
        public bool PostMaquina(Maquina maquina)
        {
            try
            {
                maquinas.Add(maquina);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMaquina(int id)
        {
            try
            {
                var maquina = maquinas.Find(m => m.Id == id);
                maquinas.Remove(maquina);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
