using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVVM_Product_search.Models
{
    public class TrainingProduct
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product Name must be filled in.")]
        [Display(Description ="Product Name")]
        [StringLength(150, MinimumLength =4, ErrorMessage ="Product Name must be greated than {2} characters and less than {1}.")]        
        public string ProductName { get; set; }

        [Range(typeof(DateTimeOffset), "1/1/2000", "12/31/2030", ErrorMessage ="Introduction Date must be between {1} and {2}.")]
        [Display(Description = "Introduction Date")]
        public DateTimeOffset IntroductionDate { get; set; }

        [Required(ErrorMessage = "Url must be filled in.")]
        [StringLength(2000, MinimumLength =5, ErrorMessage = "Product Name must be greated than {2} characters and less than {1}")]
        [Display(Description = "URL")] public string Url { get; set; }

        [Display(Description = "Price")]
        [Range(1, 100000, ErrorMessage ="{0} must be between {1} and {2}.")]
        public decimal Price { get; set; }



    }
}