namespace LogicProduct
{
    public class NumberProduct
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
