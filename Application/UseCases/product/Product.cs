using Application.InterfacesApplication;
using Application.InterfacesRepository;
using Domain.Entities;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.UseCases.product
{
    public class Product : IProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public Product(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDomain CreateProductDomain(int id, string name, string descripcion, string categoria, decimal precio, int cantidadInicial)
        {
            return new ProductDomain() {Id = id,  Name = name, Description = descripcion, Category = categoria, Price = precio, Stock = cantidadInicial };
        }

        public async Task<bool> CreateProduct(IProduct product)
        {
            //open/close principle and polymorphism
            var productExist = await _productRepository.GetProductByName(product.Name, 0,0);
            if (productExist != null) throw new ApplicationException("product exists");
            var result = await _productRepository.Create(product);
            if (result) return true;
            return false;
        }

        public async Task<IProduct> GetProduct(string name, int price1, int price2)
        {
            var productDomain = await _productRepository.GetProductByName(name, price1, price2);
            if (productDomain == null)
                return null;
            return productDomain;
        }

        public async Task<bool> UpdateProduct(IProduct product)
        {
            //open/close principle and polymorphism
            var productExist = await _productRepository.GetProductById(product.Id);
            if (productExist == null) throw new ApplicationException("product is not exists");
                productExist.Name = product.Name;
                productExist.Description = product.Description;
                productExist.Category = product.Category;
                productExist.Price = product.Price;
                productExist.Stock = product.Stock;
                    
            var result = await _productRepository.Update(productExist);
            if (result) return true;
            return false;
        }
        
        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _productRepository.Delete(id);
            if (result) return true;
            return false;
        }

        public async Task<List<IProduct>> GetProducts()
        {
            var productDomain = await _productRepository.GetProducts();
            if (productDomain == null)
                return null;
            return productDomain;
        }
    }
}
