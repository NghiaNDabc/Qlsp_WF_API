using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace webAPI.Models
{
    public partial class QlspContext : DbContext
    {
        public QlspContext()
            : base("name=QlspContext")
        {
        }

        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
