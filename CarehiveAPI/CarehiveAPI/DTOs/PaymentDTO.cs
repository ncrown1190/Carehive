namespace CarehiveAPI.DTOs
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }

        public int AppointmentId { get; set; }

        public decimal Amount { get; set; }

        public string? PaymentStatus { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}
