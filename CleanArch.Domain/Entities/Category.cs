

using System.Collections.Generic;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities {
    public sealed class Category : Entity{
        public Category(string name) => ValidateDomain(name);

        public Category(int id, string name) : base(id)
        {
            ValidateDomain(name);
        }

        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public void Update(string name) => ValidateDomain(name);
        private void ValidateDomain(string name){
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characteres.");


            this.Name = name;

        }

        

    }
}