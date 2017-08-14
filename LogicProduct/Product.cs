namespace LogicProduct
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public byte Image { get; set; }
        public virtual TypeProduct Type { get; set; }
        public string Characteristic { get; set; }
    }
}
