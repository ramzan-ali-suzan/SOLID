using System;

namespace LSP.Models
{
    public class Duck : FlyingBird
    {
        public override void Fly()
        {
            Console.WriteLine("Duck is flying...");
        }
    }
}
