using System;
using Xunit;
using FluentAssertions;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategoryWithValidParameters()
        {
            Action action = ()=> new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

         [Fact]
        public void CreateCategoryWithInvalidParametersShouldReturnException()
        {
            Action action = ()=> new Category(-1, null);
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

         [Fact]
        public void CreateCategoryWithIdInvalidShouldReturnException()
        {
            Action action = ()=> new Category(-1, null);
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategoryWithNameInvalidShouldReturnException()
        {
            Action action = ()=> new Category(1, "ba");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name, too short, minimum 3 characteres.");
        }

         [Fact]
        public void CreateCategoryWithNameIsNullShouldReturnException()
        {
            Action action = ()=> new Category(1, "");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name!");
        }
    }
}
