using EcommerceBlazor.Model;

namespace EcommerceBlazor.Repository.IRepository;

public interface ICategoryRepo
{
    public Task<List<Category>> GetCategories();
    public Task<Category> GetCategoryById(int id);
    
    public Task AddCategory(Category category);
    
    public Task  UpdateCategory(Category category);
    
    public Task DeleteCategory(int id);
    
}