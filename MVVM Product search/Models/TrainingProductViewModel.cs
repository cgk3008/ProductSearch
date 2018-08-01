using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVVM_Product_search.Models
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            EventCommand = "List";
        }

        public string EventCommand { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        public void HandleRequest()
        {

            switch (EventCommand.ToLower())
            {
                case "list":
                    Get();
                    break;

                case "search":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                default:
                    break;
            }

        }
        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }


        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);
        }

    }
}