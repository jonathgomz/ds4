using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab_19_3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public async Task<ActionResult> ConsumirID2()
        {
            string url = "https://localhost:44354/api/values/2"; 

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (s, cert, chain, sslErr) => true;

            using (var client = new HttpClient(handler))
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.resultado = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewBag.resultado = "Error: " + response.StatusCode;
                }
            }

            return View();
        }

    }
}
