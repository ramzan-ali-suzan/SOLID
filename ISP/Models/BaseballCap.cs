using ISP.Interfaces;

namespace ISP.Models
{
    public class BaseballCap : IProduct, IHat
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public int HatSize { get; set; }
    }
}
