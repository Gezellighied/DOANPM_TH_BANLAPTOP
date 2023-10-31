using Azure;
using DOANPM_TH.Models;
using DOANPM_TH.Models.ClassModel;
using DOANPM_TH.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DOANPM_TH.Repository;

namespace DOANPM_TH.Controllers
{
    public class CartController : Controller
    {
        private DBHelper dbHelper;

        public CartController(DatabaseContext context)
        {
            dbHelper = new DBHelper(context);
        }

        public IActionResult Index()
        {

            //ProductModel db = new ProductModel();
            //return View(db.FindAll().ToList());
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemViewModel cartItemViewModel = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Total),
            };

            //ViewBag.cart = dbHelper.GetCarts(HttpContext.Session.GetInt32("CustomerId"));
            //ViewBag.carts = dbHelper.GetLaptopDetails(HttpContext.Session.GetInt32("CustomerId"));

            return View(cartItemViewModel);
        }


        public ActionResult AddtoCart(int productId = -1)
        {
            Laptops laptop = dbHelper.GetLaptopDetails(productId);
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            CartItemModel cartItem = cart.Where(c => c.LaptopId == productId).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItemModel(laptop));
            }
            else
            {
                cartItem.Quantity++;
            }

            HttpContext.Session.SetJson("Cart", cart);


            // Chuyển hướng đến action "Cart" và truyền danh sách sản phẩm trong giỏ hàng
            return RedirectToAction("Index", "Cart");
        }
       
        /// xóa item trong cart
        [Route("/removecart/{productId:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productId)
        {
            Laptops laptop = dbHelper.GetLaptopDetails(productId);
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            CartItemModel cartItem = cart.Where(c => c.LaptopId == productId).FirstOrDefault();
            if (cartItem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartItem);
            }

            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToAction("Index", "Cart");
        }
       
    }
}
