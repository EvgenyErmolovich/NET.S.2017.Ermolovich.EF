using System.Collections.Generic;

namespace LogicProduct
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public virtual List<Product> products { get; set; }
    }
}
