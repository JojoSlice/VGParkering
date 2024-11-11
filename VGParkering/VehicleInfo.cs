using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGParkering
{
    //En Generisk metod för att skriva ut info om fordon
    internal class VehicleInfo
    {
        public string Info<T>(T objVariable)
        {
            string regNum = string.Empty;
            string color = string.Empty;
            string info = string.Empty;
            int width = 10;

            if (objVariable is Car)
            {
                regNum = (objVariable as Car).RegNum;
                color = (objVariable as Car).Color;
                string drive = (objVariable as Car).Electric ? "Elbil" : "Bensindriven";
                info = $"{"Bil".PadRight(width)} {regNum.PadRight(width)} {color.PadRight(width)} {drive}";
            }
            if (objVariable is Bus)
            {
                regNum = (objVariable as Bus).RegNum;
                color = (objVariable as Bus).Color;
                int passengers = (objVariable as Bus).Passengers;
                info = $"{"Buss".PadRight(width)} {regNum.PadRight(width)} {color.PadRight(width)} {passengers}";
            }
            if (objVariable is Mc)
            {
                regNum = (objVariable as Mc).RegNum;
                color = (objVariable as Mc).Color;
                string make = (objVariable as Mc).Make;
                info = $"{"Mc".PadRight(width)} {regNum.PadRight(width)} {color.PadRight(width)} {make}";
            }
               return info;
        }
    }
}
