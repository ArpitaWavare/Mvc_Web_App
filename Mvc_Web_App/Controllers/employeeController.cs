using Mvc_Web_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Mvc_Web_App.Models.employeeModel;

namespace Mvc_Web_App.Controllers
{
    public class employeeController : Controller
    {
        // GET: employee
        public ActionResult EmployeeIndex()
        {
            return View();
        }
        string apiurl = "https://localhost:44399//";
        public async Task<ActionResult> Getalldata()
        {
            List <employeeModel> employees = new List <employeeModel> ();
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(apiurl);
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
                HttpResponseMessage response = await Client.GetAsync("/api/Mvc_Web_Api");
                if (response.IsSuccessStatusCode)
                {
                    var serviceresponse = response.Content.ReadAsStringAsync().Result;
                    employees = JsonConvert.DeserializeObject<List<employeeModel>>(serviceresponse);
                }

            }
            return Json(employees, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Getpostal(int pincode)
        {
            List<PostOffModel> lstEmployees = new List<PostOffModel>();
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(apiurl);
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await Client.GetAsync($"pincode/{pincode}");

                if (response.IsSuccessStatusCode)
                {
                    var serviceResponse = await response.Content.ReadAsStringAsync();
                    lstEmployees = JsonConvert.DeserializeObject<List<PostOffModel>>(serviceResponse);
                }
            }
            return Json(lstEmployees, JsonRequestBehavior.AllowGet);
        }
    }
}


