using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVVM_Product_search.Models
{
    public class TrainingProductManager
    {

        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lower case."));
                }
            }
            return (ValidationErrors.Count == 0);
        }

        public TrainingProduct Get(int productId)
        {
            List<TrainingProduct> list = new List<TrainingProduct>();
            TrainingProduct ret = new TrainingProduct();

            //need to call data access method here
            list = CreateMockData();

            ret = list.Find(p => p.ProductId == productId);

            return ret;
        }

        public bool Update(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);

            if (ret)
            {
                //need  create update code here
            }
            return ret;

           
        }

        public bool Delete(TrainingProduct entity)
        {
            //Delete code here
            return true;
        }

        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if (ret)
            {
                //will add insert code
            }
            return ret;
        }


        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret = CreateMockData();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;
        }
        private List<TrainingProduct> CreateMockData()
        {

            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Truck straps",
                IntroductionDate = Convert.ToDateTime("5/15/2017"),
                Url = "http://bit.tly/234Nsi8",
                Price = Convert.ToDecimal(42.67)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 2,
                ProductName = "Car Engine Oil 10W/30",
                IntroductionDate = Convert.ToDateTime("2/4/2018"),
                Url = "http://bit.tly/278Nsi8",
                Price = Convert.ToDecimal(22.56)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 5,
                ProductName = "Floor Mats",
                IntroductionDate = Convert.ToDateTime("8/19/2016"),
                Url = "http://bit.tly/299934Nsi8",
                Price = Convert.ToDecimal(36.12)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 11,
                ProductName = "Car Wax",
                IntroductionDate = Convert.ToDateTime("3/27/2018"),
                Url = "http://bit.tly/11134Nsi8",
                Price = Convert.ToDecimal(18.99)
            });

            return ret;
        }
    }
}