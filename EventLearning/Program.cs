using CarDesignPatternExample.Model;
using CarDesignPatternExample.Service;

namespace CarDesignPatternExample
{
    internal class Program
    {
        private static ICar? _car;

        static void Main()
        {
            var car = new CarService(new DbContext.DbContextData());

            _car = car;

            AddCar();

            Console.WriteLine("*** Loading database ***");

            Thread.Sleep(4000);

            Console.Clear();

            Console.WriteLine("{***}- - - Car List - - -{***}\n\n");

            var result = GetCarsAsync().Result;

            if (result != null)
            {
                foreach (var item in GetCarsAsync().Result)
                    Console.WriteLine(item);
            }

            Console.WriteLine("{***}- - - End of list - - -{***}\n\n");

            Console.ReadKey();
        }

        private static async Task<IReadOnlyCollection<Car>?> GetCarsAsync()
        {
            try
            {
                if (_car != null)
                    return await Task.FromResult(_car.GetCarsAsync()).Result;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async void AddCar()
        {
            try
            {
                int count = 0;

                do
                {
                    var garageCarCount = await GetCarsAsync();

                    Console.WriteLine("\nTee's Exotic Cars\n\n");
                    Console.WriteLine("===> Add New car:" +
                                      $"\n===> Count: {garageCarCount.Count}\n\n");

                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Description: ");
                    var desc = Console.ReadLine();

                    Console.Write("Model: ");
                    var model = Console.ReadLine();

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) &&
                        !string.IsNullOrEmpty(desc) && !string.IsNullOrWhiteSpace(desc) &&
                        !string.IsNullOrEmpty(model) && !string.IsNullOrWhiteSpace(model))
                    {
                        Console.Write("Year: ");
                        var yearFormatIsValid = int.TryParse(Console.ReadLine(), out int year);

                        if (yearFormatIsValid)
                        {
                            Console.Write("Price: ");
                            var priceFormatIsValid = decimal.TryParse(Console.ReadLine(), out decimal price);

                            if (priceFormatIsValid)
                            {
                                var carBuilder = new CarBuilder(string.Empty, string.Empty, string.Empty, 0, 0.0m);

                                var carObj = carBuilder.WithName(name)
                                                          .WithDescription(desc)
                                                          .WithModel(model)
                                                          .WithYear(year)
                                                          .WithPrice(price)
                                                          .Build();

                                if (carObj != null)
                                {
                                    var result = await _car.AddCar(carObj);

                                    if (result)
                                    {
                                        Console.WriteLine($"Message: {carObj.Name} has been added to the database!\n\n");
                                        count++;
                                    }
                                    else
                                        Console.WriteLine($"Message: Failed to add {carObj.Name} to the database!");
                                }

                                Console.Clear();
                            }
                        }
                    }

                    Console.Clear();

                } while (count < 3);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}