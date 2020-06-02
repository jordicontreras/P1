using System;
using System.Collections.Generic;
using ConsoleApp1.Lib.Models;

namespace ConsoleApp1
{
    class Program
    {
        static char EscapeCharacter = 'R';
        static string EscapeWord = "RUNYOUFOOLS";

        //We create the students dictionary
        public static Dictionary<string, Student> StudentsDic = new Dictionary<string, Student>();

        //We create the subjects dictionary
        public static Dictionary<string, Subject> SubjectsDic = new Dictionary<string, Subject>();

        //We create the subjects dictionary
        public static Dictionary<string, Exam> ExamsDic = new Dictionary<string, Exam>();


        static void Main(string[] args)
        {         

            var notasDeAlumnos = new List<double>();
            var keepDoing = true;

            while (keepDoing)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the program to manage the academy");
                Console.WriteLine("To go to the students menu write 'student'");
                Console.WriteLine("To go to the subjects menu write 'subject'");
                Console.WriteLine("To go to the exams menu write 'exam'");
                Console.WriteLine("To go to statistics, write 'statistics'");
                Console.WriteLine("Write 'finish' to end the program");
                Console.WriteLine("What do you want to do?");

                string action = Console.ReadLine();
                
                switch (action)
                {
                    case "student":
                        ShowStudentsMenu();
                        break;
                    case "subject":
                        ShowSubjectsMenu();
                        break;
                    case "exam":
                        ShowExamsMenu();
                        break;
                    case "statistics":

                        break;
                    case "finish":
                        keepDoing = false;
                        break;
                    default:
                        Console.WriteLine("You didn't select a proper option");
                        break;
                }

            }

            var suma = 0.0;

            for (var i = 0; i < notasDeAlumnos.Count; i++)
            {
                suma += notasDeAlumnos[i];
            }

            var average = suma / notasDeAlumnos.Count;
            Console.WriteLine("la media los exámenes es: {0}", average);
        }

        //Redirection to the chosen CRUD option for students by user
        private static void ShowStudentsMenu()
        {
            var studentsMenu = true;
            while (studentsMenu)
            {
                Console.WriteLine();
                ShowStudentsMenuOptions();

                var studentsAction = Console.ReadLine();

                switch (studentsAction)
                {
                    case "all":
                        ShowAllStudents();
                        break;
                    case "create":
                        AddStudent();
                        break;
                    case "update":
                        UpdateStudent();
                        break;
                    case "delete":
                        DeleteStudent();
                        break;
                    case "menu":
                        studentsMenu = false;
                        break;
                    default:

                        break;
                }
            }
            
        }

        //Redirection to the chosen CRUD option for subjects by user
        private static void ShowSubjectsMenu()
        {
            var subjectsMenu = true;
            while (subjectsMenu)
            {
                Console.WriteLine();
                ShowSubjectsMenuOptions();

                var subjectsAction = Console.ReadLine();

                switch (subjectsAction)
                {
                    case "all":
                        ShowAllSubjects();
                        break;
                    case "create":
                        AddSubject();
                        break;
                    case "update":
                        UpdateSubject();
                        break;
                    case "delete":
                        DeleteSubject();
                        break;
                    case "menu":
                        subjectsMenu = false;
                        break;
                    default:

                        break;
                }
            }
        }

        //Redirection to the chosen CRUD option for exams by user
        private static void ShowExamsMenu()
        {
            var examsMenu = true;
            while (examsMenu)
            {
                Console.WriteLine();
                ShowExamsMenuOptions();

                var examsAction = Console.ReadLine();

                switch (examsAction)
                {
                    case "all":
                        ShowAllExams();
                        break;
                    case "create":
                        AddExam();
                        break;
                    case "update":
                        UpdateSubject();
                        break;
                    case "delete":
                        DeleteSubject();
                        break;
                    case "menu":
                        examsMenu = false;
                        break;
                    default:

                        break;
                }
            }
        }

        //Shows the menu with the CRUD options for the students
        private static void ShowStudentsMenuOptions()
        {
            Console.WriteLine("Students menu options");
            Console.WriteLine("");
            Console.WriteLine("To see all the students write 'all'");
            Console.WriteLine("To create a student write 'create'");
            Console.WriteLine("To update an student write 'update'");
            Console.WriteLine("To delete an student write 'delete'");
            Console.WriteLine("To go back to the main menu write 'menu'");
        }

        //Shows the menu with the CRUD options for the subjects
        private static void ShowSubjectsMenuOptions()
        {
            Console.WriteLine("Subjects menu options");
            Console.WriteLine("");
            Console.WriteLine("To see all the subjects write 'all'");
            Console.WriteLine("To create a subject write 'create'");
            Console.WriteLine("To update an subject write 'update'");
            Console.WriteLine("To delete a subject write 'delete'");
            Console.WriteLine("To go back to the main menu write 'menu'");
        }

