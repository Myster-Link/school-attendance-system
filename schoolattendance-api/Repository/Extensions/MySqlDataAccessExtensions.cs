using Microsoft.Extensions.DependencyInjection;
using Repository.Repository.User;
using Repository.UnitOfWork;
using System.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Repository.Models;

namespace Repository.Extensions
{
    public static class MySqlDataAccessExtensions
    {
        public static IServiceCollection AddMySQLRepositories(this IServiceCollection services, string connectionString)
        {
            //  Unit Of Work
            services.AddTransient<IDbConnection>(_ => new MySqlConnection(connectionString));
            services.AddTransient<IUnitOfWorkManager, UnitOfWorkManager>();

            //  EF
            services.AddDbContext<SchoolAttendanceDatabaseContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            // Dapper
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            //Repository
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
