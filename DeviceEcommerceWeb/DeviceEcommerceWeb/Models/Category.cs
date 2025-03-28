﻿using System.ComponentModel.DataAnnotations.Schema;
namespace DeviceEcommerceWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
