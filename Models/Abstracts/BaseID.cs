using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.Boss.org.az.Models.Abstracts
{
    abstract class BaseId
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
