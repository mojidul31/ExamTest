using ClientProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        string apiBaseUrl = string.Empty;

        public PersonController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }
        // GET: PersonController
        [HttpGet]
        public async Task<IActionResult> Index()
        {            
            List<PersonViewModel> personList = new List<PersonViewModel>();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/people";

                using (var response = await client.GetAsync(endpoint))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personList = JsonConvert.DeserializeObject<List<PersonViewModel>>(apiResponse);
                }
            }
            return View(personList);
        }


        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    PersonViewModel model = new PersonViewModel();
                    model.Name = collection["Name"].ToString();
                    model.PhoneNo = collection["PhoneNo"];
                    model.Email = collection["Email"].ToString();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + "/people";

                    using (var response = await client.PostAsync(endpoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            PersonViewModel person = new PersonViewModel();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/people/"+ id;

                using (var response = await client.GetAsync(endpoint))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    person = JsonConvert.DeserializeObject<PersonViewModel>(apiResponse);
                }
            }
            return View(person);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, IFormCollection collection)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    PersonViewModel model = new PersonViewModel();
                    model.Id = id;
                    model.Name = collection["Name"].ToString();
                    model.PhoneNo = collection["PhoneNo"];
                    model.Email = collection["Email"].ToString();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + "/people/"+ id;

                    using (var response = await client.PutAsync(endpoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View();
            }
            catch(Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            PersonViewModel person = new PersonViewModel();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/people/" + id;

                using (var response = await client.GetAsync(endpoint))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    person = JsonConvert.DeserializeObject<PersonViewModel>(apiResponse);
                }
            }
            return View(person);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string endpoint = apiBaseUrl + "/people/" + id;

                    using (var response = await client.DeleteAsync(endpoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
