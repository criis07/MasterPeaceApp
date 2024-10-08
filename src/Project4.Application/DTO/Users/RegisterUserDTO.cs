using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Application.DTO.Users
{
    public record RegisterUserDTO
    {
        [Required]
        public string? Name { get; set; } = string.Empty;
        [Required]
        public string? LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;
        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; } = string.Empty;
    }
}
