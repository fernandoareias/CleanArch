using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands {
    public class ProductUpdateCommand : ProductCommand {
        public int Id { get; set; }
    }
}