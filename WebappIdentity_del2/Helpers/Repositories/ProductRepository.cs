using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebappIdentity_del2.Context;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Helpers.Repositories;

public class ProductRepository : Repo<ProductEntity>
{
    private readonly ApplicationContext _context;
    public ProductRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.Include(x => x.Categories).ToListAsync();
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        return await _context.Products.Where(predicate).ToListAsync();
    }
}
