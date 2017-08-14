using System.Collections.Generic;

namespace LogicProduct
{
    public class Purchase
    {
        public int Id { get; set; }
        public virtual List<NumberProduct> NumberProducts { get; set; }
    }
}
