using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarehiveAPI.Entities;
using CarehiveAPI.DTOs;

namespace CarehiveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentDbContext _context;

        public AppointmentsController(AppointmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAllAppointments()
        {
            var appointments = await _context.Appointments
               .Include(d => d.Doctor)
               .Include(p => p.Patient) // Assuming FK relationship with Users as Patients
               .Select(a => new AppointmentDTO
               {
                   AppointmentId = a.AppointmentId,
                   PatientId = a.PatientId,
                   PatientFullName = a.Patient!.FullName, // FullName from User table
                   DoctorId = a.DoctorId,
                   DoctorName = a.Doctor!.FullName,  // FullName from Doctors table
                   AppointmentDateTime = a.AppointmentDateTime,
                   Status = a.Status,
               }).ToListAsync();

            return Ok(appointments);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(a => a.AppointmentId == id)
                .Select(a => new AppointmentDTO
                {
                    AppointmentId = a.AppointmentId,
                    PatientId = a.PatientId,
                    PatientFullName = a.Patient!.FullName,
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor!.FullName,
                    AppointmentDateTime = a.AppointmentDateTime,
                    Status = a.Status,
                }).FirstOrDefaultAsync();

            if (appointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }

            return Ok(appointment);
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentDTO>> CreateAppointment(AppointmentCreateDTO appointmentDto)
        {
            //Check if the doctor exists
            var doctor = await _context.Doctors.FindAsync(appointmentDto.DoctorId);

            if (doctor == null)
            {
                return NotFound($"Doctor with ID {appointmentDto.PatientId} not found");
            }

            //check if the patient exists
            var patient = await _context.Users.FindAsync(appointmentDto.PatientId);
            if (patient == null || patient.Role != "Patient")
            {
                return NotFound($"Patient with ID {appointmentDto.PatientId} not found");
            }

            //check if the doctor is available at the specified time
            var conflictingAppointments = await _context.Appointments
                .Where(a => a.DoctorId == appointmentDto.DoctorId &&
                a.AppointmentDateTime == appointmentDto.AppointmentDateTime).ToListAsync();

            if (conflictingAppointments.Count != 0)
            {
                return Conflict("The doctor is not available at the specified time.");
            }

            // Map the DTO to the Appointment entity
            var appointment = new Appointment
            {
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId,
                AppointmentDateTime = appointmentDto.AppointmentDateTime,
                Status = appointmentDto.Status,
                CreatedDate = DateTime.UtcNow // Automatically set the creation date
            };

            //Add the appointment to the database
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            //Return the created appointment
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentId }, new AppointmentDTO
            {
                //PatientId = appointment.PatientId,
                PatientFullName = appointment.Patient?.FullName,
                DoctorId = appointment.DoctorId,
                AppointmentDateTime = appointment.AppointmentDateTime,
                Status = appointment.Status,
            });
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