        //Shows the menu with the CRUD options for the exams
        private static void ShowExamsMenuOptions()
        {
            Console.WriteLine("Exams menu options");
            Console.WriteLine("");
            Console.WriteLine("To see all the exams write 'all'");
            Console.WriteLine("To create an exam write 'create'");
            Console.WriteLine("To update an exam write 'update'");
            Console.WriteLine("To delete an exam write 'delete'");
            Console.WriteLine("To go back to the main menu write 'menu'");
        }



        private static void ShowStatisticsMenu()
        {
            Console.WriteLine("Statistics menu optons");
            Console.WriteLine("");
            Console.WriteLine("To see all the statistic write 'all'");
            Console.WriteLine("To go back to the main menu write 'menu'");
        }

        static void ShowAllStudents()
        {
            foreach(var student in StudentsDic.Values)
            {
                Console.WriteLine($"Student Name: {student.Name} Student DNI: {student.Dni}");
            }
        }

        static void AddStudent()
        {
            bool exit = false;
            var dni = "";
            string studentName;

            while (!exit) 
            {
               
                Console.WriteLine("Introduce the DNI or write 'exit' to exit ");
                dni = Console.ReadLine();

                if (dni == "exit")
                {
                    break;
                }

                else if (StudentsDic.ContainsKey(dni))
                {
                    Console.WriteLine("The dni is already in the students list");
                }

                else if (string.IsNullOrEmpty(dni) || dni.Length != 9)
                {
                    Console.WriteLine("The DNI that you introduced is not correct, try again");
                }
                else
                {
                    Console.WriteLine("The dni was introduced correctly");
                    while (true)
                    {
                        Console.WriteLine("Introduce the name or write 'exit' to exit");
                        studentName = Console.ReadLine();

                        if(studentName == "exit")
                        {
                            exit = true;
                            break;
                        }

                        else if (string.IsNullOrEmpty(studentName))
                        {
                            Console.WriteLine("You have to introduce a name");
                        }
                        else
                        {
                            Student newStudent = new Student
                            {
                                Dni = dni,
                                Name = studentName
                            };
                            StudentsDic.Add(dni, newStudent);
                            Console.WriteLine("The student was created correctly");
                            exit = true;
                            break;
                        }
                    }
                }
            }
        }

        static void DeleteStudent()
        {
            var exit = false;
            var dni = "";

            while (!exit)
            {

                Console.WriteLine("Introduce the DNI of the student to delete or write 'exit' to exit ");
                dni = Console.ReadLine();

                if (dni == "exit")
                {
                    exit = true;
                }
                else if (string.IsNullOrEmpty(dni) || dni.Length != 9)
                {
                    Console.WriteLine("The DNI that you introduced is not correct, try again");
                }
                else if (!StudentsDic.ContainsKey(dni))
                {
                    Console.WriteLine("The DNI you introduced is not in the students list");
                }
                else if (StudentsDic.ContainsKey(dni))
                {
                    StudentsDic.Remove(dni);
                    Console.WriteLine("The student has been removed correctly");
                    exit = true;
                }
                             
            }
        }

