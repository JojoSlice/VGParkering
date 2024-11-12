using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGParkering
{
    //Meny metod
    internal class CheckOut
    {
        public void Menu(Parking parking, double pricePerMinute)
        {
            Console.WriteLine("Tryck 'C' för att checka ut ett fordon.\nTryck valfri tangent för att fortsätta vänta.\nTryck 'Q' för att avsluta.");
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.C:
                    Console.WriteLine("Skriv in Registreringsnumret ¨på fordonet som lämnar.");
                    string regNumLeaving = Console.ReadLine();
                    parking.UnparkVehicle(regNumLeaving, pricePerMinute);
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
