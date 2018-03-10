using BattleRoyalleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BattleRoyalleApp.Controllers
{
    public class MaquinaController : Controller
    {
        // GET: Maquina
        public async Task<ActionResult> Index()
        {
            List<Maquina> maquinas = new List<Maquina>();
            string Baseurl = "http://localhost:60246/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/BattleRoyalle");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    maquinas = JsonConvert.DeserializeObject<List<Maquina>>(EmpResponse);

                }
                
                return View(maquinas);
            }
        }
        // GET: Maquina/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Maquina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maquina/Create
        [HttpPost]
        public ActionResult Create(string maquina)
        {
            try
            {
                HttpClient client = new HttpClient();
                string uri = "api/BattleRoyalle";
                client.BaseAddress = new Uri("http://localhost:60246/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(uri, maquina).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maquina/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Maquina/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maquina/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Maquina/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
