using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Data.Interface;
using OnionArchitecture.Domain.DTO;
using OnionArchitecture.Domain.Models;

namespace OnionArchitecture.Data.Implementation
{ 
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserResponseDto> Add(UserRequestDto userRequestDto)
        {
            if (userRequestDto == null)
            {
                return null;
            }


            var user = new User
            {
                Name = userRequestDto.Name,
                Email= userRequestDto.Email,
                Password=userRequestDto.Password,
                EmailConfirmed = userRequestDto.EmailConfirmed,
                PasswordConfirmed= userRequestDto.PasswordConfirmed,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };

        }

        public async Task<bool> Delete(int id)
        {
            var user= _context.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            var users= await _context.Users.Select(u=> new UserResponseDto
            {
                Id=u.Id,
                Name = u.Name,
                Email= u.Email,
            }).ToListAsync();
            return users;   
        }

        public async Task<UserResponseDto> GetById(int id)
        {
           var user= await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
        }

        public async Task<UserResponseDto> Update(UserRequestUpdateDto userRequestUpdateDto)
        {
            var user= await _context.Users.FindAsync(userRequestUpdateDto.Id);
            if (user == null)
            {
                return null;
            }

            user.Name = userRequestUpdateDto.Name;
            user.Email = userRequestUpdateDto.Email;
            user.Password = userRequestUpdateDto.Password;
            user.EmailConfirmed = userRequestUpdateDto.EmailConfirmed;
            user.PasswordConfirmed= userRequestUpdateDto.PasswordConfirmed;

            await _context.SaveChangesAsync();
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,

            };


        }
    }
}
