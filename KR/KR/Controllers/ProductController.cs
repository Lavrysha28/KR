using KR.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KR.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Smartphone", Description = "A modern smartphone", Price = 499.99M },
        new Product { Id = 2, Name = "Laptop", Description = "Powerful laptop for work and gaming", Price = 1299.99M },
    };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("addToCart/{id}")]
        public IActionResult AddToCart(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            // Додаємо товар до кошика
            var cartItem = new ShoppingCartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price
            };

            // Перевірка, чи кошик вже містить даний товар
            var existingItem = ShoppingCart.Items.FirstOrDefault(item => item.ProductId == cartItem.ProductId);
            if (existingItem != null)
            {
                existingItem.Price += cartItem.Price;
            }
            else
            {
                ShoppingCart.Items.Add(cartItem);
            }

            return Ok(ShoppingCart.Items);
        }
    }
}
