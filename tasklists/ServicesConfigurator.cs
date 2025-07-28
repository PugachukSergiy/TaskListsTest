using Microsoft.EntityFrameworkCore;
using tasklists.BuisnessLogic;
using tasklists.BuisnessLogic.Handlers;
using tasklists.DataAccess;

namespace tasklists
{
    public static class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            AddDbContext(services);
            AddManagers(services);
            AddHandlers(services);
        }

        public static void AddDbContext(IServiceCollection services)
        {
            var dbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            var contextOptions = new DbContextOptionsBuilder<TaskListDbContext>()
                .UseSqlServer(dbConnectionString)
                .Options;
            services.AddSingleton(contextOptions);
            services.AddDbContext<TaskListDbContext>();
        }

        public static void AddManagers(IServiceCollection services)
        {
            services.AddScoped<TaskListManager>();
            services.AddScoped<UserManager>();
        }

        public static void AddHandlers(IServiceCollection services)
        {
            services.AddScoped<CreateTaskListHandler>();
            services.AddScoped<GetTaskListHandler>();
            services.AddScoped<UpdateTaskListHandler>();
            services.AddScoped<DeleteTaskListHandler>();
            services.AddScoped<GetTaskListsHandler>();
            services.AddScoped<ShareTaskListHandler>();
            services.AddScoped<UnshareTaskListHandler>();
            services.AddScoped<GetTaskListSharingsHandler>();
        }


    }
}
