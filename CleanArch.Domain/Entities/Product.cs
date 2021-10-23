


using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities {
    public class Product : Entity{
        public Product(string name, string description, decimal price, int stock, string image) 
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image) : base(id)
        {              
            ValidateDomain(name, description, price, stock, image);
        }

        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image){
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description!");

            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characteres.");

            DomainExceptionValidation.When(image?.Length >250, "Invalid description, too long, maximmum 250 characteres.");    
        
            DomainExceptionValidation.When(price < 0, "Invalid price value!");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value!");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
        

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
           
        }




    }
}