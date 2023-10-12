namespace _12_10_23
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[]
            {
                new Car("CarFactory", "Sedan", "Red", 4.5, 300, 4, false),
                new Bicycle("BikeFactory", "Mountain Bike", "Blue", 2.0, 20, "Mountain"),
                new Car("CarFactory", "ElectricCar", "Silver", 5.0, 350, 4, true),
                new Bicycle("BikeFactory", "Road Bike", "Black", 1.5, 30, "Road"),
            };

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.GetInfo();
                Console.WriteLine("=================================");
            }
        }
    }

    internal abstract class Vehicle
    {
        public string FactoryName { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double DriveTime { get; set; }
        public double DrivePath { get; set; }
        public DateTime ProductionDate { get; }

        public Vehicle(string factoryName, string model, string color, double driveTime, double drivePath)
        {
            FactoryName = factoryName;
            Model = model;
            Color = color;
            DriveTime = driveTime;
            DrivePath = drivePath;
            ProductionDate = DateTime.Now;
        }

        public double AverageSpeed()
        {
            return DrivePath / DriveTime;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Factory Name: {FactoryName}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Drive Time: {DriveTime} hours");
            Console.WriteLine($"Drive Path: {DrivePath} km");
            Console.WriteLine($"Production Date: {ProductionDate}");
            Console.WriteLine($"Average Speed: {AverageSpeed()} km/h");
        }

        public abstract string DefineNatureHarmness();
    }

    internal class Car : Vehicle
    {
        public int DoorCount { get; set; }
        public bool IsElectricCar { get; set; }

        public Car(string factoryName, string model, string color, double driveTime, double drivePath, int doorCount, bool isElectricCar)
            : base(factoryName, model, color, driveTime, drivePath)
        {
            DoorCount = doorCount;
            IsElectricCar = isElectricCar;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Door Count: {DoorCount}");
            Console.WriteLine($"Electric Car: {IsElectricCar}");
            Console.WriteLine($"Nature Harmness: {DefineNatureHarmness()}");
        }

        public override string DefineNatureHarmness()
        {
            if (IsElectricCar)
            {
                return "Low";
            }
            else
            {
                return "High";
            }
        }
    }

    internal class Bicycle : Vehicle
    {
        public string Type { get; set; }

        public Bicycle(string factoryName, string model, string color, double driveTime, double drivePath, string type)
            : base(factoryName, model, color, driveTime, drivePath)
        {
            Type = type;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Bicycle Type: {Type}");
            Console.WriteLine($"Nature Harmness: {DefineNatureHarmness()}");
        }

        public override string DefineNatureHarmness()
        {
            return "None";
        }
    }
}