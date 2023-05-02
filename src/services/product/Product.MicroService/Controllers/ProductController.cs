using AutoMapper;
using Product.MicroService.Entities;
using Product.MicroService.Repositories;
using Product.MicroService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Product.MicroService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductController> _logger;

    public ProductController(
        IProductRepository repository,
        IMapper mapper,
        ILogger<ProductController> logger
    )
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductReadModel>>> Get()
    {
        _logger.LogInformation("Getting all Products ...");
        var Products = await _repository.GetAllProducts();
        return Ok(_mapper.Map<IEnumerable<ProductReadModel>>(Products));
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<ActionResult<ProductReadModel>> GetById(int id)
    {
        _logger.LogInformation("Getting single Product data with id: " + id);
        var Product = await _repository.GetProductById(id);

        if (Product != null)
            return Ok(_mapper.Map<ProductReadModel>(Product));
        else
        {
            _logger.LogWarning($"No Product found with id: {id}");
            return NotFound("Product not found");
        }
    }

    [HttpPost]
    public ActionResult<ProductReadModel> Create(ProductCreateModel model)
    {
        _logger.LogInformation("Creating new Product ", model);

        var Product = _mapper.Map<ProductEntity>(model);

        _repository.AddProduct(Product);
        // _repository.SaveChanges();

        var addedProduct = _mapper.Map<ProductReadModel>(Product);
        return CreatedAtRoute(nameof(GetById), new { Id = addedProduct.ProductID }, addedProduct);
    }

    [HttpDelete("{id}")]
    public ActionResult<ProductReadModel> DeleteById(int id)
    {
        _logger.LogInformation("Delete single Product data with id: " + id);
        var Product = _repository.GetProductById(id);

        if (Product != null)
        {
            _repository.DeleteProduct(id);
            // _repository.SaveChanges();
            return Ok();
        }
        else
        {
            _logger.LogWarning($"No Product found with id: {id}");
            return NotFound("Product not found");
        }
    }
}