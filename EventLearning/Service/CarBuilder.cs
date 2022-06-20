using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using CarDesignPatternExample.Model;

namespace CarDesignPatternExample.Service
{
    internal class CarBuilder
    {
        private readonly string Name, Description, Model;
        private readonly int Year;
        private readonly decimal Price;


        public CarBuilder(string name, string description, string model, int year, decimal price)
        {
            Name = name;
            Description = description;
            Model = model;
            Year = year;
            Price = price;
        }

        internal CarBuilder? WithName(string name)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
                return new CarBuilder(name, Description, Model, Year, Price);

            return null;
        }

        internal CarBuilder? WithDescription(string description)
        {
            if (!string.IsNullOrEmpty(description) && !string.IsNullOrWhiteSpace(description))
                return new CarBuilder(Name, description, Model, Year, Price);

            return null;
        }

        internal CarBuilder? WithModel(string model)
        {
            if (!string.IsNullOrEmpty(model) && !string.IsNullOrWhiteSpace(model))
                return new CarBuilder(Name, Description, model, Year, Price);

            return null;
        }

        internal CarBuilder? WithYear(int year)
        {
            if (year >= 1950 && year <= DateTime.Now.Year)
                return new CarBuilder(Name, Description, Model, year, Price);

            return null;
        }

        internal CarBuilder? WithPrice(decimal price)
        {
            if (price > 30_000m)
                return new CarBuilder(Name, Description, Model, Year, price);

            return null;
        }

        internal Car? Build()
        {
            var builtObject = new CarBuilder(Name, Description, Model, Year, Price);

            return new Car() { Name = builtObject.Name, Description = builtObject.Description, Model = builtObject.Model, Year = builtObject.Year, Price = builtObject.Price };
        }
    }
}
