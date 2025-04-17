namespace CarehiveAPI.DTOs
{
    public class LoginRequestDTO
    {
        public string? Email { get; set; } // User's email for login
        public string? Password { get; set; } // Entered password
    }
}
