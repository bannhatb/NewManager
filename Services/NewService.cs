using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsManager.Models;

namespace NewsManager.Services
{
    
    public class NewService : INewService
    {
        private readonly DataContext _dataContext;

        public NewService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(New n)
        {
            _dataContext.News.Add(n);
            _dataContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var existed = GetNewById(Id);
            if(existed == null) return;
            _dataContext.News.Remove(existed);
            _dataContext.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _dataContext.Categories.ToList();
        }

        public New GetNewById(int Id)
        {
            return _dataContext.News.FirstOrDefault(n => n.Id == Id);
        }

        public List<New> GetNews()
        {
            return _dataContext.News.Include(p => p.Category).ToList();
        }

        public void Update(New n)
        {
            var existed = GetNewById(n.Id);
            if(existed == null) return;
            existed.Title = n.Title;
            existed.Avatar = n.Avatar;
            existed.Slug = n.Slug;
            existed.CategoryId = n.CategoryId;
            existed.Content = n.Content;
            existed.Summary = n.Summary;
            _dataContext.News.Update(existed);
            _dataContext.SaveChanges();
        }
    }
}