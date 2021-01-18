using ISP.Interfaces;

namespace ISP.Models
{
    public class Jeans : IProduct, IPants
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
    }
}
