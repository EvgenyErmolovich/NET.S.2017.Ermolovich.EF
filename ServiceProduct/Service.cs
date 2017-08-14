using LogicProduct;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Service
    {
        /// <summary>
        /// context
        /// </summary>
        private readonly DbContext context;
        /// <summary>
        /// c-or
        /// </summary>
        /// <param name="context"></param>
        public Service(DbContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            this.context = context;
        }
        /// <summary>
        /// gets all products
        /// </summary>
        /// <returns>all products</returns>
        public IEnumerable<Product> GetAllProducts() => context.Set<Product>().Select(p => p);
        public Purchase GetPurchaseById(int id) => context.Set<Purchase>().Find(id);
        public void AddPurchase(Purchase purchase, params NumberProduct[] NumberProduct)
        {
            if (purchase == null) throw new ArgumentNullException($"{nameof(purchase)} is null");
            if (NumberProduct == null) throw new ArgumentNullException($"{nameof(NumberProduct)} is null");
            foreach (var i in NumberProduct)
            {
                context.Set<NumberProduct>().Add(i);
            }
            context.Set<Purchase>().Add(purchase);
            context.SaveChanges();
        }
        /// <summary>
        /// adding product
        /// </summary>
        /// <param name="product">new product</param>
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException($"{nameof(product)} is null");
            if (context.Set<Product>().Where(p => p.Name == product.Name).Count() != 0) throw new InvalidOperationException("There is this product!");
            context.Set<Product>().Add(product);
            context.SaveChanges();
        }
        /// <summary>
        /// getting product
        /// </summary>
        /// <param name="name">name of product</param>
        /// <returns>product</returns>
        public Product GetProductByName(string name)
        {
            if (name == null) throw new ArgumentNullException($"{nameof(name)} is null");
            return context.Set<Product>().FirstOrDefault(p => p.Name == name);
        }
        /// <summary>
        /// updating bd by cost of product
        /// </summary>
        /// <param name="product">product</param>
        /// <param name="newCost">new cost</param>
        public void UpdateProduct(Product product, decimal newCost)
        {
            if (product == null) throw new ArgumentNullException($"{nameof(product)} is null");
            if (newCost <= 0 && newCost >= 100) throw new ArgumentException($"{nameof(newCost)} is invalid");
            if (context.Set<Product>().Where(p => p.Name == product.Name).Count() == 0) throw new InvalidOperationException("There isn't this product!");
            Product productUpd = GetProductByName(product.Name);
            productUpd.Cost = newCost;
            context.SaveChanges();
        }
        /// <summary>
        /// Deleteting Product
        /// </summary>
        /// <param name="product">product</param>
        public void DeleteProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException($"{nameof(product)} is null");
            if (context.Set<Product>().Where(p => p.Name == product.Name).Count() == 0) throw new InvalidOperationException("There isn't this product!");
            context.Set<Product>().Remove(GetProductByName(product.Name));
            context.SaveChanges();
        }
        /// <summary>
        /// getting all purchases
        /// </summary>
        /// <returns>sequence of purchases</returns>
        public IEnumerable<Purchase> GetAllPurchases() => context.Set<Purchase>().Select(p => p);
    }
}
