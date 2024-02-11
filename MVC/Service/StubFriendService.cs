using MVC.Models;

namespace MVC.Service
{
    public class StubFriendService : IFriendService
    {
        public void CreateFriend(Friend friend)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(Friend friend)
        {
            throw new NotImplementedException();
        }

        public Friend GetFriendByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> GetFriends()
        {
            return new List<Friend>();
        }

        public void UpdateFriend(Friend friend)
        {
            throw new NotImplementedException();
        }
    }
}
