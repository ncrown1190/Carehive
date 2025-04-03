namespace CarehiveAPI.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}
