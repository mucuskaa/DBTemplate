﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTemplate.Entities
{
    public class Student : Person
    {
        public Group? Group { get; set; }
    }
}
