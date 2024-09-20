using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLessons.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
    }
}
