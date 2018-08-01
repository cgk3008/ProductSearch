using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVVM_Product_search.Models
{
    public class TrainingProductManager
    {
public List<TrainingProduct> Get()
            {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret = CreateMockData();

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