using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarehiveAPI.Entities;
using CarehiveAPI.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace CarehiveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppointmentDbContext _context;
        private ILogger<UsersController> _logger;
        private readonly IConfiguration _config;

        public UsersController(AppointmentDbContext context, ILogger<UsersController> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //Function to authenticate user id and password
        // GET: api/Users/5
        [HttpPost]
        [Route("Authenticate")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserAuthDTO>> AuthenticateUser([FromBody] UserAuthDTO userDto)
        {
            this._logger.LogInformation("Authenticate User called");
            byte[] password = EncryptPassword(userDto.PasswordHash);
            User? user = await _context.Users
                .Where(data => data.LoginId.ToLower() == userDto.LoginId.ToLower() && data.PasswordHash.SequenceEqual(password))
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("User or Password is invalid");
            }

            userDto = new UserAuthDTO()
            {
                UserId = user.UserId,
                LoginId = userDto.LoginId,
                Phone = user.Phone,
                Email = user.Email,
                Name = user.UserName,
                Role = user.Role
            };

            userDto.Token = GenerateToken(userDto);
            return Ok(userDto);
        }

        [HttpPost("loginbyEmail")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            // Find user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

            if (user == null || VerifyPassword(loginRequest.Password!, user.PasswordHash))
            {
                return Unauthorized("Invalid email or password.");
            }

            // Generate JWT token for authenticated user
            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        //

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == userDto.Email);
            if (userExists)
            {
                return Conflict("User already exists");
            }

            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                LoginId = userDto.LoginId,
                PasswordHash = this.EncryptPassword(userDto.PasswordHash),
                Role = userDto.Role,
                Phone = userDto.Phone,
                Address = userDto.Address,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered sucessfully");
        }



        //Helper functions 
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            }),
                Expires = DateTime.UtcNow.AddHours(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool VerifyPassword(string enteredPassword, byte[] storedPasswordHash)
        {
            // Convert entered password to byte array (using UTF-8 encoding)
            var enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);

            // Compare byte arrays
            return enteredPasswordBytes.SequenceEqual(storedPasswordHash);
        }

        //This function returns encoded password
        private byte[] EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashvalue;
            UTF8Encoding utfEncoding = new UTF8Encoding();
            hashvalue = sha256.ComputeHash(utfEncoding.GetBytes(password));
            return hashvalue;
        }

        private string GenerateToken(UserAuthDTO userDto)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Name",userDto.Name!),
                new Claim("LoginId",userDto.LoginId),
                new Claim("Email",userDto.Email)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
