using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReturnOrderPortal.Models;

namespace ReturnOrderPortal.Controllers
{
    public class UserController : Controller
    {
        string TokenForLogin;
        public IActionResult Login()
        {
            var user = new User();
            return View("Login",user);
        }

        public ActionResult Authentication(User user)
        {
            TokenForLogin = GetToken("https://localhost:44375/api/token", user);
            if (TokenForLogin == null)
                return Unauthorized();

            //return Content("Login Successful");
            var ComponentModel = new Component();
            return View("ComponentProcessing",ComponentModel);
        }

       /* [HttpPost("{menuItemid}")]
        public Component Post(Component component)
        {

            var Components = new Component()
            {
                Name = component.Name,
                ContactNumber = component.ContactNumber,
                CreditCardNumber = component.CreditCardNumber,
                ComponentType = component.ComponentType,
                ComponentName = component.ComponentName,
                Quantity = component.Quantity,
                IsPriorityRequest = component.IsPriorityRequest

                menuItemName = getname(menuItemid, token)
            };
            return cart;
        }

        private string getname(int menuItemid, string token)
        {
            string name;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://52.154.173.160/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/string"));
                HttpResponseMessage response = client.GetAsync("api/MenuItem/" + menuItemid).Result;
                if (response.IsSuccessStatusCode)
                {
                    name = response.Content.ReadAsStringAsync().Result;
                }
                else
                    name = null;
            }
            return name;
        }*/

        public ActionResult ComponentProcessing(Component Request)
        {
            string Result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:.../");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/string"));
                HttpResponseMessage response = client.GetAsync("api/ComponentProcessingMicroservice/?ComponentType" + Request.ComponentType).Result;

                if (response.IsSuccessStatusCode)
                {
                    Result = response.Content.ReadAsStringAsync().Result;
                }
                else
                    Result = null;
            }
            List<string> Response = JsonConvert.DeserializeObject<List<string>>(Result) ;
            return View("ProcessResponse") ;

        }

        static string GetToken(string url,User user)
        {
            //var user = new User { Name = "admin" , Password = "admin"};
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using ( var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
