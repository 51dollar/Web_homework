using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Friend
    {
        [Key]
        public required Guid FriendID { get; set; }

        [DisplayName("Name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Username not specified")]
        public string? FriendName { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "user place not specified")]
        public string? Place { get; set; }
    }
}
