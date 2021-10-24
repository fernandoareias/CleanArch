using System;
using Xunit;
using FluentAssertions;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProductWithValidParameters()
        {
            Action action = ()=> new Product(1, "Product Name", "This is description", 28.00m, 3, "https://link.com.br");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }
          [Fact]
        public void CreateProductWithImageEmpty()
        {
            Action action = ()=> new Product(1, "Product Name", "This is description", 28.00m, 3, "");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProductWithImageNull()
        {
            Action action = ()=> new Product(1, "Product Name", "This is description", 28.00m, 3, null);
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void NotCreateProductWithInValidParameters()
        {
            Action action = ()=> new Product(-1, "a", "a", 0m, 0, "");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact]
        public void NotCreateProductWithIdInvalid()
        {
            Action action = ()=> new Product(-1, "Product Name", "This is description", 28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Id value");
        }


        [Fact]
        public void NotCreateProductWithNameIsShort()
        {
            Action action = ()=> new Product(1, "a", "This is description", 28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name, too short, minimum 3 characteres.");
        }

        [Fact]
        public void NotCreateProductWithNameNull()
        {
            Action action = ()=> new Product(1, null, "This is description", 28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name!");
        }


        [Fact]
        public void NotCreateProductWithNameEmpty()
        {
            Action action = ()=> new Product(1, "", "This is description", 28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name!");
        }


         [Fact]
        public void NotCreateProductWithDescriptionIsShort()
        {
            Action action = ()=> new Product(1, "Product Name", "ab", 28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid description, too short, minimum 5 characteres.");
        }

        [Fact]
        public void NotCreateProductWithDescriptionIsNull()
        {
            Action action = ()=> new Product(1, "Product Name", null, 28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid description!");
        }


        [Fact]
        public void NotCreateProductWithDescriptionIsEmpty()
        {
            Action action = ()=> new Product(1, "Product Name", "", 28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid description!");
        }


        [Fact]
        public void CreateProductWithImageIsNullShouldNoDomainException()
        {
            Action action = ()=> new Product(1, "Product Name", "Description Product", 28.00m, 3, null);
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateProductWithImageIsNullShouldNoNullReferenceException()
        {
            Action action = ()=> new Product(1, "Product Name", "Description Product", 28.00m, 3, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void NotCreateProductWithPriceIsInvalid()
        {
            Action action = ()=> new Product(1, "Product Name", "Description Product", -28.00m, 3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid price value!");
        }

        [Fact]
        public void NotCreateProductWithStockIsInvalid()
        {
            Action action = ()=> new Product(1, "Product Name", "Description Product", 28.00m, -3, "https://link.com.br");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid stock value!");
        }

    }
}
