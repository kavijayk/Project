using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHousingSolutions.Models
{
    public class MultipleModels
    {
        [Required]
        public Seller sellerModel { get; set; }
        [Required]
        public User userModel { get; set; }
        [Required]
        public State stateModel { get; set; }
        [Required]
        public City cityModel { get; set; }
        [Required]
        public Buyer buyerModel { get; set; }


    }
}