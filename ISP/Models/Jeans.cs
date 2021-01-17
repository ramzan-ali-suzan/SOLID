using ISP.Interfaces;
using System;

namespace ISP.Models
{
    public class Jeans : IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
        public int HatSize
        {
            get => throw new Exception("Not needed");
            set => throw new Exception("Not needed");
        }
    }
}
