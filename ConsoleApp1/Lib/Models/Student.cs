using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Lib.Models
{
    public class Student : Entity
    {
        public string Name { get; set; }

        public string Dni { get; set; }

        public List<Exam> Exams { get; set; }

    }
}
