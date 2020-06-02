using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Lib.Models
{
    public class Exam : Entity
    {
        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public double Mark { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
