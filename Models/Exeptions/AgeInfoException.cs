﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.Boss.org.az.Models.Exeptions
{
    class AgeInfoException : ApplicationException
    {
        public AgeInfoException(string message) : base(message) { }
    }
}
