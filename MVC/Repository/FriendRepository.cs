using MVC.Data;
using MVC.Models;

namespace MVC.Repository
{
    public class FriendRepository : IFriendRepository
	{
		private ApplicationDbContext _applicationDbContext;
        public FriendRepository(ApplicationDbContext applicationDbContext)
        {
			_applicationDbContext = applicationDbContext;
		}

        public void CreateFriend(Friend friend)
		{
			_applicationDbContext.Friends.Add(friend);
		}

		public void DeleteFriend(Friend friend)
		{
			_applicationDbContext.Friends.Remove(friend);
		}

		public IEnumerable<Friend> GetAllFriends()
		{
			return _applicationDbContext.Friends;
		}

		public Friend GetFriendByID(Guid id)
		{
			return _applicationDbContext.Friends.Find(id);
		}

		public void SaveChanges()
		{
			_applicationDbContext.SaveChanges();
		}

		public void UpdateFriend(Friend friend)
		{
			_applicationDbContext.Friends.Update(friend);
		}
	}
}
