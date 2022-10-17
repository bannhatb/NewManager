using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsManager.Models;

namespace NewsManager.Services
{
    public interface INewService
    {
        List<New> GetNews();
        New? GetNewById(int Id);
        void Add(New n);
        void Update(New n);
        void Delete(int Id);
    }
}