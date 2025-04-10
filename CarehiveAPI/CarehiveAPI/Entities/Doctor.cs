using System;
using System.Collections.Generic;

namespace CarehiveAPI.Entities;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public int UserId { get; set; }

    public string? Specialty { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual User User { get; set; } = null!;
}
