using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Friend
    {
        [Key]
        public int FriendID { get; set; }
        [Required]
        public string? FriendName { get; set; }
        public string? Place { get; set; }
    }
}
