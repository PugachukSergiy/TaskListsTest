using Azure.Core;
using Microsoft.EntityFrameworkCore;
using tasklists.BuisnessLogic.Helpers;
using tasklists.DataAccess;
using tasklists.Entities;

namespace tasklists.BuisnessLogic
{
    public class TaskListManager
    {
        private readonly TaskListDbContext _context;

        public TaskListManager(TaskListDbContext context)
        {
            _context = context;
        }

        public Task<List<TaskList>> GetTaskListsByUserIdAsync(int userId, int offset, int count)
        {
            var ownedListsQuary = _context.TaskLists.Where(x => x.OwnerId == userId);
            var sharedListsQuary = _context.TaskLists.Where(x => x.SharedTo!.Any(x => x.Id == userId));

            return ownedListsQuary.Union(sharedListsQuary)
                .OrderByDescending(x => x.CreationDateTime)
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }

        public async Task<TaskList> CreateTaskListAsync(int userId, string name)
        {
            var taskList = new TaskList()
            {
                Name = name,
                OwnerId = userId,
                CreationDateTime = DateTime.UtcNow,
            };
            _context.TaskLists.Add(taskList);
            await _context.SaveChangesAsync();
            return taskList;
        }

        public Task<TaskList?> GetTaskListByIdAsync(int taskListId)
        {
            return _context.TaskLists.Where(x => x.Id == taskListId).FirstOrDefaultAsync();
        }

        public async Task SaveChangesInDbAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task ShareTaskListToUserAsync(TaskList taskListInDb, User userInDb)
        {
            taskListInDb.SharedTo!.Add(userInDb);
            await _context.SaveChangesAsync();
        }

        public async Task UnshareTaskListFromUserAsync(TaskList taskListInDb, User userInDb)
        {
            taskListInDb.SharedTo!.Remove(userInDb);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskListByIdAsync(int taskListId)
        {
            await _context.TaskLists.Where(x => x.Id == taskListId).ExecuteDeleteAsync();
        }

        public Task<TaskList?> GetTaskListWithUsersByIdAsync(int taskListId)
        {
            return _context.TaskLists.Where(x => x.Id == taskListId).Include(x => x.SharedTo).FirstOrDefaultAsync();
        }
    }
}
