using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.DataAccess.Intefaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Implementations
{
    public class StatusRepository : IRepository<Status>
    {
        public IEnumerable<Status> GetAll()
        {
            return InMemoryDataBase.Statuses;
        }

        public Status GetById(int id)
        {
            return InMemoryDataBase.Statuses.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Status entity)
        {
            entity.Id = InMemoryDataBase.Statuses.Count + 1;
            InMemoryDataBase.Statuses.Add(entity);
        }

        public void Update(Status entity)
        {
            var status = GetById(entity.Id);
            if(status != null)
            {
                var statusIndex = InMemoryDataBase.Statuses.IndexOf(status);
                InMemoryDataBase.Statuses[statusIndex] = entity;
            }
        }
        public void Delete(int id)
        {
            var status = GetById(id);
            if(status != null)
            {
                InMemoryDataBase.Statuses.Remove(status);
            }
        }
    }
}
