using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication;
using MyAPI.ForumApp.Services.Authentication.Model;
using MyAPI.Services.PasswordHash;
using IAuthentication = MyAPI.Services.Authentication.IAuthentication;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Data.DataSeed;

public static class ForumDataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Category>().HasData(
            new Category
                { Id = Guid.Parse("90c4cfc8-45a4-4161-8c74-732f65a84f89"), name = "Category 1", subcategories = null },
            new Category
                { Id = Guid.Parse("c2515af9-2d60-4239-a774-551cecf0b836"), name = "Category 2", subcategories = null },
            new Category
                { Id = Guid.Parse("833dbbe8-b226-4b88-bd2b-9638f9e782d6"), name = "Category 3", subcategories = null }
        );

        modelBuilder.Entity<SubCategory>().HasData(
            new SubCategory
            {
                Id = Guid.Parse("cefe05d1-5747-4bfc-acb2-8f0d0cadcaf3"), name = "subcategory1",
                CategoryId = Guid.Parse("90c4cfc8-45a4-4161-8c74-732f65a84f89"), category = null, threads = null
            },
            new SubCategory
            {
                Id = Guid.Parse("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6"), name = "subcategory2",
                CategoryId = Guid.Parse("90c4cfc8-45a4-4161-8c74-732f65a84f89"), category = null, threads = null
            },
            new SubCategory
            {
                Id = Guid.Parse("6642cc50-1728-40fc-8656-245166023209"), name = "subcategory3",
                CategoryId = Guid.Parse("90c4cfc8-45a4-4161-8c74-732f65a84f89"), category = null, threads = null
            },
            new SubCategory
            {
                Id = Guid.Parse("10805305-586a-4301-8289-d054bdce87c8"), name = "subcategory4",
                CategoryId = Guid.Parse("c2515af9-2d60-4239-a774-551cecf0b836"), category = null, threads = null
            },
            new SubCategory
            {
                Id = Guid.Parse("d32bda2e-7b46-4aa8-b1aa-5afcdea98f69"), name = "subcategory5",
                CategoryId = Guid.Parse("c2515af9-2d60-4239-a774-551cecf0b836"), category = null, threads = null
            },
            new SubCategory
            {
                Id = Guid.Parse("a522cea4-f16c-47e3-acaf-62c0161b0922"), name = "subcategory6",
                CategoryId = Guid.Parse("833dbbe8-b226-4b88-bd2b-9638f9e782d6"), category = null, threads = null
            }
        );

        modelBuilder.Entity<Thread>().HasData(
            new Thread
            {
                Id = Guid.Parse("d9374b25-64b3-4901-ad55-8a47d3e54275"), title = "thread 1", date = DateTime.Today,
                posts = null, numofposts = 2, UserId = Guid.Parse("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                SubCategoryId = Guid.Parse("cefe05d1-5747-4bfc-acb2-8f0d0cadcaf3")
            },
            new Thread
            {
                Id = Guid.Parse("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"), title = "thread 1", date = DateTime.Today,
                posts = null, numofposts = 2, UserId = Guid.Parse("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                SubCategoryId = Guid.Parse("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6")
            },
            new Thread
            {
                Id = Guid.Parse("8e51677c-37bb-4658-90a5-45a00bf79880"), title = "thread 1", date = DateTime.Today,
                posts = null, numofposts = 2, UserId = Guid.Parse("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                SubCategoryId = Guid.Parse("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6")
            }
        );

        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                Id = Guid.Parse("31a43a68-1c17-44e0-9ca7-aa0226b68eee"), body = "Test Post",
                UserId = Guid.Parse("f36d69a4-9c09-4c08-9da4-a315d2093385"), userposter = null, date = DateTime.Today,
                ThreadId = Guid.Parse("d9374b25-64b3-4901-ad55-8a47d3e54275")
            },
            new Post
            {
                Id = Guid.Parse("582fb677-681f-46db-8327-5c25e835845f"), body = "Test Post",
                UserId = Guid.Parse("f36d69a4-9c09-4c08-9da4-a315d2093385"), userposter = null, date = DateTime.Today,
                ThreadId = Guid.Parse("25fc63f8-9b86-48c2-a75d-40c4f357c1e7")
            },
            new Post
            {
                Id = Guid.Parse("bd936dff-86e8-49bb-85ce-3ad6bea81428"), body = "Test Post",
                UserId = Guid.Parse("f36d69a4-9c09-4c08-9da4-a315d2093385"), userposter = null, date = DateTime.Today,
                ThreadId = Guid.Parse("8e51677c-37bb-4658-90a5-45a00bf79880")
            },
            new Post
            {
                Id = Guid.Parse("272f7784-81ed-4961-b811-afcd1e349caf"), body = "Test Post",
                UserId = Guid.Parse("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), userposter = null, date = DateTime.Today,
                ThreadId = Guid.Parse("8e51677c-37bb-4658-90a5-45a00bf79880")
            },
            new Post
            {
                Id = Guid.Parse("862042a9-b136-4153-a63b-1518ccfc5411"), body = "Test Post",
                UserId = Guid.Parse("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), userposter = null, date = DateTime.Today,
                ThreadId = Guid.Parse("25fc63f8-9b86-48c2-a75d-40c4f357c1e7")
            },
            new Post
            {
                Id = Guid.Parse("138670af-28f1-4f35-8b3d-ea2f471e8aa1"), body = "Test Post",
                UserId = Guid.Parse("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), userposter = null, date = DateTime.Today,
                ThreadId = Guid.Parse("d9374b25-64b3-4901-ad55-8a47d3e54275")
            },
            new Post
            {
                Id = Guid.Parse("4f59aba9-1628-4478-9657-c5ed7e46c38e"), body = "Test Post",
                UserId = Guid.Parse("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), userposter = null, date = DateTime.Today,
                ThreadId = Guid.Parse("8e51677c-37bb-4658-90a5-45a00bf79880")
            }
        );
    }
    
}