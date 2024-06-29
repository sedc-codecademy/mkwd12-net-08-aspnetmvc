using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess.EFImplementations
{
    public class UserEFRepository : IRepository<User>
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public UserEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }

        public void DeleteById(int id)
        {
           var userDb = _pizzaAppDbContext.Users.FirstOrDefault(x => x.Id == id); 

            if (userDb == null) {
                throw new Exception($"User with id {id} does not exist");
            }

            _pizzaAppDbContext.Users.Remove(userDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _pizzaAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _pizzaAppDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            _pizzaAppDbContext.Users.Add(entity);
            _pizzaAppDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(User entity)
        {
           _pizzaAppDbContext.Update(entity);
           _pizzaAppDbContext.SaveChanges();
        }
    }
}
