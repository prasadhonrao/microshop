using Microshop.Models;

namespace Microshop.Repositories;

public class MockCategoryRepository : ICategoryRepository
{
    public Task<Category> CreateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        // Mock data
        var categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "Electronic gadgets"
            },
            new Category
            {
                Id = 2,
                Name = "Clothing",
                Description = "Clothing items"
            },
            new Category
            {
                Id = 3,
                Name = "Books",
                Description = "Books"
            }
        };

        return Task.FromResult(categories.AsEnumerable());
    }

    public Task<Category> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
