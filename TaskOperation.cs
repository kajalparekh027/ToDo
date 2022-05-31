using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To.Do {
    internal class TaskOperation {

        bool loadSavedDataOnce = true;
        int todo;
        int done;

        List<Task> taskList = new();
        public void Dashboard() {
            bool quit = true;

            loadSavedData();


            while (quit) {
                countTask();
                Console.Clear();
                Console.WriteLine("Welcome to ToDoLy");
                Console.WriteLine("You have {0} tasks todo and {1} tasks are done!", todo, done);
                Console.WriteLine("--------------");
                Console.WriteLine("Pick an Option:");
                Console.WriteLine("1 - Show Task List (by date or project");
                Console.WriteLine("2 - Add new Task");
                Console.WriteLine("3 - Edit Task (update, mark as done, remove)");
                Console.WriteLine("4 - Save and Quit");
                string choice = Console.ReadLine();
                if (choice == "4") {
                    quit = false;
                    SaveBinaryData();
                    System.Environment.Exit(0);
                } else if (choice == "2") {
                    Add();
                } else if (choice == "1") {
                    Show();
                } else if (choice == "3") {
                    Edit();
                }
            }
        }

        private void countTask() {
            todo = taskList.FindAll(task => task.Status.ToLower() == "ToDo".ToLower()).Count;
            done = taskList.FindAll(task => task.Status.ToLower() == "Done".ToLower()).Count;
        }

        void Add() {
            Task task = new();
            Console.WriteLine("Task - Attribute(Title, DueDate, Staus, Project)");
            Console.Write("Title: ");
            task.Title = Console.ReadLine();

            Console.Write("DueDate(dd/MM/yyyy HH:mm:ss) : ");
            task.DueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Console.Write("Status: ");
            task.Status = Console.ReadLine();

            Console.Write("project: ");
            task.Project = Console.ReadLine();

            taskList.Add(task);
        }

        void Edit() {
            Console.WriteLine("Enter Title to Edit OR Enter to show Task list: ");

            String title = Console.ReadLine();

            if (title == "") {
                Show();
            } else {
                Task task = taskList.Find(x => x.Title == title);
                if (task != null) {

                    Console.Write("DueDate(dd/MM/yyyy HH:mm:ss) : ");
                    task.DueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    Console.Write("Status: ");
                    task.Status = Console.ReadLine();

                    Console.Write("project: ");
                    task.Project = Console.ReadLine();
                } else {
                    Console.WriteLine("Not Found. Press any key to continue");
                    Console.ReadKey();
                }
            }

        }

        void Show() {


            List<Task> tasks = taskList.OrderBy(tasks => tasks.Project).ThenBy(tasks => tasks.DueDate).ToList();

            Console.WriteLine("Title".PadRight(20) + "DueDate".PadRight(25) + "Status".PadRight(20) +
                                 "Project".PadRight(20) + "\n");
            Console.WriteLine("------------------------------------------------------------------------------");

            foreach (Task task in tasks) {

                Console.WriteLine(task.Title.PadRight(20) + task.DueDate.ToString("dd/MM/yyyy HH:mm:ss").PadRight(25) + task.Status.PadRight(20) + task.Project.PadRight(20));
            }
            taskList = tasks;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void loadSavedData() {
            if (loadSavedDataOnce) {
                try {
                    using (Stream stream = File.Open(Path.Combine(".", "taskList.bin"), FileMode.Open)) {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                        taskList = (List<Task>)bformatter.Deserialize(stream);
                        loadSavedDataOnce = false;
                    }
                } catch (Exception ex) { }
            }
        }

        private void SaveBinaryData() {
            //serialize
            using (Stream stream = File.Open(Path.Combine(".", "taskList.bin"), FileMode.Create)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, taskList);
            }
        }

    }
}

