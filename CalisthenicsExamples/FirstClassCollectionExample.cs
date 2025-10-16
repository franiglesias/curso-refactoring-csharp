// Translated from CalisthenicsExamples/first-class-collection.ts
// Preserves first-class collection concept
using System;
using System.Collections.Generic;

namespace CalisthenicsExamples
{
    public class Project
    {
        private TaskCollection tasks = new TaskCollection();

        public void AddTask(string task)
        {
            this.tasks.AddTask(task);
        }

        public List<string> GetTasks()
        {
            return this.tasks.AllTasks();
        }
    }

    public class TaskCollection
    {
        private List<string> tasks = new List<string>();

        public void AddTask(string task)
        {
            this.tasks.Add(task);
        }

        public List<string> AllTasks()
        {
            return this.tasks;
        }
    }
}
