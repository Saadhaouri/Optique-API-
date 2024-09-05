using Core.Application.Interface.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Optique_Domaine.Entities;

public class CategoryRepository : ICategoryRepository
{
    private readonly OpDbContext _context;

    public CategoryRepository(OpDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(Guid categoryId)
    {
        return await _context.Categories.FindAsync(categoryId) ?? throw new InvalidOperationException("category not found ");
    }

    public async Task InsertAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        return await _context.Produits
                             .Where(p => p.CategoryID == categoryId)
                             .ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}