using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymManagement.Models;

namespace GymManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<PTSchedules> PTSchedules { get; set; }
        public DbSet<CheckInLog> CheckInLogs { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.MembershipType)
                .WithMany(mt => mt.Members)
                .HasForeignKey(m => m.MembershipTypeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PTSchedules>()
                .HasOne(ps => ps.PersonalTrainer)
                .WithMany(pt => pt.PTSchedules)
                .HasForeignKey(ps => ps.PTID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PTSchedules>()
                .HasOne(ps => ps.Member)
                .WithMany(m => m.PTSchedules)
                .HasForeignKey(ps => ps.MemberID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CheckInLog>()
                .HasOne(c => c.Member)
                .WithMany(m => m.CheckInLogs)
                .HasForeignKey(c => c.MemberID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailLog>()
                .HasOne(e => e.Member)
                .WithMany()
                .HasForeignKey(e => e.MemberID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}