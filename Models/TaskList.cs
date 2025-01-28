using Microsoft.AspNetCore.Http.Features;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

using System;
using System.Collections.Generic;

public class TaskList
{
    // -----------------------------------  Properties

   // public string Description { get; set; }
    public int ListId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = string.Empty;
    
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    
    public string? Status { get; set; }
    public List<TaskItem> Items { get; set; } = new List<TaskItem>();
    
    
    // -----------------------------------  Constructors

    public TaskList()
    {
        Title = string.Empty;
    }
    
    public TaskList(string title)
    {
        Title = title;
    }
    
    public TaskList(int listId, string title)
    {
        ListId = listId;
        Title = title;
        DateCreated = DateTime.Now; // Log time created
    }
    
    // -----------------------------------  Methods
    public void AddItem(TaskItem item)
    {
        Items.Add(item);
    }
    public void RemoveItem(TaskItem item)
    {
        Items.Remove(item);
    }
    public void DisplayList()
    {
        Console.WriteLine($"To-Do List: {Title}");
        Console.WriteLine($"Created: {DateCreated}");
        Console.WriteLine("Items:");

        foreach (var item in Items)
        {
            item.DisplayItem();
        }
    }
}