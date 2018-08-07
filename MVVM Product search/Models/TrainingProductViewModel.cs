using PTCCommon;
using System;
using System.Collections.Generic;

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

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "CK":
                    break;

                default:
                    break;
            }

            base.HandleRequest();
        }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
        }


       

        protected override void Save()
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

            base.Save();
        }

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);
            Get();
            //ListMode();
            base.Delete();
        }      

        protected override void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTimeOffset.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            //AddMode();
            base.Add();
        }            

        protected override void Edit()
        {           
            TrainingProductManager mgr = new TrainingProductManager();

            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            //EditMode();
            base.Edit(); // could put this ahead of code above, depends on how you want view/data/buttons etc to load
        }
       

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();

            base.ResetSearch();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);

            base.Get();
        }

    }
}