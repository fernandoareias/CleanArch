



using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services {

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
         public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
         {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

         }
        public async Task Create(CategoryDTO model)
        {
            var entity = _mapper.Map<Category>(model);
            await _categoryRepository.Create(entity);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var categoriesEntity = await _categoryRepository.GetById(id);

            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntities = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntities);
        }

        public async Task Remove(int? id)
        {
            var entity = await _categoryRepository.GetById(id);
            await _categoryRepository.Remove(entity);
        }

        public async Task<CategoryDTO> Update(CategoryDTO model)
        {
            var entity = _mapper.Map<Category>(model);
            await _categoryRepository.Update(entity);

            return _mapper.Map<CategoryDTO>(entity);
        }
    }
}