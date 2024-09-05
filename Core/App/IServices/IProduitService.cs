using Core.App.Dto.ProductDTO;

namespace Core.App.IServices;

public interface IProduitService
{
    IEnumerable<ProductDto> GetAllProducts();
    ProductDto GetProductById(Guid id);
    void CreateProduct(CreateUpdateProductDto productDto);
    void UpdateProduct(Guid id, CreateUpdateProductDto productDto);
    void DeleteProduct(Guid id);
}
