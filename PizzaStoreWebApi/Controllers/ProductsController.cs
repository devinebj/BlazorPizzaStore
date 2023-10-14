﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaStoreModels.ViewModels;
using StoreDatabase.Data;
using StoreDatabase.Entities;

namespace PizzaStoreWebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase {
		private readonly StoreContext _context;

		public ProductsController(StoreContext context) {
			_context = context;
		}

		// GET: api/Products
		[HttpGet(Name = "GetProducts")]
		public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts() {
			if (_context.Products == null) {
				return NotFound();
			}

			List<ProductViewModel> productViewModels = new List<ProductViewModel>();
			var products = await _context.Products.OrderBy(p => p.ProductId).ToListAsync();

			foreach (var product in products) {
				var productViewModel = new ProductViewModel {
					ProductId = product.ProductId,
					Name = product.ProductName,
					Price = product.ProductPrice
				};

				productViewModels.Add(productViewModel);
			}

			return productViewModels;
		}

		// GET: api/Products/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id) {
			if (_context.Products == null) {
				return NotFound();
			}
			var product = await _context.Products.FindAsync(id);

			if (product == null) {
				return NotFound();
			}

			return product;
		}

		// PUT: api/Products/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(int id, Product product) {
			if (id != product.ProductId) {
				return BadRequest();
			}

			_context.Entry(product).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!ProductExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Products
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Product>> PostProduct(Product product) {
			if (_context.Products == null) {
				return Problem("Entity set 'StoreContext.Products'  is null.");
			}
			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
		}

		// DELETE: api/Products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id) {
			if (_context.Products == null) {
				return NotFound();
			}
			var product = await _context.Products.FindAsync(id);
			if (product == null) {
				return NotFound();
			}

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ProductExists(int id) {
			return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
		}
	}
}
