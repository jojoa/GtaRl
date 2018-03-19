using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTARL.models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class GTARlDb : DbContext
    {
        public GTARlDb() : base("server=localhost;database=GTARL;uid=root;password=test1234")
        {

        }

        public GTARlDb(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<GTARlDb>(null);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<EggModel> Eggs { get; set; }

        public DbSet<EggFoundModel> EggFound { get; set; }


    }
}
