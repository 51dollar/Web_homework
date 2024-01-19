using Microsoft.AspNetCore.Mvc;
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
			IEnumerable<Friend> objFrindsList = _db.Friends;
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
				_db.Friends.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Edit(int? id)
		{
			if (id==null || id == 0)
			{
				return NotFound();
			}

			var friendFromDb = _db.Friends.Find(id);

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
				_db.Friends.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}