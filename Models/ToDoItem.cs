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

    // Methods
}