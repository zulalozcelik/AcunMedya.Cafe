using AcunMedya.Cafe.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcunMedya.Cafe.Context
{
    public class CafeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NTFDHVN\\SQLEXPRESS; initial catalog=DbAcunMedyaCafe; integrated Security=true; TrustServerCertificate=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
