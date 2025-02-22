using TaskManagementSystem.Data_DBContext_and_Seeding;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetUsers();
        public void AddUser(User user);
        UserDTO UpdateUser(int id, User user);
        User GetUserById(int id);
        void DeleteUser(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementDbContext _dbContext;
        public UserRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IEnumerable<UserDTO> GetUsers()
        {
            return _dbContext.Users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Username = u.UserName,
                PasswordHash = u.PasswordHash,
                Email = u.Email,
                CreatedAt = u.CreatedAt
            }).ToList();
                
         }
        public void AddUser(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
          return _dbContext.Users.Find(id);
        }

        public UserDTO UpdateUser(int id, User user)
        {
           var existingUser = _dbContext.Users.Find(id);
            if (existingUser == null)
                return null;
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            _dbContext.SaveChanges();

            return new UserDTO
            {
                UserId = existingUser.UserId,
                Username = existingUser.UserName,
                Email = existingUser.Email,
                CreatedAt = existingUser.CreatedAt
            };


        }
    }
}
