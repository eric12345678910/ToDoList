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
    [ValidateAntiForgeryToken]
    public IActionResult Create(TaskList taskList)
    {
        if (ModelState.IsValid)
        {
            taskList.ListId = _taskLists.Count + 1; // Generate unique ID
            _taskLists.Add(taskList);
            return RedirectToAction("Index");
        }

        return View(taskList); // Redirect back if model is not valid
    }

    [HttpGet]
    public IActionResult TaskList(int listId)
    {
        var list = _taskLists.FirstOrDefault(l => l.ListId == listId);
        if (list == null)
        {
            return NotFound();
        }

        // //////////////////////////////////////// Debugging 
        Console.WriteLine($"List Found: {list.Title}");
        return View(list);
    }

/*
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

*/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddItem(int listId, string itemName)
    {
        var list = _taskLists.FirstOrDefault(l => l.ListId == listId);
        // Handle errors: empty list
        if (list == null)
        {
            return NotFound();
        }

        // Handle errors: empty input string
        if (string.IsNullOrWhiteSpace(itemName))
        {
            ModelState.AddModelError("", "Item name cannot be empty.");
            return View(list);
        }

        // Add item to current list
        list.Items.Add(new TaskItem(itemName));

        return RedirectToAction("index");
    }

}

