

using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Repositories {
    public class CategoryRepository : ICategoryRepository
    {

        private  ApplicationDbContext _contextCategory;
        public CategoryRepository(ApplicationDbContext context)
        {
            _contextCategory = context;   
        }

        public async Task<Category> Create(Category category)
        {
            _contextCategory.Add(category);
            await _contextCategory.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetById(int? id)
        {
            return await _contextCategory.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _contextCategory.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            _contextCategory.Remove(category);
            await _contextCategory.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _contextCategory.Update(category);
            await _contextCategory.SaveChangesAsync();
            return category;
        }
    }
}