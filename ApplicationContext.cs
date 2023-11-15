using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;

namespace LogTo
{
    public class ApplicationContext:DbContext
    {
        readonly StreamWriter logSt = new StreamWriter("mylog.txt", true);
        public DbSet<Human> Humans { get; set; } = null!;
        public ApplicationContext() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=Hello.db");
            optionsBuilder.LogTo(logSt.WriteLine);
        }
        public override void Dispose()
        {
            base.Dispose();
            logSt.Dispose();
        }
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logSt.DisposeAsync();
        }
    }
}

/*LogTo()
Trace
Debug
Information
Warning
Error
Critical
None

SqlServerEventId
CoreEventId
RelationalEventId

DbLoggerCategory

Database.Command
Database.Connection
Database.Transaction
Mirgation
Model
Query
Scaffolding
Update
Infrastructure*/