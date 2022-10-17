using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsManager.Services;

namespace NewsManager.Controllers
{
    public class NewController : Controller
    {
        private readonly INewService _newService;

        public NewController(INewService newService)
        {
            _newService = newService;
        }

        public IActionResult Index()
        {
            var news = _newService.GetNews();
            return View(news);
        }
    }
}