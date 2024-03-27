using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Friend
    {
        [Key]
        public required Guid FriendID { get; set; }

        [DisplayName("Name")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Names is 100 characters")]
        [Required(ErrorMessage = "Username not specified")]
        public string? FriendName { get; set; }

        [MaxLength(25, ErrorMessage = "Maximum length for the Place is 25 characters")]
        [Required(ErrorMessage = "user place not specified")]
        public string? Place { get; set; }
    }
}
