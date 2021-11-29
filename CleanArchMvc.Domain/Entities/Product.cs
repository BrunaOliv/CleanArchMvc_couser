using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Descripition { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExcepetionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExcepetionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExcepetionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            DomainExcepetionValidation.When(string.IsNullOrEmpty(description), "Invalid name.Name is required");

            DomainExcepetionValidation.When(price < 0, "Invalid price value.");

            DomainExcepetionValidation.When(stock < 0, "Invalid stock value.");

            DomainExcepetionValidation.When(image?.Length > 250, "Invalid image, too long, maximum 250 characters");

            Name = name;
            Descripition = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
