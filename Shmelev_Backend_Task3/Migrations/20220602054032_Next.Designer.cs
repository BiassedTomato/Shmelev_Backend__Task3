﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shmelev_Backend_Task3;

namespace Shmelev_Backend_Task3.Migrations
{
    [DbContext(typeof(ForumContext))]
    [Migration("20220602054032_Next")]
    partial class Next
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ForumUserModeratedBoard", b =>
                {
                    b.Property<int>("ModeratedBoardsId")
                        .HasColumnType("int");

                    b.Property<string>("ModeratorsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ModeratedBoardsId", "ModeratorsId");

                    b.HasIndex("ModeratorsId");

                    b.ToTable("ForumUserModeratedBoard");
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModeratedBoardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ForumRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "dcd6603d-1e41-4c6b-87aa-541ccf5eb895",
                            ConcurrencyStamp = "d63177a6-c6e6-463b-84c2-41749cd8fdca",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "bd7acb6c-c29a-464e-984c-b1c369f13729",
                            ConcurrencyStamp = "d1f15ea9-d20e-41cd-9fc0-dd7f2c898570",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "2dbe9c16-990d-4117-8162-8de2bc7bcfcf",
                            ConcurrencyStamp = "0339278f-7176-46be-b9a7-d65a5577bb39",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        });
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ForumUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "64b6755d-ee10-4abf-99f6-7eb549e18b6f",
                            Email = "admin@admin.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.RU",
                            NormalizedUserName = "ADMIN@ADMIN.RU",
                            PasswordHash = "AQAAAAEAACcQAAAAELXaW9zbh3Q4GyRXoJs/3aQ1a11RILnF82PjzJEc6DWqys3Q6JtUQLWAwRD7LkQ8Bg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "945461d7-9f5e-4be1-872b-888cc63a75eb",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.ru"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ceb5881d-6990-4010-9036-b1d1c49e85f7",
                            Email = "mod@mod.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MOD@MOD.RU",
                            NormalizedUserName = "MOD@MOD.RU",
                            PasswordHash = "AQAAAAEAACcQAAAAED76ySbetz1ccHfWKZh9XcnXTZAaph1zrPKFsSQZS5oUCqMDmDb2jDr9AePFchdhSw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "97fbf36f-6fbc-4c20-a342-73b38b2cf0ab",
                            TwoFactorEnabled = false,
                            UserName = "mod@mod.ru"
                        });
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ForumUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "dcd6603d-1e41-4c6b-87aa-541ccf5eb895"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2dbe9c16-990d-4117-8162-8de2bc7bcfcf"
                        });
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ModeratedBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardId")
                        .IsUnique();

                    b.ToTable("ModeratedBoards");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ThreadId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Thread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BoardId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("ForumUserModeratedBoard", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ModeratedBoard", null)
                        .WithMany()
                        .HasForeignKey("ModeratedBoardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shmelev_Backend_Task3.ForumUser", null)
                        .WithMany()
                        .HasForeignKey("ModeratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ForumRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ForumUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ForumUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ForumUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Attachment", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.Post", "Post")
                        .WithMany("Attachments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ForumUserRole", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ForumRole", "Role")
                        .WithMany("ForumUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shmelev_Backend_Task3.ForumUser", "User")
                        .WithMany("ForumUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ModeratedBoard", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.Board", "Board")
                        .WithOne("ModeratedBoard")
                        .HasForeignKey("Shmelev_Backend_Task3.ModeratedBoard", "BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Post", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ForumUser", "Author")
                        .WithMany("AuthoredPosts")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Shmelev_Backend_Task3.Thread", "Thread")
                        .WithMany("Posts")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Thread");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Thread", b =>
                {
                    b.HasOne("Shmelev_Backend_Task3.ForumUser", "Author")
                        .WithMany("AuthoredThreads")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Shmelev_Backend_Task3.Board", "Board")
                        .WithMany("Threads")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Board", b =>
                {
                    b.Navigation("ModeratedBoard");

                    b.Navigation("Threads");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ForumRole", b =>
                {
                    b.Navigation("ForumUserRoles");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.ForumUser", b =>
                {
                    b.Navigation("AuthoredPosts");

                    b.Navigation("AuthoredThreads");

                    b.Navigation("ForumUserRoles");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Post", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("Shmelev_Backend_Task3.Thread", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
