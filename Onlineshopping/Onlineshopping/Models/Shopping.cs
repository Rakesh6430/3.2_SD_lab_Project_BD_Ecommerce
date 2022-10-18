using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onlineshopping.Models
{
    public class Shopping
    {

        public int shippingdetailid { get; set; }
        [Required]
        public Nullable<int> memberid { get; set; }
        [Required]
        public string adress { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string zipcode { get; set; }
        
        public Nullable<int> orderid { get; set; }
       
        public Nullable<decimal> amountpaid { get; set; }
        [Required]
        public string paymenttype { get; set; }

    }
}