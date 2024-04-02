using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using www.Boss.org.az.Models.Abstracts;
using www.Boss.org.az.Models.Database;

namespace www.Boss.org.az.Models.Entity
{
    class Worker : Person
    {
        public List<Cv> Cvs { get; set; }
        public List<Vacancy> IncomingVacancies { get; set; }
        public void ShowAllCv(JsonDatabase db)
        {
            int i = 0;
            if (Cvs == null)
                Console.WriteLine("There are currently no CVs!");
            else
            {
                Console.WriteLine($"\t\t\t----------- {Name} {Surname} all Cv -----------");
                this.Show();
                Cvs.ForEach(cv =>
                {
                    Console.WriteLine($"----> Cv {++i}");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Cv guid: {cv.Guid}");
                    Console.ResetColor();
                    cv.Show(db);
                    Console.WriteLine("-----------------------------------------------");
                });
            }
        }
    }


}
