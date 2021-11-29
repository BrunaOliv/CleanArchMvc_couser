using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidationDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExcepetionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(name);
        }

        public void Update(string name)
        {
            ValidationDomain(name);
        }
        public ICollection<Product> Products { get; private set; }

        private void ValidationDomain(string name)
        {
            DomainExcepetionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExcepetionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecters");

            Name = name;
        }
    }
}
