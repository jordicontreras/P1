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

        public string printFields()
        {
            return "Student: " + this.Student.Name + ";" + this.Student.Dni + " | Subject: " + this.Subject.Name + ";Teacher: " + 
                this.Subject.Teacher + " | Mark: " + this.Mark + " | Date: " + this.Timestamp;
        }
    }
}
