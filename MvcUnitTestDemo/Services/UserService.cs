using MvcUnitTestDemo.Data;
using MvcUnitTestDemo.Models;

namespace MvcUnitTestDemo.Services
{
    public class UserService: IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            await _context.Users.AddAsync(user);
        }

        public async void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
