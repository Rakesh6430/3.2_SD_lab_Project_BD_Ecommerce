using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onlineshopping.Models
{
    public class Categorydetail
    {
        public int categoryid { get; set; }
        [Required(ErrorMessage ="Category Name Required")]
        [StringLength(100,ErrorMessage = "minimum 3 and minimum 3 and maximum 100 charecter are allowed",MinimumLength =3)]
        public string categoryName { get; set; }
        public Nullable<bool> Isactive { get; set; }
        public Nullable<bool> Isdelete { get; set; }
    }
    public class productdetail
    {
        public int Productid { get; set; }

        [Required(ErrorMessage = "Product Name Required")]

        [StringLength(100, ErrorMessage = "minimum 3 and minimum 3 and maximum 100 charecter are allowed", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required]
        [Range(1,50)]
        public Nullable<int> categoryid { get; set; }
        public Nullable<bool> Isactive { get; set; }
        public Nullable<bool> Isdelete { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
        public Nullable<System.DateTime> modifieddate { get; set; }
        [Required(ErrorMessage = "Description is  Required")]
        public Nullable<System.DateTime> description { get; set; }
        public string productimage { get; set; }
        public Nullable<bool> Isfeatured { get; set; }
        [Required]
        [Range(typeof(int),"1","500",ErrorMessage ="Invalid Quatity")]
        public Nullable<int> quantity { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "Invalid Price")]
        public Nullable<decimal> price { get; set; }

        public SelectList categories { get; set; }

    }

        
}