namespace CarDesignPatternExample.Model
{
    internal abstract class Vehicle
    {
        abstract public string Name { get; set; }
        abstract public string Description { get; set; }
        abstract public string Model { get; set; }
        abstract public int Year { get; set; }
        abstract public decimal Price { get; set; }
    }
}