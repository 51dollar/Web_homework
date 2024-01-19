using MVC.Models;

namespace MVC.Repository
{
	public interface IFriendRepository
	{
		public IEnumerable<Friend> GetAllFriends();

		public Friend GetFriendByID(Guid id);

		public void CreateFriend(Friend friend);

		public void UpdateFriend(Friend friend);

		public void DeleteFriend(Friend friend);

		public void SaveChanges();
	}
}
