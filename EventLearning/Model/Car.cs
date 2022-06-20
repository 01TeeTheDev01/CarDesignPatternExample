namespace CarDesignPatternExample.Model
{
    class Car : Vehicle
    {
        public override string Name { get; set; } = string.Empty;
        public override string Description { get; set; } = string.Empty;
        public override string Model { get; set; } = string.Empty;
        public override int Year { get; set; } = 0;
        public override decimal Price { get; set; } = 0.0m;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}\n{nameof(Description)}: {Description}\n{nameof(Model)}: {Model}\n{nameof(Year)}: {Year}\n{nameof(Price)}: {Price:c2}\n\n";
        }
    }
}