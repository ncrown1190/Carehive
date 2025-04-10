using System;
using System.Collections.Generic;

namespace CarehiveAPI.Entities;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public TimeOnly? AppointmentTime { get; set; }

    public string? Status { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual User Patient { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
