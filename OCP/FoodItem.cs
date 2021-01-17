namespace OCP
{
    public abstract class FoodItem
    {
        public string Name { get; set; }

        public abstract void Prepare();
    }
}
