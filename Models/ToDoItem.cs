namespace ToDoList.Models;

public class ToDoItem
{
    // Properties
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; private set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; private set; } = false; // Default completion status to false

    // Constructor
    public ToDoItem(string name, string description, DateTime dueDate)
    {
        Name = name;
        Description = description;
        DueDate = dueDate;
        DateCreated = DateTime.Now; // Log time created
    }

    // Methods
    public void MarkAsComplete()
    {
        IsCompleted = true;
    }

    public void DisplayItem()
    {
        Console.WriteLine($"Item Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Created: {DateCreated}");
        Console.WriteLine($"Due: {DueDate}");
        Console.WriteLine($"Complete: {IsCompleted}");
    }
}