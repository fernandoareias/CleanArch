


using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces {
    public interface ICategoryService {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int id);

        Task Create(CategoryDTO model);
        Task<CategoryDTO> Update(CategoryDTO model);
        Task Remove(int? id);
    }
}