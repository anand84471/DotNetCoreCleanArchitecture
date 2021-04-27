using Core.Entities.Concrete;
using DAL.DTO;
using DAL.DTO.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.PostgresqlRepo
{
    public class PostgreSqlContext: DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {

        }

        public DbSet<UserDTO> user_details { get; set; }
        public DbSet<Gender> master_gender { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<OrganizationDTO> organizations_details { get; set; }
        public DbSet<SchoolDTO> school_details { get; set; }
        public DbSet<TagDTO> tags_details { get; set; }
        public DbSet<UserSessionsDTO> user_sessions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>(builder =>
            {
            builder.HasKey(c=>c.Id);
                });
            builder.Entity<Gender>(builder =>
            {
                builder.HasKey(c => c.Id);
            });
            builder.Entity<UserDTO>(builder =>
            {
                builder.HasKey(u => u.UserId);
            });
            builder.Entity<UserDTO>()
             .Property(u => u.UserId)
             .HasDefaultValueSql("default");
            builder.Entity<UserDTO>()
               .Property(u => u.RowInsertionDatetime)
               .HasDefaultValueSql("current_timestamp");

            builder.Entity<UserDTO>()
              .Property(u => u.RowUpdationDatetime)
              .HasDefaultValueSql("current_timestamp");

            builder.Entity<OrganizationDTO>(builder =>
            {
                builder.HasKey(c => c.OrganizationId);
            });
            builder.Entity<SchoolDTO>(builder =>
            {
                builder.HasKey(c => c.SchoolId);
            });
            builder.Entity<TagDTO>(builder =>
            {
                builder.HasKey(c => c.TagId);
            });
            builder.Entity<UserSessionsDTO>(builder =>
            {
                builder.HasKey(c => c.SessionId);
            });
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
