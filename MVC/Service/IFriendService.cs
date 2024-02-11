using MVC.Models;

namespace MVC.Service
{
    public interface IFriendService
    {
        public IEnumerable<Friend> GetFriends();

        public Friend GetFriendByID(Guid id);

        public void CreateFriend(Friend friend);

        public void UpdateFriend(Friend friend);

        public void DeleteFriend(Friend friend);
    }
}
