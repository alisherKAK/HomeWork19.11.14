using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "You must fill this field")]
        public string Login { get; set; }
        [Required(ErrorMessage = "You must fill this field")]
        public string Password { get; set; }
        [Required(ErrorMessage = "You must fill this field")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must fill this field")]
        public string Phone { get; set; }
    }
}
