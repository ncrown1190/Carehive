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
    public class DoctorsController : ControllerBase
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<DoctorsController> _logger;

        public DoctorsController(AppointmentDbContext context, ILogger<DoctorsController> logger)
        {
            _context = context;
            _logger = logger;

        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _context.Doctors
                .Join(
                _context.Users,
                doctor => doctor.UserId,
                user => user.UserId,
                (doctor, user) => new DoctorDTO
                {
                    DoctorId = doctor.DoctorId,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Phone = user.Phone,
                    Specialty = doctor.Specialty
                }
                ).ToListAsync();
            return Ok(doctors);
        }


        // GET: api/Doctors
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        //{
        //    return await _context.Doctors.ToListAsync();
        //}

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorResponseDTO>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.DoctorId == id);

            if (doctor == null)
            {
                return NotFound();
            }

            var responseDto = new DoctorResponseDTO
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.User.UserName,
                Specialty = doctor.Specialty
            };

            return Ok(responseDto);

            //var doctor = await _context.Doctors
            //    .Where(d => d.DoctorId == id)
            //    .Select(d => new DoctorDTO
            //    {
            //        DoctorId = d.DoctorId,
            //        UserId = d.UserId,
            //        Specialty = d.Specialty,
            //        UserName = d.User.UserName,
            //    }).ToListAsync();

            //return Ok(doctor);
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult> PostDoctor([FromBody] DoctorCreateDTO doctorDto)
        {
            //Find the user by name
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == doctorDto.DoctorName);

            if (user == null)
            {
                return NotFound($"No user found with the name '{doctorDto.DoctorName}'.");
            }
            var newDoctor = new Doctor
            {
                //DoctorId = doctorDto.DoctorId,
                UserId = user.UserId,
                Specialty = doctorDto.Specialty,
                User = user,
            };

            _context.Doctors.Add(newDoctor);
            await _context.SaveChangesAsync();

            //build response DTO
            var responseDto = new DoctorResponseDTO
            {
                DoctorId = newDoctor.DoctorId,
                DoctorName = user.UserName,
                Specialty = newDoctor.Specialty
            };

            return CreatedAtAction(nameof(GetDoctor), new { newDoctor.DoctorId }, responseDto);
        }

        //public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        //{
        //    _context.Doctors.Add(doctor);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctor);
        //}

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
