using System;

namespace ISP
{
    public class BaseballCap : IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize 
        { 
            get => throw new Exception("Not needed"); 
            set => throw new Exception("Not needed"); 
        }
        public int Inseam 
        { 
            get => throw new Exception("Not needed"); 
            set => throw new Exception("Not needed"); 
        }
        public int HatSize { get; set; }
    }
}
