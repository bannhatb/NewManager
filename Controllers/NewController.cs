using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsManager.Models;
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

        public IActionResult Add()
        {
            List<Category> categories = _newService.GetCategories();
            return View(categories);
        }
        public IActionResult Update(int id) 
        {
            New? n = _newService.GetNewById(id);
            ViewBag.Categories = _newService.GetCategories();
            return View(n);
        }

        public IActionResult Save(New n) 
        {
            var existed = _newService.GetNewById(n.Id);
            if(existed == null)
            {
                _newService.Add(n);
            }
            else
            {
                _newService.Update(n);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _newService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}