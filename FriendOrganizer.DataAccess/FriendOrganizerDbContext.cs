﻿using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<FriendPhoneNumber> FriendPhoneNumbers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public FriendOrganizerDbContext() : base("FriendOrganizerDb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new FriendConfiguration());
        }
    }
    public class FriendConfiguration : EntityTypeConfiguration<Friend>
    {
        public FriendConfiguration()
        {
            Property(f => f.FirstName).IsRequired().HasMaxLength(50);
            Property(f => f.LastName).HasMaxLength(50);
            Property(f => f.Email).HasMaxLength(50);

        }
    }
}
