using System;

namespace LSP
{
    public class Duck : FlyingBird
    {
        public override void Fly()
        {
            Console.WriteLine("Duck is flying...");
        }
    }
}
