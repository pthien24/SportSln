﻿using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(Cart cartService, IOrderRepository repoService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new Order());
        [HttpPost]

        [HttpPost] public IActionResult Checkout(Order order) { if (cart.Lines.Count() == 0) { ModelState.AddModelError("", "Sorry, your cart is empty!"); } if (ModelState.IsValid) { order.Lines = cart.Lines.ToArray(); repository.SaveOrder(order); cart.Clear(); return RedirectToPage("/Completed", new { orderId = order.OrderID }); } else { return View(); } }
        //public IActionResult Checkout(Order order)
        //{
        //    if (cart.Lines.Count == 0) {
        //        ModelState.AddModelError("", "sorry , Your cart is empty"); 
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        order.Lines = cart.Lines.ToArray();
        //        repository.SaveOrder(order);
        //        cart.Clear();
        //        return RedirectToPage("/Completed", new { OrderId = order.OrderID });
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        
    }
}
