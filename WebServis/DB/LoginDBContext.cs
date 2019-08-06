namespace WebServis.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LoginDBContext : DbContext
    {
        public LoginDBContext()
            : base("name=LoginDBContext")
        {
        }

        public virtual DbSet<tbKullaniciler> tbKullanicilers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
