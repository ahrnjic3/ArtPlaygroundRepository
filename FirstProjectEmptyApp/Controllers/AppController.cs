using FirstProjectEmptyApp.Data;
using FirstProjectEmptyApp.Services;
using FirstProjectEmptyApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectEmptyApp.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IArtPlaygroundRepository _repository;

        public AppController(IMailService mailService, IArtPlaygroundRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
      
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact() {
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model) {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("amerhrnjo16@gmail.com", model.Subject, $"From:{model.Name} - {model.Email},Message: {model.Message}");
                ViewBag.UserMsg = "Mail Sent";
                ModelState.Clear();
            }
            else { 
                // show error
            }

            return View();

        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
        public IActionResult Shop() {
            var result = _repository.GetAllPRoducts();

            return View( result);
        }
    }
}
