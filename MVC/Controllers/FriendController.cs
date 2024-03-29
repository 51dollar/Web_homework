﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Service;

namespace MVC.Controllers
{
    public class FriendController : Controller
	{
		private readonly IFriendService _friends;

		public FriendController(IFriendService friends)
		{
			_friends = friends;
		}

		public IActionResult Index()
		{
			var objFrindsList = _friends.GetFriends();
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
			if (obj.FriendName == obj.Place)
			{
				ModelState.AddModelError("FriendName", "The Place cannot exactly match the Name");
			}
			if (ModelState.IsValid)
			{
				_friends.CreateFriend(obj);
				TempData["success"] = "Friend created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Edit(Guid id)
		{
			if (id == Guid.Empty)
			{
				return NotFound();
			}

			var friendFromDb = _friends.GetFriendByID(id);

			if (friendFromDb == null)
			{
				return NotFound();
			}

			return View(friendFromDb);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Friend obj)
		{
			if (obj.FriendName == obj.Place)
			{
				ModelState.AddModelError("FriendName", "The Place cannot exactly match the Name");
			}
			if (ModelState.IsValid)
			{
				_friends.UpdateFriend(obj);
				TempData["success"] = "Friend update successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Delete(Guid id)
		{
			if (id == Guid.Empty)
			{
				return NotFound();
			}

			var friendFromDb = _friends.GetFriendByID(id);

			if (friendFromDb == null)
			{
				return NotFound();
			}

			return View(friendFromDb);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(Guid id)
		{
			var obj = _friends.GetFriendByID(id);
			if (obj == null)
			{
				return NotFound();
			}

			_friends.DeleteFriend(obj);
			TempData["success"] = "Kicked out from friends";
			return RedirectToAction("Index");
		}
	}
}