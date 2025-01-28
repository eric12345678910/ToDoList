namespace ToDoList.Controllers;

using ToDoList.Models;
using Microsoft.AspNetCore.Mvc;

public class ProjectController : Controller
{
    private static List<TaskList> _taskLists = new List<TaskList>();
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(_taskLists); // Output all task lists
    }
    
    // Form to create a new list
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskList list)
    {
        list.ListId = _taskLists.Count + 1; // Generate unique ID
        _taskLists.Add(list);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult TaskList(int listId)
    {
        var list = _taskLists.FirstOrDefault(l => l.ListId == listId);
        if (list == null)
        {
            return NotFound();
        }
        return View(//list //
                    );
    }
 

    [HttpGet]
    public IActionResult AddItem(int listId)
    {
        var list = _taskLists.FirstOrDefault(l => l.ListId == listId);
        if (list == null)
        {
            return NotFound();
        }
        return View(list);
    }

    [HttpPost]
    public IActionResult AddItem(int listId, string itemName)
    {
        var list = _taskLists.FirstOrDefault(l => l.ListId == listId);
        if (list == null)
        {
            return NotFound();
        }
        
        // Add item to list
        var newItem = new TaskItem( itemName );
        list.Items.Add(newItem);

        return RedirectToAction("Index");
    }
}

