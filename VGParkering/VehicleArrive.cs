using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGParkering
{
    //Metod för skapandet av fordons object, fordonen läggs i en lista 
    internal class VehicleArrive
    {
        private static readonly Random rnd = new Random();
        private static readonly string[] VehicleType = { "Bil", "Buss", "Mc" };
        private static readonly string[] Colors = { "Röd", "Blå", "Grön", "Gul", "Lila", "Orange", "Svart", "Vit", "Rosa", "Brun" };
        private static readonly string[] Makes = { "Harley-Davidson", "Yamaha", "Honda", "Kawasaki", "Suzuki", "Ducati", "BMW", "Triumph" };

        public void GetVehicle(List<IVehicle> vehicles)
        {
            string regNum = GetReg();
            string color = Colors[rnd.Next(Colors.Length)];
            string type = VehicleType[rnd.Next(VehicleType.Length)];

            switch (type)
            {
                case "Bil":
                    bool isElectric = rnd.Next(2) == 1;
                    vehicles.Add(new Car(regNum, color, 0, isElectric));
                    break;
                case "Buss":
                    int passengers = rnd.Next(60);
                    vehicles.Add(new Bus(regNum, color, 0, passengers));
                    break;
                case "Mc":
                    string mcMake = Makes[rnd.Next(Makes.Length)];
                    vehicles.Add(new Mc(regNum, color, 0, mcMake));
                    break;
            }
        }
        private string GetReg()
        {
            string letters = new string(Enumerable.Range(0, 3).Select(_ => (char)rnd.Next('A', 'Z' + 1)).ToArray());
            string numbers = new string(Enumerable.Range(0, 3).Select(_ => (char)rnd.Next('0', '9' + 1)).ToArray());
            return letters + numbers;
        }
    }
}
