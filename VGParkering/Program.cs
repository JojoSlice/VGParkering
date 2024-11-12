namespace VGParkering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();
            VehicleInfo info = new VehicleInfo();
            VehicleArrive vehicleArrive = new VehicleArrive();
            Parking parking = new Parking();
            CheckOut checkOut = new CheckOut();
            Random rnd = new Random();

            int time = 0;
            const double pricePerMinute = 1.5;
            double earning = 0;

            while (true) 
            {
                double tottalPriceForAll = 0;

                Console.Clear();
                Console.WriteLine($"Den totala intäkten är: {earning} kr.");
                Console.WriteLine();
                Console.WriteLine($"Det har gått {time} minuter och en bil kommer.");
                Console.WriteLine();

                vehicleArrive.GetVehicle(vehicles);
                int vehicleIndex = vehicles.Count - 1;

                int spot = parking.ParkVehicle(vehicles, vehicleIndex);
                if (spot != -1)
                {
                    Console.WriteLine($"Fordon har parkerat på plats {spot + 1}: {info.Info(vehicles[vehicleIndex])}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ingen tom plats tillgänglig för fordonet.");
                    Console.WriteLine();
                }

                parking.DrawParking(vehicles);

                checkOut.Menu(parking, pricePerMinute);

                int elapsedTime = rnd.Next(50);
                time += elapsedTime;

                foreach (IVehicle vehicle in vehicles)
                {
                    vehicle.TimeParked += elapsedTime;
                    double costForVehicle = vehicle.TimeParked * pricePerMinute;
                    tottalPriceForAll += costForVehicle;
                }
                earning += tottalPriceForAll;
            }
        }
    }
}
