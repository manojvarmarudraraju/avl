using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    protected TaskInterface[] tasks = new TaskInterface[] {
        // STUDENTS
        // Instantiate your tasks here as decsribed in the documentation
        new Task1(),
        new Task2()
    };

    public TaskInterface[] GetTasks() {
        return this.tasks;
    }
}
