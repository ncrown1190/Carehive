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
    public class SchedulesController : ControllerBase
    {
        private readonly AppointmentDbContext _context;

        public SchedulesController(AppointmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetSchedules()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Doctor)
                .ThenInclude(d => d.User)
                .Select(s => new ScheduleDTO
                {
                    ScheduleId = s.ScheduleId,
                    DoctorId = s.DoctorId,
                    ScheduleDate = s.ScheduleDate,
                    AvailableFrom = s.AvailableFrom,
                    AvailableTo = s.AvailableTo,
                    DoctorName = s.Doctor.User.UserName
                }).ToListAsync();

            return Ok(schedules);
        }

        //Get Doctor schedule by doctor name
        [HttpGet("{doctorName}")]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetSchedulesByDoctorName(string doctorName)
        {
            var schedules = await _context.Schedules
                .Include(s => s.Doctor)
                .ThenInclude(d => d.User)
                .Where(s => s.Doctor.User.UserName == doctorName)
                .Select(s => new ScheduleDTO
                {
                    ScheduleId = s.ScheduleId,
                    DoctorId = s.DoctorId,
                    ScheduleDate = s.ScheduleDate,
                    AvailableFrom = s.AvailableFrom,
                    AvailableTo = s.AvailableTo,
                    DoctorName = s.Doctor.User.UserName
                }).ToListAsync();

            if (schedules.Count == 0)
            {
                return NotFound($"No Schedules found for Doctor: {doctorName}");
            }

            return Ok(schedules);
        }

        // GET: api/Schedules/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Schedule>> GetSchedule(int id)
        //{
        //    var schedule = await _context.Schedules.FindAsync(id);

        //    if (schedule == null)
        //    {
        //        return NotFound();
        //    }

        //    return schedule;
        //}

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleCreateDTO>> PostSchedule(ScheduleCreateDTO scheduleDto)
        {
            //find the doctor based on the provides name
            var doctor = await _context.Users
                .Where(u => u.UserName == scheduleDto.DoctorName)
                .Select(u => u.Doctor)
                .FirstOrDefaultAsync();

            if (doctor == null)
            {
                return NotFound($"Doctor with name '{scheduleDto.DoctorName}' not found");
            }

            //create a new schedule entry
            var schedule = new Schedule
            {
                DoctorId = doctor.DoctorId,
                ScheduleDate = scheduleDto.ScheduleDate,
                AvailableFrom = scheduleDto.AvailableFrom,
                AvailableTo = scheduleDto.AvailableTo
            };

            //Return the created schedule
            return CreatedAtAction(nameof(GetSchedulesByDoctorName), new { id = schedule.ScheduleId }, scheduleDto);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleId == id);
        }
    }
}
