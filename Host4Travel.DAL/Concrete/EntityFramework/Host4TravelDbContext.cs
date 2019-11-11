﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Host4Travel.UI
{
    public partial class Host4TravelDbContext : DbContext
    {
        public Host4TravelDbContext()
        {
        }

        public Host4TravelDbContext(DbContextOptions<Host4TravelDbContext> options)
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
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryReward> CategoryReward { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostApplication> PostApplication { get; set; }
        public virtual DbSet<PostCategoryReward> PostCategoryReward { get; set; }
        public virtual DbSet<PostCheckIn> PostCheckIn { get; set; }
        public virtual DbSet<PostDiscussion> PostDiscussion { get; set; }
        public virtual DbSet<PostImage> PostImage { get; set; }
        public virtual DbSet<PostRating> PostRating { get; set; }
        public virtual DbSet<Reward> Reward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=94.73.170.2;initial catalog=u8206796_bnbdb;User Id=u8206796_bnbuser;Password=XFvn39D9MCyr76F");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.CookieAccepted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(192);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CategoryUrl)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.CategoryParent)
                    .WithMany(p => p.InverseCategoryParent)
                    .HasForeignKey(d => d.CategoryParentId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<CategoryReward>(entity =>
            {
                entity.ToTable("Category_Reward");

                entity.Property(e => e.CategoryRewardId).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryReward)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Reward_Category");

                entity.HasOne(d => d.Reward)
                    .WithMany(p => p.CategoryReward)
                    .HasForeignKey(d => d.RewardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Reward_Reward");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.ChatId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Side1)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Side2)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Chat_Post");
            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.Property(e => e.ChatMessageId).ValueGeneratedNever();

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatMessage)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatMessage_Chat");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(10, 6)");

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.PostDescription).IsRequired();

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_AspNetUsers");
            });

            modelBuilder.Entity<PostApplication>(entity =>
            {
                entity.Property(e => e.PostApplicationId).ValueGeneratedNever();

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.ApplicationEndDate).HasColumnType("datetime");

                entity.Property(e => e.ApplicationStartDate).HasColumnType("datetime");

                entity.Property(e => e.ApplicentId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Applicent)
                    .WithMany(p => p.PostApplication)
                    .HasForeignKey(d => d.ApplicentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostApplication_AspNetUsers");
            });

            modelBuilder.Entity<PostCategoryReward>(entity =>
            {
                entity.ToTable("Post_Category_Reward");

                entity.Property(e => e.PostCategoryRewardId).ValueGeneratedNever();

                entity.Property(e => e.RewardValue)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PostCategoryReward)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category_Reward_Category");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostCategoryReward)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category_Reward_Post");

                entity.HasOne(d => d.Reward)
                    .WithMany(p => p.PostCategoryReward)
                    .HasForeignKey(d => d.RewardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category_Reward_Reward");
            });

            modelBuilder.Entity<PostCheckIn>(entity =>
            {
                entity.Property(e => e.PostCheckInId).ValueGeneratedNever();

                entity.Property(e => e.CheckInEndDate).HasColumnType("datetime");

                entity.Property(e => e.CheckInStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.PostCheckIn)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostCheckIn_PostApplication");
            });

            modelBuilder.Entity<PostDiscussion>(entity =>
            {
                entity.Property(e => e.PostDiscussionId).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.HasOne(d => d.CommentNavigation)
                    .WithMany(p => p.InverseCommentNavigation)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_PostDiscussion_PostDiscussion");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostDiscussion)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostDiscussion_Post");
            });

            modelBuilder.Entity<PostImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).ValueGeneratedNever();

                entity.Property(e => e.AltText)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostImage)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostImage_Post");
            });

            modelBuilder.Entity<PostRating>(entity =>
            {
                entity.Property(e => e.PostRatingId).ValueGeneratedNever();

                entity.Property(e => e.OwnerId).HasMaxLength(450);

                entity.Property(e => e.RatingComment).HasMaxLength(250);

                entity.Property(e => e.RatingReply).HasMaxLength(250);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.PostRating)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_PostRating_PostApplication");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.PostRating)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_PostRating_AspNetUsers");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostRating)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_PostRating_Post");
            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.Property(e => e.RewardId).ValueGeneratedNever();

                entity.Property(e => e.RewardDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RewardName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
