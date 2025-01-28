namespace ToDoList.Models;

public class TaskItem
{
    // Properties
    public int TaskItemId { get; set; }
    public string Name { get; set; }
    
    
    public DateTime DateCreated { get; private set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; private set; } = false; // Default completion status to false

    // Constructor
    public TaskItem(string name, string description, DateTime dueDate)
    {
        Name = name;
        DueDate = dueDate;
        DateCreated = DateTime.Now; // Log time created
    }
    
    public TaskItem(string name)
    {
        Name = name;
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
        Console.WriteLine($"Created: {DateCreated}");
        Console.WriteLine($"Due: {DueDate}");
        Console.WriteLine($"Complete: {IsCompleted}");
    }
    
}