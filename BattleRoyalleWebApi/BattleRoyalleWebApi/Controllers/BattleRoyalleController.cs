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
        public static List<Maquina> maquinas = new List<Maquina>();

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
                var maq = maquinas.Find(m => m.IpLocal == maquina.IpLocal);
                if (maq == null)
                    maquinas.Add(maquina);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> comandos = new List<string>();

        [HttpPost]
        [Route("api/BattleRoyalle/PostComandos")]
        public bool PostComandos([FromBody] string comando)
        {
            try
            {
                comandos.Add(comando);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        [Route("api/BattleRoyalle/getcomando")]
        public string GetComando()
        {
            if(comandos.Count > 0)
                return comandos[comandos.Count - 1];
            return "";
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
