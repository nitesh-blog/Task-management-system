using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> GetAllRoles();
        void CreateRole(Role role);
        void AssignRole(int userId, int roleId);
    }
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RoleDTO> GetAllRoles() 
        {
           return _repository.GetRoles();
        }

        public void CreateRole(Role role)
        {
            _repository.AddRole(role);
        }
        public void AssignRole(int userId, int roleId)
        {
            _repository.AssignRole(userId, roleId);
        }
    }
}
