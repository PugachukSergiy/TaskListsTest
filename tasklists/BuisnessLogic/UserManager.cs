using Microsoft.EntityFrameworkCore;
using tasklists.DataAccess;
using tasklists.Entities;

namespace tasklists.BuisnessLogic
{
    public class UserManager
    {
        private readonly TaskListDbContext _context;

        public UserManager(TaskListDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetUserByIdAsync(int userId)
        {
            return _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
        }
    }
}
