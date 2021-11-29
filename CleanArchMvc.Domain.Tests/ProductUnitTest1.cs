using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WhithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>();
        }
        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>()
                .WithMessage("Invalid Id value");
        }
        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }
        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>()
                .WithMessage("Invalid name.Name is required");
        }
        [Fact]
        public void CreatProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>();
        }
        [Fact]
        public void CreatProduct_WithNegativePriceValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>()
                .WithMessage("Invalid price value.");
        }
        [Fact]
        public void CreatProduct_WithNegativeStockValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 99.9m, -99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>()
                .WithMessage("Invalid stock value.");
        }
        [Fact]
        public void CreatProduct_WithTooLongImageValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 99.9m, 99, "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>()
                .WithMessage("Invalid image, too long, maximum 250 characters");
        }
        [Fact]
        public void CreatProduct_EmptyImageValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 99.9m, 99, "");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>();
        }
        [Fact]
        public void CreatProduct_NullImageValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 99.9m, 99, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExcepetionValidation>();
        }
        [Fact]
        public void CreatProduct_NullImageNameValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 99.9m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }
    }
}
