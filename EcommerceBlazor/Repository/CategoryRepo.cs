using EcommerceBlazor.Data;
using EcommerceBlazor.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using EcommerceBlazor.Model;

namespace EcommerceBlazor.Repository;

public class CategoryRepo: ICategoryRepo
{

    private readonly AuthDbContext _authDbContext;
    public CategoryRepo(AuthDbContext authDbContext)
    {
        
        _authDbContext = authDbContext;
        
    }
    public async Task<List<Category>> GetCategories()
    {
        
        return await _authDbContext.Categories.ToListAsync();
    }

    public  async Task<Category> GetCategoryById(int id)
    {
        if (id != null) 
        {
        return await _authDbContext.Categories.FindAsync(id);
            
        }

        return null;
    }

    public async Task AddCategory(Category category)
    {
        if (category != null)
        {
            await _authDbContext.Categories.AddAsync(category);
            await _authDbContext.SaveChangesAsync();
            
        }
    }

    public async Task UpdateCategory(Category category)
    {
        
        
              var oldCategory = await _authDbContext.Categories.FindAsync(category.Id);
              
              oldCategory.Name = category.Name;
              if(oldCategory==null)
                  return;
              
         _authDbContext.Categories.Update(category);
          await _authDbContext.SaveChangesAsync();
        
    }

    public async Task DeleteCategory(int id)
    {
        var deletedCategory = await _authDbContext.Categories.FindAsync(id);

        if (deletedCategory != null)
        {
            _authDbContext.Categories.Remove(deletedCategory);
            await _authDbContext.SaveChangesAsync();
        }
        
    }
}