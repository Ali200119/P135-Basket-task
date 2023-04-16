using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fiorello.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            List<CartVM> cart;

            if (Request.Cookies["cart"] != null && Request.Cookies["cart"].Count() != 0)
            {
                cart = JsonConvert.DeserializeObject<List<CartVM>>(Request.Cookies["cart"]);
            }

            else
            {
                cart = new List<CartVM>();
            }


            List<CartDetailVM> cartDetails = new();


            foreach (var product in cart)
            {
                Product dbProduct = await _context.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == product.Id);
                cartDetails.Add(new CartDetailVM
                {
                    Id = dbProduct.Id,
                    Name = dbProduct.Name,
                    Image = dbProduct.ProductImages.Where(pi => pi.IsMain).FirstOrDefault().Name,
                    Price = dbProduct.Price,
                    Count = product.Count
                });
            }

            return View(cartDetails);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteProductFromBasket(int? id)
        {
            if (id is null) return BadRequest();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (dbProduct is null) return NotFound();

            List<CartVM> cart = JsonConvert.DeserializeObject<List<CartVM>>(Request.Cookies["cart"]);

            cart.Remove(cart.FirstOrDefault(cp => cp.Id == id));

            Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseCount(int? id)
        {
            if (id is null) return BadRequest();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (dbProduct is null) return NotFound();

            List<CartVM> cart = JsonConvert.DeserializeObject<List<CartVM>>(Request.Cookies["cart"]);

            cart.FirstOrDefault(cp => cp.Id == id).Count++;

            Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseCount(int? id)
        {
            if (id is null) return BadRequest();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (dbProduct is null) return NotFound();

            List<CartVM> cart = JsonConvert.DeserializeObject<List<CartVM>>(Request.Cookies["cart"]);

            CartVM product = cart.FirstOrDefault(cp => cp.Id == id);

            if (product.Count > 1)
            {
                product.Count--;
            }

            Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));

            return Ok();
        }
    }
}