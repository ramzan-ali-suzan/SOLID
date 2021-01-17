namespace ISP
{
    public interface IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
        public int HatSize { get; set; }
    }
}
