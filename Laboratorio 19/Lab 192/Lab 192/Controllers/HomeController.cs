using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;


namespace Lab_192.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "HomePage";
            return View();

        }

        
        public async Task<ActionResult> ConsumirAPI()
        {
            string url = "https://localhost:44354/api/values"; 

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                ViewBag.resultado = json;
            }

            return View();
        }
        
    }
}
