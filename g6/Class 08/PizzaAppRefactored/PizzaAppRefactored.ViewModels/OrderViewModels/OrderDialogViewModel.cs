using PizzaAppRefactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.ViewModels.OrderViewModels
{
    public class OrderDialogViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; }

        [Display(Name ="Is order delivered")]
        public bool IsDelivered {  get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name ="Pizza store")]
        public string PizzaStore {  get; set; }

        [Display(Name ="User")]
        public int UserId { get; set; }
    }
}
