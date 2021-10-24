


using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Repositories {
    public class ProductRepository : IProductRepository {

        private ApplicationDbContext _contextProduct;
        public ProductRepository(ApplicationDbContext context)
        {
            _contextProduct = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _contextProduct.Add(product);
            await _contextProduct.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _contextProduct.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetCategoriesAsync()
        {
            return await _contextProduct.Products.ToListAsync();
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _contextProduct.Products.Include(c => c.Category).FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _contextProduct.Remove(product);
            await _contextProduct.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _contextProduct.Update(product);
            await _contextProduct.SaveChangesAsync();
            return product;
        }
    }
}