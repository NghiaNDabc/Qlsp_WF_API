using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cuoiki1.Models
{
    public partial class QLspContext : DbContext
    {
        public QLspContext()
            : base("name=QLspContext")
        {
        }

        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
