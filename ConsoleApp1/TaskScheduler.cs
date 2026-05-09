using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

//the creates a list space for any tasks created, and is dynamic so there's no cap 
List<Task> taskList = new List<Task>();

//intro line just so the user knows what kind of program they're looking at
Console.WriteLine("Welcome to your task scheduler! This program will allow you to add tasks and then view them, letting you see what needs to be done, when, and if any of your projects are overdue.");

/// <summary>
/// this code runs the functionality of actually making the tasks and putting them into the scheduler.
/// </sumary>
while (true)
{
    Console.WriteLine("Would you like to: [A.] Make a new task [B.] View current tasks [C.] Remove a task from the list [D.] All done!");
    string choice = Console.ReadLine();

    // making new task 
    if (choice == "A")
    {
        //collecting the name of the task
        Console.WriteLine("Great! Please enter the name of this task: ");
        string name = Console.ReadLine();

        //collecting the description of the task
        Console.WriteLine("Now enter the description of the task: ");
        string description = Console.ReadLine();

        //collecting the time the task has to be completed (duedate)
        Console.WriteLine("Last thing! Enter the date this task needs to be completed by. It needs to be in yyyy-mm-dd hh:mm format (and it has to be in military time): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        //adds the task by calling the class made at the end of the code and assembling the info just now collected
        taskList.Add(new Task {task_description = description, task_duedate = date});

        //let the user know that it's been added
        Console.WriteLine("Your task has been added!");
    }

    // looking at tasks already made
    else if (choice == "B")
    {
        //calls all tasks previously made and displays their name, decription, and their due date.
        // will also be responsible for the reminder portion of the scheduler 
        Console.WriteLine("Current Tasks: ");
        foreach(var task in taskList)
        {
            //this added status string will display if a task is overdue or if there's still time to get it in on time
            string current_status = "";
            if (DateTime.Now >= task.task_duedate)
            {
                current_status = "OVERDUE!!! Finish ASAP!!!";
            }

            else if (DateTime.Now < task.task_duedate)
            {
                current_status = "On time to complete!";
            }

            Console.WriteLine($"{task.task_name}: {task.task_description} {current_status}, This task needs to be completed by {task.task_duedate}");
        }
    }

    //to remove tasks from the list once you've completed them 
    else if (choice == "C")
    {
        Console.WriteLine("What task do you want to remove from your list? Please enter the name of the task.");
        string taskToRemove = Console.ReadLine();
        
        for (int i = taskList.Count - 1; i >= 0; i--)
        {
            if (taskList[i].task_name.Equals(taskToRemove, StringComparison.OrdinalIgnoreCase))
            {
                taskList.RemoveAt(i);
                Console.WriteLine("The task has been removed!");
            }
        }
    }

    //exits the program
    else if (choice == "D")
    {
        Console.WriteLine("Thanks for using the task scheduler!");
        break;
    }

    //catch all for if someone mistypes when trying to select an option 
    else
    {
        Console.WriteLine("Not a valid input. Please try again.");
    }
}

/// <summary>
/// creates and defines a class named task, so every time task comes up the program will expect a task description and a task due date
/// </summary>
public class Task{
    public string task_name {get;set;}
    public string task_description {get;set;}
    public DateTime task_duedate {get;set;}
}

//in summary:
//code allows user to create tasks and manage those tasks once created
//tasks can be viewed and user will be notified if a task is past the due date
//
