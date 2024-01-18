using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Friend
    {
        [Key]
        public int FriendID { get; set; }
        [Required]
        [DisplayName("Name")]
        public string? FriendName { get; set; }
		[Required]
		public string? Place { get; set; }
    }
}
