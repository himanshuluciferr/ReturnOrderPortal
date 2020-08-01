﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
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

      


        public dynamic ComponentProcessing(Component component)
        {
            return component;
        }
       /* public ActionResult ComponentProcessing(Component component)
        {
            string Results;
            using (var client = new HttpClient())
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
                };
                //var json = JsonConvert.SerializeObject(Components);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                //var myContent = JsonConvert.SerializeObject(Components);
                //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                //var byteContent = new ByteArrayContent(buffer);
                //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.BaseAddress = new Uri("http://localhost:.../");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage response = client.GetAsync(string.Format("api/ComponentProcessingMicroservice/ComponentType={0}&Quantity={1}" , Request.ComponentType,Request.Quantity)).Result;
                HttpResponseMessage response =  client.GetAsync("api/ComponentProcessingMicroservice/", component , new JsonMediaTypeFormatter()).Result;


                if (response.IsSuccessStatusCode)
                {
                    Results = response.Content.ReadAsStringAsync().Result;
                }
                else
                    Results = null;
            }
            List<string> Response = JsonConvert.DeserializeObject<List<string>>(Results) ;
            return View("ProcessResponse");

        }*/

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
