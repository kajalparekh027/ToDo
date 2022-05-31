using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace To.Do {
    internal class AddTask {
        static void Main(string[] args) {
            List<Todo> todos = AddTask();
            AddTask addTask = new AddTask();
            todos = SortTodosByDuedateandProject(todos);
            Dashboard();
            /* Console.WriteLine("Tasktitle".PadRight(15) + "Duedate".PadRight(15) + "Status".PadRight(15) + "Project".PadRight(15));
             string ITasktitle = Console.ReadLine();
             string IDuedate = Console.ReadLine();
             string IStatus = Console.ReadLine();
             string IProject = Console.ReadLine();*/
            /*Console.ReadLine();

            static List<Todo> AddTask() {
                Todo todo = new Todo();
              
                return new List<Todo>();

                
            }

            static void Dashboard() {
                bool exit = true;
                while (exit) {
                    Console.Clear();
                    Console.WriteLine("Tasktitle", "Duedate", "Status", "Project");
                    Console.WriteLine("AddTask");
                    Console.WriteLine("-----------");
                    Console.WriteLine("Enter");
                    Console.WriteLine("'Add/a'to add Task");
                    Console.WriteLine("'quit/q'to exit Task");
                    Console.WriteLine("'show/s'to show Task");

                    string Choice = Console.ReadLine();
                    if (Choice == "q") {
                        System.Environment.Exit(0);
                    } else if (Choice == "a") {
                        Add();
                    } else if (Choice == "s") {
                        Show();

                    }
                }
            }

            static void Show() {
                Console.Clear();
                List<Todo> todos = new List<Todo>();
                todos = SortTodosByDuedateandProject(todos);
                

                foreach (Todo todo in todos) {
                    Console.WriteLine("Tasktitle".PadRight(15) + "Duedate".PadRight(15) + "Status".PadRight(15) + "Project".PadRight(15));
                    

                }
                
            }

            static void Add() {


            }
        }

        private static List<Todo> SortTodosByDuedateandProject(List<Todo> todos) {
            todos = todos.OrderBy(todos => todos.Duedate).ThenBy(todos => todos.Project).ToList();
            return todos;
        }
    }
} */


    



