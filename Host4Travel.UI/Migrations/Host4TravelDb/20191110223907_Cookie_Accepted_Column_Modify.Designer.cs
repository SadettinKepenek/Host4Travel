﻿// <auto-generated />
using System;
using Host4Travel.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Host4Travel.UI.Migrations.Host4TravelDb
{
    [DbContext(typeof(Host4TravelDbContext))]
    [Migration("20191110223907_Cookie_Accepted_Column_Modify")]
    partial class Cookie_Accepted_Column_Modify
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Host4Travel.UI.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CookieAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(192)")
                        .HasMaxLength(192);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Host4Travel.UI.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("CategoryLevel")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("CategoryParentId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Host4Travel.UI.CategoryReward", b =>
                {
                    b.Property<Guid>("CategoryRewardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.HasKey("CategoryRewardId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RewardId");

                    b.ToTable("Category_Reward");
                });

            modelBuilder.Entity("Host4Travel.UI.Chat", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Side1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("Side2")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("ChatId");

                    b.HasIndex("PostId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("Host4Travel.UI.ChatMessage", b =>
                {
                    b.Property<Guid>("ChatMessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime");

                    b.HasKey("ChatMessageId");

                    b.HasIndex("ChatId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("Host4Travel.UI.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10, 6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(10, 6)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("PostDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("PostType")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("PostId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Host4Travel.UI.PostApplication", b =>
                {
                    b.Property<Guid>("PostApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ApplicationEndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ApplicationStartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ApplicentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostApplicationId");

                    b.HasIndex("ApplicentId");

                    b.ToTable("PostApplication");
                });

            modelBuilder.Entity("Host4Travel.UI.PostCategoryReward", b =>
                {
                    b.Property<Guid>("PostCategoryRewardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.Property<string>("RewardValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("PostCategoryRewardId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.HasIndex("RewardId");

                    b.ToTable("Post_Category_Reward");
                });

            modelBuilder.Entity("Host4Travel.UI.PostCheckIn", b =>
                {
                    b.Property<Guid>("PostCheckInId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckInEndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CheckInStartDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("PostCheckInId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("PostCheckIn");
                });

            modelBuilder.Entity("Host4Travel.UI.PostDiscussion", b =>
                {
                    b.Property<Guid>("PostDiscussionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostDiscussionId");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("PostDiscussion");
                });

            modelBuilder.Entity("Host4Travel.UI.PostImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageId");

                    b.HasIndex("PostId");

                    b.ToTable("PostImage");
                });

            modelBuilder.Entity("Host4Travel.UI.PostRating", b =>
                {
                    b.Property<Guid>("PostRatingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RatingComment")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("RatingReply")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("RatingValue")
                        .HasColumnType("int");

                    b.HasKey("PostRatingId");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("OwnerId");

                    b.ToTable("PostRating");
                });

            modelBuilder.Entity("Host4Travel.UI.Reward", b =>
                {
                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RewardDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("RewardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("RewardId");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetRoleClaims", b =>
                {
                    b.HasOne("Host4Travel.UI.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserClaims", b =>
                {
                    b.HasOne("Host4Travel.UI.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserLogins", b =>
                {
                    b.HasOne("Host4Travel.UI.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserRoles", b =>
                {
                    b.HasOne("Host4Travel.UI.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Host4Travel.UI.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.AspNetUserTokens", b =>
                {
                    b.HasOne("Host4Travel.UI.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.Category", b =>
                {
                    b.HasOne("Host4Travel.UI.Category", "CategoryParent")
                        .WithMany("InverseCategoryParent")
                        .HasForeignKey("CategoryParentId")
                        .HasConstraintName("FK_Category_Category");
                });

            modelBuilder.Entity("Host4Travel.UI.CategoryReward", b =>
                {
                    b.HasOne("Host4Travel.UI.Category", "Category")
                        .WithMany("CategoryReward")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Category_Reward_Category")
                        .IsRequired();

                    b.HasOne("Host4Travel.UI.Reward", "Reward")
                        .WithMany("CategoryReward")
                        .HasForeignKey("RewardId")
                        .HasConstraintName("FK_Category_Reward_Reward")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.Chat", b =>
                {
                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("Chat")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_Chat_Post");
                });

            modelBuilder.Entity("Host4Travel.UI.ChatMessage", b =>
                {
                    b.HasOne("Host4Travel.UI.Chat", "Chat")
                        .WithMany("ChatMessage")
                        .HasForeignKey("ChatId")
                        .HasConstraintName("FK_ChatMessage_Chat")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.Post", b =>
                {
                    b.HasOne("Host4Travel.UI.AspNetUsers", "Owner")
                        .WithMany("Post")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_Post_AspNetUsers")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.PostApplication", b =>
                {
                    b.HasOne("Host4Travel.UI.AspNetUsers", "Applicent")
                        .WithMany("PostApplication")
                        .HasForeignKey("ApplicentId")
                        .HasConstraintName("FK_PostApplication_AspNetUsers")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.PostCategoryReward", b =>
                {
                    b.HasOne("Host4Travel.UI.Category", "Category")
                        .WithMany("PostCategoryReward")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Post_Category_Reward_Category")
                        .IsRequired();

                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("PostCategoryReward")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_Post_Category_Reward_Post")
                        .IsRequired();

                    b.HasOne("Host4Travel.UI.Reward", "Reward")
                        .WithMany("PostCategoryReward")
                        .HasForeignKey("RewardId")
                        .HasConstraintName("FK_Post_Category_Reward_Reward")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.PostCheckIn", b =>
                {
                    b.HasOne("Host4Travel.UI.PostApplication", "Application")
                        .WithMany("PostCheckIn")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_PostCheckIn_PostApplication")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.PostDiscussion", b =>
                {
                    b.HasOne("Host4Travel.UI.PostDiscussion", "CommentNavigation")
                        .WithMany("InverseCommentNavigation")
                        .HasForeignKey("CommentId")
                        .HasConstraintName("FK_PostDiscussion_PostDiscussion");

                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("PostDiscussion")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostDiscussion_Post")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.PostImage", b =>
                {
                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("PostImage")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostImage_Post")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.PostRating", b =>
                {
                    b.HasOne("Host4Travel.UI.PostApplication", "Application")
                        .WithMany("PostRating")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_PostRating_PostApplication");

                    b.HasOne("Host4Travel.UI.AspNetUsers", "Owner")
                        .WithMany("PostRating")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_PostRating_AspNetUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
