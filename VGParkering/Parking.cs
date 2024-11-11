using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGParkering
{
    //Hantering av parkering 
    internal class Parking
    {
        private List<IVehicle>[] ParkingSpot = new List<IVehicle>[15];
        private bool[] IsReserved = new bool[15];
        VehicleInfo vehicleInfo = new VehicleInfo();

        public Parking()
        {
            for (int i = 0; i < ParkingSpot.Length; i++)
            {
                ParkingSpot[i] = new List<IVehicle>();
                IsReserved[i] = false;
            }
        }

        //Kontrollerar om plats finns tillgänglig
        public int ParkVehicle(List<IVehicle> vehicles, int vehicleIndex)
        {
            IVehicle vehicle = vehicles[vehicleIndex];
            int requiredSpots = (vehicle is Bus) ? 2 : 1;

            for (int spot = 0; spot < ParkingSpot.Length; spot++)
            {
                if (vehicle is Mc && CanParkMotorcycleAtSpot(spot))
                {
                    ParkingSpot[spot].Add(vehicle);
                    return spot;
                }
                else if (!(vehicle is Mc) && CanParkAtSpot(spot, requiredSpots))
                {
                    for (int i = 0; i < requiredSpots; i++)
                    {
                        ParkingSpot[spot + i].Add(vehicle);
                        IsReserved[spot + i] = true;
                    }
                    return spot;
                }
            }
            return -1;
        }

        //Hanterar tillgänglighet för motorcykel
        private bool CanParkMotorcycleAtSpot(int spot)
        {
            return ParkingSpot[spot].Count < 2 && ParkingSpot[spot].All(v => v is Mc);
        }

        //Hanterar tillgänglighet för bil och buss
        private bool CanParkAtSpot(int startSpot, int requiredSpots)
        {
            if (startSpot + requiredSpots > ParkingSpot.Length)
                return false;

            for (int i = 0; i < requiredSpots; i++)
            {
                if (ParkingSpot[startSpot + i].Count != 0 || IsReserved[startSpot + i])
                    return false;
            }

            return true;
        }

        //Ritar ut parkeringen
        public void DrawParking(List<IVehicle> vehicles)
        {
            HashSet<IVehicle> displayedVehicles = new HashSet<IVehicle>();

            for (int spot = 0; spot < ParkingSpot.Length; spot++)
            {
                if (ParkingSpot[spot].Count == 0)
                {
                    Console.WriteLine($"Plats {spot + 1}: Tom");
                }
                else
                {
                    if (ParkingSpot[spot].Count > 1 && ParkingSpot[spot][0] is Mc)
                    {
                        foreach (var vehicle in ParkingSpot[spot])
                        {
                            Console.WriteLine($"Plats {spot + 1}: {vehicleInfo.Info(vehicle)} ");
                            displayedVehicles.Add(vehicle);
                        }
                    }
                    else
                    {
                        IVehicle vehicle = ParkingSpot[spot][0];

                        if (!displayedVehicles.Contains(vehicle))
                        {
                            int requiredSpots = vehicle is Bus ? 2 : 1;
                            int endSpot = spot + requiredSpots - 1;

                            if (requiredSpots > 1)
                            {
                                Console.WriteLine($"Plats {spot + 1} - {endSpot + 1}: {vehicleInfo.Info(vehicle)}");
                            }
                            else
                            {
                                Console.WriteLine($"Plats {spot + 1}: {vehicleInfo.Info(vehicle)}");
                            }

                            displayedVehicles.Add(vehicle);

                            spot = endSpot;
                        }
                    }
                }
            }
        }


        //Hantering av utchecking
        public bool UnparkVehicle(string regNumber, double pricePerMinute)
        {
            Console.WriteLine();
            for (int spot = 0; spot < ParkingSpot.Length; spot++)
            {
                var vehicle = ParkingSpot[spot].FirstOrDefault(v => v.RegNum == regNumber);
                if (vehicle != null)
                {
                    int requiredSpots = vehicle is Bus ? 2 : 1;

                    for (int i = 0; i < requiredSpots; i++)
                    {
                        ParkingSpot[spot + i].Remove(vehicle);
                        IsReserved[spot + i] = false;
                    }
                    Console.WriteLine($"Fordon med registreringsnummer {regNumber} har lämnat parkeringen.\nFöraren fick betala: {(vehicle.TimeParked * pricePerMinute)} kr.");
                    Console.ReadKey(true);
                    return true;
                }
            }
            Console.WriteLine($"Inget fordon med registreringsnummer {regNumber} hittades på parkeringen.");
            Console.ReadKey(true);
            return false;
        }
    }
}


