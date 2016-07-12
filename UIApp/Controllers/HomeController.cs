using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Newtonsoft.Json;
using System.Text;
using UIApp.Models;

namespace UIApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ackSample()
        {
            return View();
        }
        public ActionResult Sample()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SamplePost()
        {
            string[] Vehicle = ConfigurationManager.AppSettings["VehicleLocation"].Split('~').Select(s => s.Trim()).ToArray();
            for (int i = 0; i <= Vehicle.Length - 1; i++)
            {

                string vehicleparam = Vehicle[i].ToString();

                var Client = new HttpClient();
                //Client.BaseAddress = new Uri("http://localhost:64103/");
                Client.BaseAddress = new Uri("http://postapitest.azurewebsites.net/");
                string serurl = "api/Test/Insert?param=" + vehicleparam;
                var conresponse = Client.PostAsync(serurl,
                    new StringContent(JsonConvert.SerializeObject(vehicleparam).ToString(),
                        Encoding.UTF8, "application/json"));
                var res = conresponse.Result;

                if (res.IsSuccessStatusCode)
                {
                    dynamic concontent = JsonConvert.DeserializeObject(
                        res.Content.ReadAsStringAsync()
                        .Result);
                    TempData["content"] = concontent;
                    // Access variables from the returned JSON object
                    //var appHref = concontent.links.applications.href;
                }

            }
            return RedirectToAction("ackSample");

        }
    }
}