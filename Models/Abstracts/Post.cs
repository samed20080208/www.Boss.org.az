using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using www.Boss.org.az.Models.Database;
using www.Boss.org.az.Models.Extentions;

namespace www.Boss.org.az.Models.Abstracts
{
    
    abstract class Post : BaseId
    {
        public uint CategoryId { get; set; }
        public uint SubCategoryId { get; set; }
        public string EducationDegree { get; set; }
        public string Experience { get; set; }
        public List<string> Languages { get; set; }
        public uint ViewCount { get; set; }
        public double Salary { get; set; }
        public string WorkCity { get; set; }
        protected DateTime StartTimePost { get; } = DateTime.Now;
        protected DateTime EndTimePost { get; } = DateTime.Now.AddDays(30);

        public virtual void Show(JsonDatabase db)
        {
            Console.WriteLine($"Category: {db.Categories.ToList().Find(c => c.Id == CategoryId).Name}/{db.SubCategories.ToList().Find(s => s.Id == SubCategoryId).Name}");
            Console.WriteLine($"City: {WorkCity.Trim().ToLower().FirstCharToUpper()}");
            Console.WriteLine($"Salary: {Salary} AZN");
            Console.WriteLine($"Education degree: {EducationDegree.Trim().ToLower().FirstCharToUpper()}");
            Console.WriteLine($"Experience: {Experience}");
            Console.Write($"Language: ");
            if (Languages == null) Console.WriteLine("No knowledge of language!");
            else Languages.ForEach(a => Console.Write($"{a.Trim().ToLower().FirstCharToUpper()} "));
        }
    }
}
