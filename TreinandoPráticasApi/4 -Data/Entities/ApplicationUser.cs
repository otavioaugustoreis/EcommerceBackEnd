﻿using Microsoft.AspNetCore.Identity;

namespace TreinandoPráticasApi._4__Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
