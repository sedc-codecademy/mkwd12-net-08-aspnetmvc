using DataAccess.Interfaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        public List<Restaurant> GetAll()
        {
            return new List<Restaurant> { StaticDb.Restaurant};
        }

        public Restaurant GetById(int id)
        {
            return StaticDb.Restaurant;
        }
        public void Delete(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
