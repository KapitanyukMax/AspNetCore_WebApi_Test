using BusinessLogic.ApiModels.Products;
using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public ProductsService(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CreateProductModel model)
        {
            _context.Products.Add(_mapper.Map<Product>(model));
            _context.SaveChanges();
        }

        public void Edit(EditProductModel model)
        {
            _context.Products.Update(_mapper.Map<Product>(model));
            _context.SaveChanges();
        }

        public void Delete(int modelId)
        {
            var model = _context.Products.Find(modelId);

            if (model == null)
                return;

            _context.Products.Remove(model);
            _context.SaveChanges();
        }

        public List<ProductDto> Get()
        {
            return _mapper.Map<List<ProductDto>>(_context.Products.Include(p => p.Category).ToList());
        }

        public ProductDto? Get(int modelId)
        {
            var model = _context.Products.Find(modelId);

            if (model == null)
                return null;

            return _mapper.Map<ProductDto>(model);
        }
    }
}
