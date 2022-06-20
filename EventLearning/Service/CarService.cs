using CarDesignPatternExample.DbContext;
using CarDesignPatternExample.Model;

namespace CarDesignPatternExample.Service
{
    class CarService : ICar
    {
        private readonly DbContextData dbContextData;

        public CarService(DbContextData dbContextData)
        {
            this.dbContextData = dbContextData ?? throw new ArgumentNullException(nameof(dbContextData));
        }

        public async Task<bool> AddCar(Car? car)
        {
            return await Task.FromResult(dbContextData.CreateCar(car));
        }

        async Task<IReadOnlyCollection<Car>> ICar.GetCarsAsync()
        {
            return await Task.FromResult(dbContextData.GetCars());
        }
    }
}