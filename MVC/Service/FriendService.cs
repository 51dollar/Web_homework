using MVC.Models;
using MVC.Repository;

namespace MVC.Service
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friends;

        public FriendService(IFriendRepository friends)
        {
            _friends = friends;
        }

        public void CreateFriend(Friend friend)
        {
            _friends.CreateFriend(friend);
            _friends.SaveChanges();
        }

        public void DeleteFriend(Friend friend)
        {
            _friends.DeleteFriend(friend);
            _friends.SaveChanges();
        }

        public Friend GetFriendByID(Guid id)
        {
            return _friends.GetFriendByID(id);
        }

        public IEnumerable<Friend> GetFriends()
        {
            return _friends.GetAllFriends();
        }

        public void UpdateFriend(Friend friend)
        {
            _friends.UpdateFriend(friend);
            _friends.SaveChanges();
        }
    }
}
