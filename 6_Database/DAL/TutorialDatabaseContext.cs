using Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DAL
{
    public class TutorialDatabaseContext : DbContext
    {
        public TutorialDatabaseContext()
            : base("TutorialDatabaseContext")
        {

        }

        public DbSet<Models.Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<StudentModel>()
                .Property(x => x.FirstName)
                .IsUnicode(true);

            modelBuilder.Entity<StudentModel>()
                .Property(x => x.LastName)
                .IsUnicode(true);
        }
    }
}
