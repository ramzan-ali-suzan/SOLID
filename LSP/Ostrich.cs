using System;

namespace LSP
{
    public class Ostrich : Bird
    {
        public override void Fly()
        {
            throw new Exception("Ostrich can't fly!");
        }
    }
}
