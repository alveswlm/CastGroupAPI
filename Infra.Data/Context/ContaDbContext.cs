using Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Context
{
    public class ContaDbContext : DbContext, IDbContext
    {
        private static string _codeFirstUpdateConnectionString;
        private static string CodeFirstUpdateConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_codeFirstUpdateConnectionString))
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                        .Build();
                    _codeFirstUpdateConnectionString = config.GetSection("ConnectionStrings")["ContaDbConnection"];
                }

                return _codeFirstUpdateConnectionString;
            }
        }

        public DbSet<ContaEntity> Contas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CodeFirstUpdateConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ContaEntity>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });
        }

        public ContaDbContext() : this(CodeFirstUpdateConnectionString)
        {
        }

        public ContaDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}