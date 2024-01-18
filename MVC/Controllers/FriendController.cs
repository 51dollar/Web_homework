﻿using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class FriendController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FriendController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Friend> objFrindsList = _db.friends.ToList();
            return View(objFrindsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Friend obj)
        {
            if(obj.FriendName == obj.Place)
            {
                ModelState.AddModelError("FriendName", "The Place cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.friends.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
