using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyUp.Core
{
    public class EasyUpDbContext : DbContext
    {
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<DataType> DataTypes { get; set; }
        public DbSet<ContentField> ContentFields { get; set; }
        public DbSet<ContentFieldValue> ContentFieldValues { get; set; }

        public EasyUpDbContext() : base("name=mainConnection")
        {

        }
    }
}
