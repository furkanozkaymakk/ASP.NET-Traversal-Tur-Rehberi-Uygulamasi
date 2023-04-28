﻿using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0PA7HPM\\SQLEXPRESS;database=TraversalDB;integrated security=true;TrustServerCertificate=True");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> About2s { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feature2> Feature2s { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}