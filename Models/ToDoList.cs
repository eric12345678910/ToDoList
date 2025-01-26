namespace ToDoList.Models;

using System;
using System.Collections.Generic;

public class ToDoList
{
    // Properties
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    
    // Constructor
    public ToDoList(string title, string description)
    {
        Title = title;
        Description = description;
        DateCreated = DateTime.Now; // Log time created
    }
    
    // Methods
    
    
}