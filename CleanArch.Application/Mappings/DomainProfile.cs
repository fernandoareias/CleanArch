


using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings {
    public class DomainProfile : Profile {
        public DomainProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}