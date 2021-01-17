namespace ISP
{
    public class BaseballCap : IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }
        public int Inseam 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }
        public int HatSize { get; set; }
    }
}
