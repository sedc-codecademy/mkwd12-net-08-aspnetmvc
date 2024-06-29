using PizzaAppRefactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.ViewModels.OrderViewModels
{
    public class AddPizzaToOrderViewModel
    {
        public int OrderId { get; set; }

        [Display(Name ="Pizza")]
        public int PizzaId { get; set; }

        [Display(Name ="Pizza size")]
        public PizzaSizeEnum PizzaSize { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
