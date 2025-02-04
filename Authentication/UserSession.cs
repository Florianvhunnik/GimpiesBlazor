﻿namespace GimpiesBlazor.Authentication
{
    public class UserSession
    {
        public int AccountId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
    }
}
