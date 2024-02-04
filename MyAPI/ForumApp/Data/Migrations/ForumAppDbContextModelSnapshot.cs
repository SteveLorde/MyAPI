﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAPI.ForumApp.Data;

#nullable disable

namespace MyAPI.ForumApp.Data.Migrations
{
    [DbContext(typeof(ForumAppDbContext))]
    partial class ForumAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("orderingid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("forumapp_categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"),
                            name = "Category 1",
                            orderingid = 1
                        },
                        new
                        {
                            Id = new Guid("c2515af9-2d60-4239-a774-551cecf0b836"),
                            name = "Category 2",
                            orderingid = 2
                        },
                        new
                        {
                            Id = new Guid("833dbbe8-b226-4b88-bd2b-9638f9e782d6"),
                            name = "Category 3",
                            orderingid = 3
                        });
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ThreadId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<int>("ordernum")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("forumapp_posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31a43a68-1c17-44e0-9ca7-aa0226b68eee"),
                            ThreadId = new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"),
                            UserId = new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                            body = "Test Post",
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            ordernum = 1
                        },
                        new
                        {
                            Id = new Guid("582fb677-681f-46db-8327-5c25e835845f"),
                            ThreadId = new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"),
                            UserId = new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                            body = "Test Post",
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            ordernum = 1
                        },
                        new
                        {
                            Id = new Guid("bd936dff-86e8-49bb-85ce-3ad6bea81428"),
                            ThreadId = new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                            UserId = new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                            body = "Test Post",
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            ordernum = 1
                        },
                        new
                        {
                            Id = new Guid("272f7784-81ed-4961-b811-afcd1e349caf"),
                            ThreadId = new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                            UserId = new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                            body = "Test Post",
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            ordernum = 2
                        },
                        new
                        {
                            Id = new Guid("862042a9-b136-4153-a63b-1518ccfc5411"),
                            ThreadId = new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"),
                            UserId = new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                            body = "Test Post",
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            ordernum = 2
                        },
                        new
                        {
                            Id = new Guid("138670af-28f1-4f35-8b3d-ea2f471e8aa1"),
                            ThreadId = new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"),
                            UserId = new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                            body = "Test Post",
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            ordernum = 2
                        },
                        new
                        {
                            Id = new Guid("4f59aba9-1628-4478-9657-c5ed7e46c38e"),
                            ThreadId = new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                            UserId = new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                            body = "Test Post",
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            ordernum = 3
                        });
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("forumapp_subcategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cefe05d1-5747-4bfc-acb2-8f0d0cadcaf3"),
                            CategoryId = new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"),
                            name = "subcategory1"
                        },
                        new
                        {
                            Id = new Guid("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6"),
                            CategoryId = new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"),
                            name = "subcategory2"
                        },
                        new
                        {
                            Id = new Guid("6642cc50-1728-40fc-8656-245166023209"),
                            CategoryId = new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"),
                            name = "subcategory3"
                        },
                        new
                        {
                            Id = new Guid("10805305-586a-4301-8289-d054bdce87c8"),
                            CategoryId = new Guid("c2515af9-2d60-4239-a774-551cecf0b836"),
                            name = "subcategory4"
                        },
                        new
                        {
                            Id = new Guid("d32bda2e-7b46-4aa8-b1aa-5afcdea98f69"),
                            CategoryId = new Guid("c2515af9-2d60-4239-a774-551cecf0b836"),
                            name = "subcategory5"
                        },
                        new
                        {
                            Id = new Guid("a522cea4-f16c-47e3-acaf-62c0161b0922"),
                            CategoryId = new Guid("833dbbe8-b226-4b88-bd2b-9638f9e782d6"),
                            name = "subcategory6"
                        });
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.Thread", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("forumapp_threads");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"),
                            SubCategoryId = new Guid("cefe05d1-5747-4bfc-acb2-8f0d0cadcaf3"),
                            UserId = new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            title = "thread 1"
                        },
                        new
                        {
                            Id = new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"),
                            SubCategoryId = new Guid("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6"),
                            UserId = new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            title = "thread 1"
                        },
                        new
                        {
                            Id = new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                            SubCategoryId = new Guid("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6"),
                            UserId = new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                            date = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            title = "thread 1"
                        });
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("hashedpassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("profileimage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("usertype")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("forumapp_users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                            date = new DateTime(2024, 2, 4, 18, 0, 26, 23, DateTimeKind.Local).AddTicks(6983),
                            email = "testuser1@gmail.com",
                            hashedpassword = "TiaSS3yu07Yx2dZ+YvpjJw==.MoUHP/6P+U0MzO3YAJwFQx2bD2AySUdiyrUicBGBXz4=",
                            profileimage = "",
                            username = "testuser1",
                            usertype = "user"
                        },
                        new
                        {
                            Id = new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                            date = new DateTime(2024, 2, 4, 18, 0, 26, 23, DateTimeKind.Local).AddTicks(7066),
                            email = "testuser2@gmail.com",
                            hashedpassword = "4gbxO8GXZHQPXPkSs+4I5g==.JHyZsmPEwQgk7rsF/4uhfDd3WKPwA35Siu5UhwNZIK8=",
                            profileimage = "",
                            username = "testuser2",
                            usertype = "user"
                        });
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.Post", b =>
                {
                    b.HasOne("MyAPI.ForumApp.Data.Models.Thread", "thread")
                        .WithMany("posts")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAPI.ForumApp.Data.Models.User", "userposter")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("thread");

                    b.Navigation("userposter");
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.SubCategory", b =>
                {
                    b.HasOne("MyAPI.ForumApp.Data.Models.Category", "category")
                        .WithMany("subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.Thread", b =>
                {
                    b.HasOne("MyAPI.ForumApp.Data.Models.SubCategory", "subcategory")
                        .WithMany("threads")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAPI.ForumApp.Data.Models.User", "userowner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subcategory");

                    b.Navigation("userowner");
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.Category", b =>
                {
                    b.Navigation("subcategories");
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.SubCategory", b =>
                {
                    b.Navigation("threads");
                });

            modelBuilder.Entity("MyAPI.ForumApp.Data.Models.Thread", b =>
                {
                    b.Navigation("posts");
                });
#pragma warning restore 612, 618
        }
    }
}
