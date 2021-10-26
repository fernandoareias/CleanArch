



using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services {

    public class ProductService : IProductService
    {
         private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Create(ProductDTO productDTO)
        {
            var entity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(entity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var entity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var entity = await _productRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(entity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var entity =  _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(entity);
        }

        
    }
}