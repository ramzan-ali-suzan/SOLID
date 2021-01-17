namespace ISP
{
    public class Jeans : IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
        public int HatSize 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }
    }
}
