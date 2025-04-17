namespace CarehiveAPI.DTOs
{
    public class UserAuthDTO
    {
        public int UserId { get; set; }

        public string LoginId { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? Name { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }
        public string Role { get; set; } = null!;

        public string? Token { get; set; }
    }
}

