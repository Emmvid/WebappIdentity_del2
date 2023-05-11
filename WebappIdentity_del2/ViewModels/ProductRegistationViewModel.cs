﻿using System.ComponentModel.DataAnnotations;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.ViewModels;

public class ProductRegistationViewModel
{
    public string ArticleNumber { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Tagline { get; set; }
    public string? Description { get; set; }
    public HashSet<ProductCategoryEntity>? Categories { get; set; }



    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }

    public static implicit operator ProductEntity(ProductRegistationViewModel viewModel)
    {
        var entity = new ProductEntity
        {
            ArticleNumber = viewModel.ArticleNumber,
            ProductName = viewModel.ProductName,
            Price = viewModel.Price,
            Tagline = viewModel.Tagline,
            Description = viewModel.Description,
            Categories = viewModel.Categories,
           
        };
        //Kontrollerar om bilden finns, och skapar själva namnet för bilden
        if (viewModel.Image != null)
        {
            entity.ImageUrl = $"{viewModel.ArticleNumber}_{viewModel.Image?.FileName}";
        }
        return entity;
    }
    
}