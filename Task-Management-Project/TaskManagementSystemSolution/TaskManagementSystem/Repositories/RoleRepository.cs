using TaskManagementSystem.Data_DBContext_and_Seeding;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<RoleDTO> GetRoles();
        void AddRole (Role role);
        void AssignRole (int userId,int roleID);
    }
    public class RoleRepository : IRoleRepository
    {
        private readonly TaskManagementDbContext _dbContext;
        public RoleRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<RoleDTO> GetRoles()
        {
            return _dbContext.Roles.Select(r => new RoleDTO
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName
            }).ToList();
        }
        public void AddRole(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
        }

        public void AssignRole(int userId, int roleId)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            _dbContext.UserRoles.Add(userRole);
            _dbContext.SaveChanges();
        }

       
    }
}
