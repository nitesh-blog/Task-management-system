using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUser();
        void CreateUser(User user);
        UserDTO UpdateUser(int id,User user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDTO> GetAllUser()
        {
            return _userRepository.GetUsers();
        }

        public void CreateUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public UserDTO UpdateUser(int id, User user)
        {
            return _userRepository.UpdateUser(id, user);
        }
    }
}
