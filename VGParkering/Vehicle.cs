using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGParkering
{
    interface IVehicle
    {
        string RegNum { get; set; }
        string Color { get; set; }
        double TimeParked { get; set; }
    }
    class Car : IVehicle 
    {
        public string RegNum { get; set; }
        public string Color { get; set; }
        public double TimeParked { get; set; }
        public bool Electric { get; set; }
        public Car(string regNum,string color, double timeParked, bool electric)
        {
            RegNum = regNum;
            Color = color;
            TimeParked = timeParked;
            Electric = electric;
        }
    }

    class Bus : IVehicle
    {
        public string RegNum { get; set; }
        public string Color { get; set; }
        public double TimeParked { get; set; }
        public int Passengers { get; set; }
        public Bus(string regNum,string color, double timeParked, int passengers) 
        {
            RegNum = regNum;
            Color = color;
            TimeParked = timeParked;
            Passengers = passengers; 
        }
    }
    class Mc : IVehicle
    {
        public string RegNum { get; set; }
        public string Color { get; set; }
        public double TimeParked { get; set; }
        public string Make { get; set; }
        public Mc(string regNum,string color, double timeParked, string make)
        {
            RegNum = regNum;
            Color = color;
            TimeParked = timeParked;
            Make = make;
        }
    }
}
