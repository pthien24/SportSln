namespace SportStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDBContext context;
        public EFStoreRepository(StoreDBContext ctx) { context = ctx; }
        public IQueryable<Product> Products => context.Products;
        public void CreateProduct(Product product) { 
            context.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveProduct(Product p)
        {
            context.SaveChanges();
        }
    }
}
