using System;
using System.Collections.Generic;
using ConsoleApp1.Lib.Models;

namespace ConsoleApp1
{
    class Program
    {

        //Variable that will autoincrement to have a different key everytime we create an Exam in the dictionary
        public static int examNumber = 1;

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

            //Loop with the menu to choose student|subject|exam|statistics section
            while (keepDoing)
            {
                //Academy Menu
                Console.WriteLine();
                Console.WriteLine("Welcome to the program to manage the academy");
                Console.WriteLine("To go to the students menu write 'student'");
                Console.WriteLine("To go to the subjects menu write 'subject'");
                Console.WriteLine("To go to the exams menu write 'exam'");
                Console.WriteLine("To go to statistics, write 'statistics'");
                Console.WriteLine("Write 'finish' to end the program");
                Console.WriteLine("What do you want to do?");

                string action = Console.ReadLine();
                
                //Depending on the chosen option we show the concrete menu section
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
                        statistics();
                        break;
                    case "finish":
                        keepDoing = false;
                        break;
                    default:
                        Console.WriteLine("You didn't select a proper option");
                        break;
                }
            }
        }

        //Redirection to the chosen CRUD option for students by user
        private static void ShowStudentsMenu()
        {
            var studentsMenu = true;

            //Loop that shows the students menu to choose the action we want to do
            while (studentsMenu)
            {
                Console.WriteLine();
                
                //Call to the function that shows the menu options for the students
                ShowStudentsMenuOptions();

                //We read the action chosen by the user
                var studentsAction = Console.ReadLine();

                //Depending on the chosen option we redirect to the concrete CRUD function of the student  
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

            //Loop that shows the subjects menu to choose the action we want to do
            while (subjectsMenu)
            {
                Console.WriteLine();

                //Call to the function that shows the menu options for the subjects
                ShowSubjectsMenuOptions();

                //We read the action chosen by the user
                var subjectsAction = Console.ReadLine();

                //Depending on the chosen option we redirect to the concrete CRUD function of the student
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

            //Loop that shows the exams menu to choose the action we want to do
            while (examsMenu)
            {
                Console.WriteLine();

                //Call to the function that shows the menu options for the exams
                ShowExamsMenuOptions();

                //We read the action chosen by the user
                var examsAction = Console.ReadLine();

                //Depending on the chosen option we redirect to the concrete CRUD function of the exam
                switch (examsAction)
                {
                    case "all":
                        ShowAllExams();
                        break;
                    case "create":
                        AddExam();
                        break;
                    case "update":
                        UpdateExam();
                        break;
                    case "delete":
                        DeleteExam();
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

        //Function to show all students
        static void ShowAllStudents()
        {
            foreach(var student in StudentsDic.Values)
            {
                Console.WriteLine($"Student Name: {student.Name} Student DNI: {student.Dni}");
            }
        }

        //Function to add an student
        static void AddStudent()
        {
            bool exit = false;
            string dni;
            string studentName;

            //Loop that will keep on until the user asks for exit or the student is added correctly
            while (!exit) 
            {
               
                Console.WriteLine("Introduce the DNI or write 'exit' to exit ");

                //We save the introduced student DNI by the user
                dni = Console.ReadLine();

                if (dni == "exit")
                {
                    break;
                }

                //We check if the DNI format is correct
                else if (string.IsNullOrEmpty(dni) || dni.Length != 9)
                {
                    Console.WriteLine("The DNI that you introduced is not correct, try again");
                }

                //We check on the dictionary to see if contains they student DNI to avoid duplicates
                else if (StudentsDic.ContainsKey(dni))
                {
                    Console.WriteLine("The dni is already in the students list");
                }
                 
                //If everything is ok we ask for the student name
                else
                {
                    Console.WriteLine("The dni was introduced correctly");

                    //We keep in the loop until the name is correct and we Introduce the student in the dictionary or the user asks for exit
                    while (true)
                    {
                        Console.WriteLine("Introduce the name or write 'exit' to exit");
                        //We save the student name introduced by the user
                        studentName = Console.ReadLine();

                        if(studentName == "exit")
                        {
                            exit = true;
                            break;
                        }

                        //We check if the user Introduced correctly a student name
                        else if (string.IsNullOrEmpty(studentName))
                        {
                            Console.WriteLine("You have to introduce a name");
                        }

                        //if everything is ok we introduce the student in the dictionary
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

        //Function to delete an student
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

        //Function to update an student
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

        //Function to show all subjects
        static void ShowAllSubjects()
        {
            foreach (var subject in SubjectsDic.Values)
            {
                Console.WriteLine($"Subject Name:{subject.Name} Teacher:{subject.Teacher}");
            }
        }

        //Function to add a subject
        static void AddSubject()
        {
            bool exit = false;
            string subjectName;
            string teacher;

            //Loop that will keep on until the user asks for exit or the subject is added correctly
            while (!exit)
            {

                Console.WriteLine("Introduce the subject to add or write 'exit' to exit ");

                //We save the subject name introduced by the user
                subjectName = Console.ReadLine();

                if (subjectName == "exit")
                {
                    exit = true;
                }

                //We check if the user introduced a value
                else if (string.IsNullOrEmpty(subjectName))
                {
                    Console.WriteLine("you need to introduce a name for the subject, try again");
                }

                //We check if the subjects dictionary has already the subject name to avoid duplicates
                else if (SubjectsDic.ContainsKey(subjectName))
                {
                    Console.WriteLine("The subject is already in the subjects list");
                }

                //if everything is ok we continue to ask for the teacher
                else
                {
                    Console.WriteLine("The subject was introduced correctly");

                    //We keep in the loop until the teacher name is correct and we Introduce the subject in the dictionary or the user asks for exit
                    while (true)
                    {
                        Console.WriteLine("Introduce the teacher or write 'exit' to exit");

                        //we save the teacher name introduced by the user
                        teacher = Console.ReadLine();

                        if (teacher == "exit")
                        {
                            exit = true;
                            break;
                        }

                        //We check if the user introduced a value
                        else if (string.IsNullOrEmpty(subjectName))
                        {
                            Console.WriteLine("You need to introduce a name for the teacher, try again");
                        }

                        //if everything is ok we introduce the subject in the dictionary
                        else
                        { 
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

        //Function to delete a subject
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

        //Function to update a subject
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

        //Function to add an exam
        static void AddExam()
        {
            bool exit = false;
            string studentDNI;
            bool correctMark = false;
            string mark;
            //Student foundStudent;
            bool subject = false;
            string subjectName;
            double itsmark;
            //Subject foundSubject;

            //Loop that will keep on until the user asks for exit or the exam is added correctly
            while (!exit)
            {

                Console.WriteLine("To add an Exam Introduce first the student DNI or write 'exit' to exit ");
                //we save the student DNI
                studentDNI = Console.ReadLine();

                if (studentDNI == "exit")
                {
                    break;
                }

                else
                {
                    //we check if the student exists in the dictionary
                    if (StudentsDic.ContainsKey(studentDNI))
                    {
                        //We save the student object
                        StudentsDic.TryGetValue(studentDNI, out Student foundStudent);
                        Console.WriteLine($"The student is: {foundStudent.Name}");

                        //Loop that will keep on until the user asks for exit or the subject is found in the subjects dictionary
                        while (!subject)
                        {
                            Console.WriteLine("Now you need to write the subject of the Exam or write 'exit' to exit ");

                            //we save the subject introduced by the user
                            subjectName = Console.ReadLine();

                            //we check if the subject dictionary contains the introduced subject by the user
                            if (SubjectsDic.ContainsKey(subjectName))
                            {
                                //we save the found subject
                                SubjectsDic.TryGetValue(subjectName, out Subject foundSubject);
                                Console.WriteLine($"The subject name is {subjectName}");
                                subject = true;

                                //Loop that will keep on until the user asks for exit or the mark is introduced correctly
                                while (!correctMark)
                                {
                                    Console.WriteLine("Now introduce the mark for the Exam or write 'exit' to exit ");

                                    //we save the introduced mark by the user
                                    mark = Console.ReadLine();

                                    if(mark == "exit")
                                    {
                                        break;
                                    }

                                    //we check if the user introduced a value for the mark
                                    else if(string.IsNullOrEmpty(mark))
                                    {
                                        Console.WriteLine("You have to introduce the mark");
                                    }

                                    //we check if the mark introduced is a double
                                    else if (!Double.TryParse(mark.Replace('.', ','), out itsmark))
                                    {
                                        Console.WriteLine("The introduced mark is not in the right format");
                                    }

                                    //if everything is ok we introduce the exam in the dictionary
                                    else
                                    {
                                        Exam newExam = new Exam
                                        {
                                            Student = foundStudent,
                                            Subject = foundSubject,
                                            Mark = (double)itsmark,
                                            Timestamp = DateTime.Now
                                        };
                                        var examID = "Exam" + examNumber;
                                        ExamsDic.Add(examID, newExam);
                                        examNumber++;
                                        Console.WriteLine("Exam created correctly");
                                        exit = true;
                                        break;                                        
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("We haven't found this subject, try again.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("We haven't found this student, try again.");
                    }
                    
                }

            }
        }

        //Function to Update an exam
        static void UpdateExam()
        {
            //bool to control to keep or exit of this action(UPDATE)
            bool exit = false;
            //bool to control if we got a correct Mark from the introduced data by user
            bool correctMark = false;
            //variable to save the Mark value
            string mark;
            //variable for the examID we will search on the Exams dictionary
            string examID;


            //Loop that will keep on until the user asks for exit or the exam is updated correctly
            while (!exit)
            {

                Console.WriteLine("Introduce the ID of the Exam you want to update or write 'exit' to exit ");
                //We save the value introduced by the user
                examID = Console.ReadLine();

                if (examID == "exit")
                {
                    break;
                }

                //We check if the Exam ID is in the dictionary
                else
                {
                    if (ExamsDic.ContainsKey(examID))
                    {
                        ExamsDic.TryGetValue(examID, out Exam foundExam);
                        Console.WriteLine($"ExamID: {examID} | Subject: {foundExam.Subject.Name} | Student: {foundExam.Student.Name};{foundExam.Student.Dni}" +
                            $" | Mark:{foundExam.Mark} | Date:{foundExam.Timestamp}");

                        //Loop that will keep on until the user asks for exit or the Mark that is introduced has a correct formal
                        while (!correctMark)
                        {
                            Console.WriteLine("Now introduce the new mark for the Exam to update or write 'exit' to exit ");
                            //We save the mark introduced by the user
                            mark = Console.ReadLine();

                            if (mark == "exit")
                            {
                                break;
                            }
                            //We check if the user has introduced a value for the mark
                            else if (string.IsNullOrEmpty(mark))
                            {
                                Console.WriteLine("You have to introduce the mark");
                            }
                            //We check if the user has introduced a value that can be parsed to double
                            else if (!Double.TryParse(mark, out double itsmark))
                            {
                                Console.WriteLine("The introduced mark is not in the right format");
                            }

                            //if everything it's ok we update the mark of the exam
                            else
                            {
                                foundExam.Mark = itsmark;
                                
                                ExamsDic[examID] = foundExam;
                                Console.WriteLine("Exam Mark updated correctly");
                                exit = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("We haven't found this Exam, try again.");
                    }

                }

            }
        }

        //Function to delete a subject
        static void DeleteExam()
        {
            var exit = false;
            string examID;

            //Loop that will keep on until the user asks for exit or the exam is deleted
            while (!exit)
            {

                Console.WriteLine("Introduce the ID of the Exam to delete or write 'exit' to exit ");
                //We save the exam ID introduced by the user
                examID = Console.ReadLine();

                if (examID == "exit")
                {
                    exit = true;
                }
                //we check if the user has introduced a value
                else if (string.IsNullOrEmpty(examID))
                {
                    Console.WriteLine("You need to introduce an Exam ID, try again");
                }
                else
                {
                    //We check if the dictionary has the Exam ID introduced by the user
                    if (!ExamsDic.ContainsKey(examID))
                    {
                        Console.WriteLine("The Exam ID that you introduced is not in the Exams list");
                    }
                    //if everything it's ok we delete the exam
                    else
                    {
                        ExamsDic.Remove(examID);
                        Console.WriteLine("The Exam has been removed correctly");
                        exit = true;
                    }
                }


            }
        }

        //Function to show all exams
        static void ShowAllExams()
        {
            foreach (KeyValuePair<string, Exam> Exam in ExamsDic)
            {
                Console.WriteLine("Exam ID: " + Exam.Key + " | " + Exam.Value.printFields());
            }
        }

        //Function to show the average of the exam Marks
        static void statistics()
        {
            var totalMark = 0.0;
            var examsCounter = 0;

            foreach(var exam in ExamsDic.Values)
            {
                totalMark += exam.Mark;
                examsCounter++;
            }

            //We calculate the average
            var average = totalMark / examsCounter;
            Console.WriteLine($"Exams total number: {examsCounter}");
            Console.WriteLine($"Average score of the exams: {average}");
        }
    }
}
