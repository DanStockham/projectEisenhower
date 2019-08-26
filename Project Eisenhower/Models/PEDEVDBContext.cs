using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_Eisenhower.Models
{
    public partial class PEDEVDBContext : DbContext
    {
        public PEDEVDBContext()
        {
        }

        public PEDEVDBContext(DbContextOptions<PEDEVDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Eventtatus> Eventtatus { get; set; }
        public virtual DbSet<EventTags> EventTags { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<FpsRanges> FpsRanges { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<RulesOfEngagement> RulesOfEngagement { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-H4LTUG94\\SQLEXPRESS;Initial Catalog=PEDEVDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_Contacts_1");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("money");

                entity.Property(e => e.FieldId).HasColumnName("field_id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpName)
                    .HasColumnName("opName")
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_Event_Field");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Event_Status");
            });

            modelBuilder.Entity<Eventtatus>(entity =>
            {
                entity.ToTable("Event_Status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventTags>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PK_Event_Tags");

                entity.ToTable("Event_Tags");

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(e => e.FieldId).HasColumnName("field_id");

                entity.Property(e => e.AddrsId).HasColumnName("addrs_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasColumnName("field_name")
                    .HasMaxLength(140);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Addrs)
                    .WithMany(p => p.Field)
                    .HasForeignKey(d => d.AddrsId)
                    .HasConstraintName("FK_Locations_Field");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Field)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Field_Contacts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Field)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_Field_Users");
            });

            modelBuilder.Entity<FpsRanges>(entity =>
            {
                entity.ToTable("FPS_Ranges");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.MaxFps).HasColumnName("maxFPS");

                entity.Property(e => e.MinFps).HasColumnName("minFPS");

                entity.Property(e => e.RangeDesc)
                    .IsRequired()
                    .HasColumnName("range_desc")
                    .HasColumnType("text");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.FpsRanges)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FPS_Ranges_Event");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.AddrsId);

                entity.Property(e => e.AddrsId).HasColumnName("addrs_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<RulesOfEngagement>(entity =>
            {
                entity.ToTable("Rules_Of_Engagement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.RuleItem).HasColumnName("rule_item");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.RulesOfEngagement)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Rules_Of_Engagement_Event");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasColumnName("tag_name")
                    .HasMaxLength(50);
            });
        }
    }
}
