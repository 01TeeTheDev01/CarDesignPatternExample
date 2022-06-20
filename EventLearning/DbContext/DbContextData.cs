using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarDesignPatternExample.Model;

namespace CarDesignPatternExample.DbContext
{
    internal class DbContextData
    {
        private List<Car> CarsList { get; set; }


        public DbContextData()
        {
            CarsList = new List<Car>();
        }


        internal List<Car>? GetCars()
        {
            try
            {
                if (CarsList != null)
                    return CarsList;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal bool CreateCar(Car? car)
        {
            try
            {
                if (car != null && CarsList != null)
                {
                    CarsList.Add(car);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
