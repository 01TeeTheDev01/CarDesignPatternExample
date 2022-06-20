using CarDesignPatternExample.Model;

namespace CarDesignPatternExample
{
    interface ICar
    { 
        Task<IReadOnlyCollection<Car>>? GetCarsAsync();
        Task<bool> AddCar(Car? car);
    }
}