using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.Boss.org.az.Models.Entity
{
    class SubCategory
    {
        public uint Id { get; set; }
        public static uint ID { get; set; }
        public uint CategoryId { get; set; }
        public string Name { get; set; }
        public SubCategory(uint categoryId, string name)
        {
            Id = ++ID;
            CategoryId = categoryId;
            Name = name;
        }
    }
}
