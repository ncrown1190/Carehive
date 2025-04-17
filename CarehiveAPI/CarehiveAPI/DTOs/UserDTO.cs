namespace CarehiveAPI.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string LoginId { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? Phone { get; set; }

        public string Role { get; set; } = null!;

        public string? Address { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? Token { get; set; }
    }
}
