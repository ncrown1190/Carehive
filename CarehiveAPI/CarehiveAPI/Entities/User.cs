using System;
using System.Collections.Generic;

namespace CarehiveAPI.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string LoginId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public string? Phone { get; set; }

    public string Role { get; set; } = null!;

    public string? Address { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Doctor? Doctor { get; set; }
}
