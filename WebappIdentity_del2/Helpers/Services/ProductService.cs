using WebappIdentity_del2.Helpers.Repositories;
using WebappIdentity_del2.Models.Dtos;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Helpers.Services;

public class ProductService
{
    #region Constructors & PRIVATE FIELDS
    private readonly ProductRepository _productRepo;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(ProductRepository productRepo, IWebHostEnvironment webHostEnvironment)
    {
        _productRepo = productRepo;
        _webHostEnvironment = webHostEnvironment;
    }
    #endregion
    public async Task<Product> CreateAsync(ProductEntity entity)
    {
        var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
        if (_entity == null)
        {
            _entity = await _productRepo.AddAsync(entity);
            if (_entity != null)
                return _entity;

        }
        return null!;
    }

    public async Task<bool> UploadImageAsync(Product product, IFormFile image)
    {
        try { 
        //Gör så den hittar till själva mappen
        string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
        await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch
        {
            return false;
        }
        
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var items = await _productRepo.GetAllAsync();
        var list = new List<Product>();
        foreach (var item in items)
        {
            list.Add(item);
        }
        return list;
    }
}