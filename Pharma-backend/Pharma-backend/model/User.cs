using System.ComponentModel.DataAnnotations;

namespace Pharma_backend.model
{
    public class User
    {
        
            [Key]
            public int UserId { get; set; }

            [Required]
            [StringLength(100)]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string Role { get; set; }
            // Admin / Customer
        }
    }

