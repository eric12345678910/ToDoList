using Microsoft.AspNetCore.Http.Features;
using System.ComponentModel.DataAnnotations;


namespace ToDoList.Models;

using System;
using System.Collections.Generic;

public class ToDoList
{
    // Properties
    public int ListId { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    
    public string? Status { get; set; }
    public List<ToDoItem> Items { get; private set; } = new List<ToDoItem>();
    
    // Constructor
    public ToDoList(string title, string description)
    {
        Title = title;
        Description = description;
        DateCreated = DateTime.Now; // Log time created
    }
    
    // Methods
    public void AddItem(ToDoItem item)
    {
        Items.Add(item);
    }
    public void RemoveItem(ToDoItem item)
    {
        Items.Remove(item);
    }
    public void DisplayList()
    {
        Console.WriteLine($"To-Do List: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Created: {DateCreated}");
        Console.WriteLine("Items:");

        foreach (var item in Items)
        {
            item.DisplayItem();
        }
    }
}