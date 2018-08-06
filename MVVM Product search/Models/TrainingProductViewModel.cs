using PTCCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVVM_Product_search.Models
{
    public class TrainingProductViewModel : ViewModelBase
    {
        public TrainingProductViewModel() : base()
        {
            

       

        }

        public TrainingProduct Entity { get; set; }       
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
        }


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

                case "edit":
                    //System.Diagnostics.Debugger.Break(); used this code to stop and lok at code and inspect web page
                    IsValid = true;
                    Edit();


                    break;

                case "delete":                    
                    ResetSearch();
                    Delete();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "add":
                    Add();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                default:
                    break;
            }

        }

        private void Save()
        {

            TrainingProductManager mgr = new TrainingProductManager();
            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)           
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }

        }

        private void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);
            Get();
            ListMode();
        }

      

        private void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTimeOffset.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            AddMode();
        }

        private void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }


        private void Edit()
        {           
            TrainingProductManager mgr = new TrainingProductManager();

            Entity = mgr.Get(Convert.ToInt32(EventArgument));         

            EditMode();
        }
        private void EditMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
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