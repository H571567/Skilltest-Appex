﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
    }
}