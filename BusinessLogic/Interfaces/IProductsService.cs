using BusinessLogic.ApiModels.Products;
using BusinessLogic.Dtos;

namespace BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        void Create(CreateProductModel model);

        void Edit(EditProductModel model);

        void Delete(int modelId);

        List<ProductDto> Get();

        ProductDto? Get(int modelId);
    }
}
