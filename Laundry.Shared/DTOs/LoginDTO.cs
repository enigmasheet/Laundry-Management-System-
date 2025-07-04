﻿using System.ComponentModel.DataAnnotations;

namespace Laundry.Shared.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;
    }
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public double ExpiresIn { get; set; }
        public UserDto User { get; set; } = new();
    }
}
