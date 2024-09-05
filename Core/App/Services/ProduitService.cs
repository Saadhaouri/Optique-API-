using AutoMapper;
using Core.App.Dto.ProductDTO;
using Core.App.Interfaces;
using Core.App.IServices;
using Optique_Domaine.Entities;

public class ProduitService : IProduitService
{
    private readonly IProduitRepository _produitRepository;
    private readonly IMapper _mapper;

    public ProduitService(IProduitRepository produitRepository, IMapper mapper)
    {
        _produitRepository = produitRepository;
        _mapper = mapper;
    }

    public IEnumerable<ProductDto> GetAllProducts()
    {
        var products = _produitRepository.GetProduits();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public ProductDto GetProductById(Guid id)
    {
        var product = _produitRepository.GetProduitById(id);
        if (product == null)
            return null;

        return _mapper.Map<ProductDto>(product);
    }

    public void CreateProduct(CreateUpdateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _produitRepository.InsertProduit(product);
        _produitRepository.Save();
    }

    public void UpdateProduct(Guid id, CreateUpdateProductDto productDto)
    {
        var product = _produitRepository.GetProduitById(id);
        if (product == null)
            throw new ArgumentException("Product not found");

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;
        product.PriceForSale = productDto.PriceForSale;
        product.Quantity = productDto.Quantity;
        product.CategoryID = productDto.CategoryID;
        product.FournisseurId = productDto.FournisseurId;
        

        _produitRepository.Save();
    }

    public void DeleteProduct(Guid id)
    {
        var product = _produitRepository.GetProduitById(id);
        if (product == null)
            throw new ArgumentException("Product not found");

        _produitRepository.DeleteProduit(id);
        _produitRepository.Save();
    }
}
