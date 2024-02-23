using Microshop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Microshop.Controllers;

public class ProductsController : Controller
{
    private readonly IProductRepository productRepository;
    private readonly ICategoryRepository categoryRepository;

    public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        this.productRepository = productRepository;
        this.categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Index()
    {
        var products = await productRepository.GetProductsAsync();
        return View(products);
    }
}
