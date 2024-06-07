using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    static class StaticDb
    {
        public static Restaurant Restaurant = new Restaurant() { 
            Id = 1,
            Name = "Kaj Slave",
            Menu = new List<MenuItem>
            {
                new MenuItem()
                {
                    Id = 1,
                    Name = "10ka",
                    Description = "10 kebapi",
                    Price = 200
                },new MenuItem()
                {
                    Id = 2,
                    Name = "5ka",
                    Description = "5 kebapi",
                    Price = 100
                },new MenuItem()
                {
                    Id = 3,
                    Name = "Coca Cola",
                    Description = "Coca Cola 250ml",
                    Price = 70
                }
            }
        };

    }
}
