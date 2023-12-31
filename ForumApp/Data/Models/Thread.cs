﻿using System.ComponentModel.DataAnnotations.Schema;
using MyAPI.ForumApp.Services.Repositories;

namespace MyAPI.ForumApp.Data.Models;

public class Thread : IEntity
{
    public Guid Id { get; set; }
    public string title { get; set; }
    public DateTime date { get; set; }
    public List<Post> posts { get; set; }
    public int numofposts { get; set; }
    public Guid UserId { get; set; }
    public User userowner { get; set; }
    public Guid SubCategoryId { get; set; }
    public SubCategory subcategory { get; set; }
    [NotMapped]
    public Post lastpost { get; set; }


}