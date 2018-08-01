using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVVM_Product_search.Models
{
    public class TrainingProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTimeOffset IntroductionDate { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }



    }
}