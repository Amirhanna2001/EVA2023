using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetCategories();
        Task<Category> Add(Category category);
        Task<Category> GetCategory(int id);

        Category Update(Category category);
        Category Delete(Category category);
    }
}
