using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReturnOrderPortal.DataContext;
using ReturnOrderPortal.Models;

namespace ReturnOrderPortal.Controllers
{

    public class UserController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserController));
        static string TokenForLogin;
        private readonly ProcessContext db;
        static ProcessResponse Response = new ProcessResponse();


        public UserController(ProcessContext context)
        {
            db = context;
        }

        public IActionResult Login()
        {
            _log4net.Info("Login initiated");
            var user = new User();
            return View("Login", user);
        }

        public ActionResult Authentication(User user)
        {
            _log4net.Info("Authentication initiated");
            TokenForLogin = GetToken("http://localhost:65486/api/token", user);
            if (TokenForLogin == null)
            {
                ViewBag.Message = String.Format("Invalid Username Or Password");
                return View("Login", user);
            }
            //return Content("Login Successful");
            var ComponentModel = new Component();
            return View("ComponentProcessing");
        }




        /*public dynamic ComponentProcessing(Component component)
        {
            return Content("hjgj");
        }*/
        /*public ActionResult ComponentProcessing(Component component)
         {
             string Results;

                 var Components = new Component()
                 {
                     Name = component.Name,
                     ContactNumber = component.ContactNumber,
                     CreditCardNumber = component.CreditCardNumber,
                     ComponentType = component.ComponentType,
                     ComponentName = component.ComponentName,
                     Quantity = component.Quantity,
                     IsPriorityRequest = component.IsPriorityRequest
                 };
                 var json = JsonConvert.SerializeObject(Components);
                 var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
             using var client = new HttpClient();
             var url = "";
             var response = await client.PostAsync(url, Components);

                 //var myContent = JsonConvert.SerializeObject(Components);
                 //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                 //var byteContent = new ByteArrayContent(buffer);
                 //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // client.BaseAddress = new Uri("http://localhost:.../");
              //   client.DefaultRequestHeaders.Accept.Clear();
                 //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 //HttpResponseMessage response = client.GetAsync(string.Format("api/ComponentProcessingMicroservice/ComponentType={0}&Quantity={1}" , Request.ComponentType,Request.Quantity)).Result;
                 //HttpResponseMessage response =  client.PostAsync("api/ComponentProcessingMicroservice/", component ).Result;


                 if (response.IsSuccessStatusCode)
                 {
                     Results = response.Content.ReadAsStringAsync().Result;
                 }
                 else
                     Results = null;

             List<string> Response = JsonConvert.DeserializeObject<List<string>>(Results) ;
             return View("ProcessResponse");

         }*/

        public async Task<ActionResult> ComponentProcessing(Component component)
        {
            _log4net.Info("ComponentProcessingMicroservice initiated");
            string Results;
            using (var client = new HttpClient())
            {
                Component components = new Component
                {
                    Name = component.Name,
                    ContactNumber = component.ContactNumber,
                    CreditCardNumber = component.CreditCardNumber,
                    ComponentType = component.ComponentType,
                    ComponentName = component.ComponentName,
                    Quantity = component.Quantity,
                    IsPriorityRequest = component.IsPriorityRequest
                };

                // client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenForLogin);
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var myJSON = JsonConvert.SerializeObject(components);


                string uri = string.Format("https://localhost:44392/api/ComponentProcessingMicroservice?json={0}", myJSON);

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Results = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Results = null;
                }
            }
             Response = JsonConvert.DeserializeObject<ProcessResponse>(Results);
            /* ProcessResponse Response = new ProcessResponse
             {
                 RequestId = 1,
                 PackagingAndDeliveryCharge = 10,
                 ProcessingCharge = 9,
                 DateOfDelivery = Convert.ToDateTime("10/01/2011")
             };*/
            
            return View("ProcessResponse", Response);


        }




        /*public ActionResult ComponentProcessing(Component component)
         {
             string Results;
             HttpClient client = new HttpClient();
             Uri baseAddress = new Uri("http://localhost:2939/");
             client.BaseAddress = baseAddress;

             JArray paramList = new JArray();
             Component components = new Component {
                 Name = component.Name,
                 ContactNumber = component.ContactNumber,
                 CreditCardNumber = component.CreditCardNumber,
                 ComponentType = component.ComponentType,
                 ComponentName = component.ComponentName,
                 Quantity = component.Quantity,
                 IsPriorityRequest = component.IsPriorityRequest
             };


             paramList.Add(JsonConvert.SerializeObject(components));


             HttpResponseMessage response = client.PostAsJsonAsync("api/ComponentProcessingMicroservice/", paramList).Result;
             if (response.IsSuccessStatusCode)
             {
                 Results = response.Content.ReadAsStringAsync().Result;
             }
             else
             {
                 Results = null;
             }
             List<string> Response = JsonConvert.DeserializeObject<List<string>>(Results);
             return View("ProcessResponse");
         }*/




        /* public async Task<ActionResult> Confirmation()
         {
             _log4net.Info("Payment Confirmation initiated");
             string confirm = "true";
             dynamic details = "";
             var abc = JsonConvert.SerializeObject(confirm);
             var data = new StringContent(abc, Encoding.UTF8, "application/json");

             using (var client = new HttpClient())
             {

                 HttpResponseMessage response = await client.GetAsync(string.Format("https://localhost:44346/api/ComponentProcessingMicroservice/True?message={0}", confirm));
                // var response = await client.PostAsync("https://localhost:44346/api/ComponentProcessingMicroservice", data);

                 string name = response.Content.ReadAsStringAsync().Result;


             }
             string x = (string)details;
             if (x == "Success")
                 return View("Confirmation");
             else
                 return View("Failed");

         }*/
        public async Task<ActionResult> Confirmation()
        {
            _log4net.Info("Payment Confirmation initiated");
            Submission res = new Submission()
            {
                Result = "True"
            };
            string name = "";
            //string confirm = "true";
            dynamic details = "";
            var abc = JsonConvert.SerializeObject(res);
            var data = new StringContent(abc, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {


                var response = await client.PostAsync("https://localhost:44392/api/ComponentProcessingMicroservice", data);

                name = response.Content.ReadAsStringAsync().Result;


            }
            string x = (string)name;
            if (x == "Success")
            {
                db.ProcessDb.Add(Response);
                db.SaveChanges();
                return View("Confirmation");
            }
            else
                return View("Failed");

        }

        /*public async Task<ActionResult> Confirmation()
        {
            /*var confirm = "True";
            string Results;
            using (var client = new HttpClient())
            {
                string uri = string.Format("https://localhost:44346/api/ComponentProcessingMicroservice?json={0}", confirm );
                HttpResponseMessage response = await client.GetAsync(uri);
                
                if (response.IsSuccessStatusCode)
                {
                    Results = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Results = null;
                }
            }
            // var Response = JsonConvert.DeserializeObject<ProcessResponse>(Results);
            //ProcessResponse Response = new ProcessResponse
            {
                RequestId = 1,
                PackagingAndDeliveryCharge = 10,
                ProcessingCharge = 9,
                DateOfDelivery = Convert.ToDateTime("10/01/2011")
            };
            return View("Confirmation");


        }*/




        static string GetToken(string url, User user)
        {
            //var user = new User { Name = "admin" , Password = "admin"};
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
