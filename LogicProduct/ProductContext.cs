using System.Data.Entity;

namespace LogicProduct
{
    public partial class ProductContext : DbContext
    {
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }
        public virtual DbSet<NumberProduct> NumberProducts { get; set; }
    }
}
