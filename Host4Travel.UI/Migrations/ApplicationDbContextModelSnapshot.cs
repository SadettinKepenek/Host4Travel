﻿// <auto-generated />
using System;
using Host4Travel.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Host4Travel.UI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Host4Travel.Entities.Concrete.ApplicationIdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.ApplicationIdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CookieAcceptDate")
                        .HasColumnName("datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CookieAcceptIpAddress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsCookieAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

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

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

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
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.HasIndex("CategoryParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.CategoryReward", b =>
                {
                    b.Property<Guid>("CategoryRewardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

            modelBuilder.Entity("Host4Travel.Entities.Concrete.Chat", b =>
                {
                    b.Property<Guid>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

            modelBuilder.Entity("Host4Travel.Entities.Concrete.ChatMessage", b =>
                {
                    b.Property<Guid>("ChatMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

            modelBuilder.Entity("Host4Travel.Entities.Concrete.Document", b =>
                {
                    b.Property<Guid>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DocumentUploadDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DocumentUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("DocumentId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentType");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.Log", b =>
                {
                    b.Property<Guid>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("LogDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("LogMessage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostApplication", b =>
                {
                    b.Property<Guid>("PostApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

                    b.HasIndex("PostId");

                    b.ToTable("PostApplication");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostCategoryReward", b =>
                {
                    b.Property<Guid>("PostCategoryRewardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostCheckIn", b =>
                {
                    b.Property<Guid>("PostCheckInId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckInEndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CheckInStartDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostCheckInId");

                    b.HasIndex("ApplicationId")
                        .IsUnique();

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("PostCheckIn");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

            modelBuilder.Entity("Host4Travel.UI.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

            modelBuilder.Entity("Host4Travel.UI.PostDiscussion", b =>
                {
                    b.Property<Guid>("PostDiscussionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

            modelBuilder.Entity("Host4Travel.UI.PostRating", b =>
                {
                    b.Property<Guid>("PostRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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

                    b.HasIndex("ApplicationId")
                        .IsUnique()
                        .HasFilter("[ApplicationId] IS NOT NULL");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PostId");

                    b.ToTable("PostRating");
                });

            modelBuilder.Entity("Host4Travel.UI.Reward", b =>
                {
                    b.Property<int>("RewardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasIndex("RewardName")
                        .IsUnique();

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
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

            modelBuilder.Entity("Host4Travel.Entities.Concrete.Category", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.Category", "CategoryParent")
                        .WithMany("InverseCategoryParent")
                        .HasForeignKey("CategoryParentId")
                        .HasConstraintName("FK_Category_Category");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.CategoryReward", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.Category", "Category")
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

            modelBuilder.Entity("Host4Travel.Entities.Concrete.Chat", b =>
                {
                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("Chat")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_Chat_Post");
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.ChatMessage", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.Chat", "Chat")
                        .WithMany("ChatMessage")
                        .HasForeignKey("ChatId")
                        .HasConstraintName("FK_ChatMessage_Chat")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.Document", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .HasConstraintName("FK_DocumentType_Document")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", "Owner")
                        .WithMany("Documents")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_Document_ApplicationIdentityUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostApplication", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", "Applicent")
                        .WithMany("PostApplication")
                        .HasForeignKey("ApplicentId")
                        .HasConstraintName("FK_PostApplication_AspNetUsers")
                        .IsRequired();

                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("PostApplication")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostApplication_Post")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostCategoryReward", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.Category", "Category")
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

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostCheckIn", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.PostApplication", "Application")
                        .WithOne("PostCheckIn")
                        .HasForeignKey("Host4Travel.Entities.Concrete.PostCheckIn", "ApplicationId")
                        .HasConstraintName("FK_PostApplication_PostCheckIn")
                        .IsRequired();

                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithOne("PostCheckIn")
                        .HasForeignKey("Host4Travel.Entities.Concrete.PostCheckIn", "PostId")
                        .HasConstraintName("FK_PostCheckIn_Post")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.Entities.Concrete.PostImage", b =>
                {
                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("PostImage")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostImage_Post")
                        .IsRequired();
                });

            modelBuilder.Entity("Host4Travel.UI.Post", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", "Owner")
                        .WithMany("Post")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_Post_AspNetUsers")
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

            modelBuilder.Entity("Host4Travel.UI.PostRating", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.PostApplication", "Application")
                        .WithOne("PostRating")
                        .HasForeignKey("Host4Travel.UI.PostRating", "ApplicationId")
                        .HasConstraintName("FK_PostRating_PostApplication");

                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", "Owner")
                        .WithMany("PostRating")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_PostRating_AspNetUsers");

                    b.HasOne("Host4Travel.UI.Post", "Post")
                        .WithMany("PostRating")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostRating_Post");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Host4Travel.Entities.Concrete.ApplicationIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
