using E_CommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Services
{
    public class CategoryServices:ICategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return (await _context.Categories.ToListAsync());
        }
        public async Task<Category> Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();
            return category;
        }
        public  async  Task<Category> GetCategory(int id)
            =>await _context.Categories.FindAsync(id);    
        

        public Category Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges() ;
            return category;
        }
        public Category Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }

        
    }
}