        static void UpdateStudent()
        {
            bool exit = false;
            var dni = "";
            string studentName;

            while (!exit)
            {

                Console.WriteLine("Introduce the DNI of the student to update or write 'exit' to exit ");
                dni = Console.ReadLine();

                if (dni == "exit")
                {
                    exit = true;
                }

                else if (string.IsNullOrEmpty(dni) || dni.Length != 9)
                {
                    Console.WriteLine("The DNI that you introduced is not correct, try again");
                }
                else 
                {               
                    if (StudentsDic.ContainsKey(dni))
                    {
                        Console.WriteLine("Introduce the name of the student");
                        studentName = Console.ReadLine();

                        if (string.IsNullOrEmpty(studentName))
                        {
                            Console.WriteLine("Sorry, you need to introduce a name to update the name");
                        }
                        else 
                        { 
                            Student updatedStudent = new Student
                            {
                                Dni = dni,
                                Name = studentName
                            };
                            StudentsDic[dni] = updatedStudent;
                            Console.WriteLine("student name updated correctly");
                            exit = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The DNI is not in the students list");
                    }
                }
            }
        }

        static void AddSubject()
        {
            bool exit = false;
            string subjectName;
            string teacher;

            while (!exit)
            {

                Console.WriteLine("Introduce the subject to add or write 'exit' to exit ");
                subjectName = Console.ReadLine();

                if (subjectName == "exit")
                {
                    exit = true;
                }

                else if (SubjectsDic.ContainsKey(subjectName))
                {
                    Console.WriteLine("The subject is already in the subjects list");
                }

                else if (string.IsNullOrEmpty(subjectName))
                {
                    Console.WriteLine("you need to introduce a name for the subject, try again");
                }
                else
                {
                    Console.WriteLine("The subject was introduced correctly");
                    while (true)
                    {
                        Console.WriteLine("Introduce the teacher or write 'exit' to exit");

                        teacher = Console.ReadLine();

                        if (teacher == "exit")
                        {
                            exit = true;
                            break;
                        }
                        else if (string.IsNullOrEmpty(subjectName))
                        {
                            Console.WriteLine("You need to introduce a name for the teacher, try again");
                        }
                        else{ 
                        Subject newSubject = new Subject
                            {
                                Teacher = teacher,
                                Name = subjectName
                            };
                            SubjectsDic.Add(subjectName, newSubject);
                            Console.WriteLine("The subject was created correctly");
                            exit = true;
                            break;
                        }
                    }
                }
            }
        }

        static void ShowAllSubjects()
        {
            foreach (var subject in SubjectsDic.Values)
            {
                Console.WriteLine($"Subject Name:{subject.Name} Teacher:{subject.Teacher}");
            }
        }

        static void DeleteSubject()
        {
            var exit = false;
            var subjectName = "";

            while (!exit)
            {

                Console.WriteLine("Introduce the name of the subject to delete or write 'exit' to exit ");
                subjectName = Console.ReadLine();

                if (subjectName == "exit")
                {
                    exit = true;
                }
                else if (string.IsNullOrEmpty(subjectName))
                {
                    Console.WriteLine("The subject that you introduced is not correct, try again");
                }
                else
                {
                    if (!SubjectsDic.ContainsKey(subjectName))
                    {
                        Console.WriteLine("The subject that you introduced is not in the subjects list");
                    }
                    else
                    {
                        SubjectsDic.Remove(subjectName);
                        Console.WriteLine("The subject has been removed correctly");
                        exit = true;
                    }
                }
                

            }
        }

        static void UpdateSubject()
        {
            bool exit = false;
            string subjectName;
            string teacher;

            while (!exit)
            {

                Console.WriteLine("Introduce the name of the subject to update or write 'exit' to exit ");
                subjectName = Console.ReadLine();

                if (subjectName == "exit")
                {
                    exit = true;
                }

                else if (string.IsNullOrEmpty(subjectName))
                {
                    Console.WriteLine("You need to introduce a subject, try again");
                }
                else
                {
                    if (SubjectsDic.ContainsKey(subjectName))
                    {

                        Console.WriteLine("Introduce a new name for the teacher");
                        teacher = Console.ReadLine();

                        if(string.IsNullOrEmpty(teacher))
                        {
                            Console.WriteLine("Sorry, you need to introduce a name to update the name");
                        }
                        else
                        {
                            Subject updatedSubject = new Subject
                            {
                                Name = subjectName,
                                Teacher = teacher
                            };
                            SubjectsDic[subjectName] = updatedSubject;
                            Console.WriteLine("Subject updated correctly");
                            exit = true;
                        }

                        
                    }
                    else
                    {
                        Console.WriteLine("The DNI is not in the students list");
                    }
                }
            }
        }

        static void AddExam()
        {
            bool exit = false;
            string exam;
            string mark;

            while (!exit)
            {

                Console.WriteLine("Introduce the Exam or write 'exit' to exit ");
                exam = Console.ReadLine();

                if (exam == "exit")
                {
                    break;
                }

                else if (ExamsDic.ContainsKey(exam))
                {
                    Console.WriteLine("The exam is already in the exams list");
                }

                else if (string.IsNullOrEmpty(exam) || exam.Length < 3)
                {
                    Console.WriteLine("The exam that you introduced is not correct, try again");
                }
                else
                {
                    Console.WriteLine("The exam was introduced correctly");
                    while (true)
                    {
                        Console.WriteLine("Introduce the name or write 'exit' to exit");
                        mark = Console.ReadLine();

                        if (mark == "exit")
                        {
                            exit = true;
                            break;
                        }

                        else if (string.IsNullOrEmpty(mark))
                        {
                            Console.WriteLine("You have to introduce a mark");
                        }
                        else
                        {
                            Exam newExam = new Exam
                            {
                                //E = dni,
                                //Name = studentName
                            };
                            //StudentsDic.Add(dni, newStudent);
                            //Console.WriteLine("The student was created correctly");
                            //exit = true;
                            //break;
                        }
                    }
                }
            }
        }
    }
}
