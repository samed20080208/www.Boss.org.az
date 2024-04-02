using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using www.Boss.org.az.Models.Database;
using www.Boss.org.az.Models.Entity;
using www.Boss.org.az.Models.Menthods;
using www.Boss.org.az.Models.MenuHelper;

namespace www.Boss.org.az.Models.Menu
{
    static class ProgramMenegment
    {
        public static void Start()
        {
            JsonDatabase db = new();
            db.Workers = new List<Worker>();
            db.Employers = new List<Employer>();
            db.Categories = new List<Category>();
            db.SubCategories = new List<SubCategory>();

            var text = File.ReadAllText("Workers.json");
            db.Workers = JsonSerializer.Deserialize<List<Worker>>(text);
            text = File.ReadAllText("Employers.json");
            db.Employers = JsonSerializer.Deserialize<List<Employer>>(text);
            text = File.ReadAllText("Categories.json");
            db.Categories = JsonSerializer.Deserialize<List<Category>>(text);
            text = File.ReadAllText("Subcategories.json");
            db.SubCategories = JsonSerializer.Deserialize<List<SubCategory>>(text);

            int choise = ConsoleHelper.MultipleChoice(5, 1, 1, true, "Sign in", "Sign up", "Exit");
            while (true)
            {
                switch (choise)
                {
                    case 0:
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("(If you want to go back, type >> back <<)");
                            Console.ResetColor();
                            SignInMenuDisplay(db);
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            SignUpMenuDisplay(db);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Exit...");
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
        private static void SignInMenuDisplay(JsonDatabase db)
        {
            if (db.Workers == null && db.Employers == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There are currently no users!");
                Thread.Sleep(1600);
                Start();
            }
            else
            {
                string username, password;
            UsernameLogin:
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                if (username.Trim().ToLower() == "back")
                    Start();
                else if (!Helpers.IsValidEmpty(username)) goto UsernameLogin;
                PasswordLogin:
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                if (password.Trim().ToLower() == "back")
                    Start();
                else if (!Helpers.IsValidEmpty(password)) goto PasswordLogin;
                if (db.SignIn(username, password) == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Username or password incorrect. Please try again.");
                    Thread.Sleep(2000);
                }
                else if (db.SignIn(username, password).GetType().Name == "Worker")
                    WorkerSide.WorkerMenu(db, db.Workers.FirstOrDefault(w => w.Username == username));
                else if (db.SignIn(username, password).GetType().Name == "Employer")
                    EmployerSide.EmployerMenu(
                        db, db.Employers.Find(e => e.Username == username));
            }
        }
        private static void SignUpMenuDisplay(JsonDatabase db)
        {
            Console.WriteLine("How do you want to register ?");
            int choise2 = ConsoleHelper.MultipleChoice(0, 1, 3, false, "Worker", "Employer", "Back to");
            switch (choise2)
            {
                case 0:
                    {
                        Console.Clear();
                        db.SignUp(true);
                        Start();
                        break;
                    }
                case 1:
                    {
                        Console.Clear();
                        db.SignUp(false);
                        Start();
                        break;
                    }
                case 2:
                    {
                        Start();
                        break;
                    }
            }
        }
    }
}
