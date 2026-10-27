
using Sep2026.ConsoleApp2;

Start:
Console.WriteLine("Student Management System");



    Console.WriteLine("Choose management system");

    Console.WriteLine("1. Student Registration");
    Console.WriteLine("2. Grade Registration");
    Console.WriteLine("3. Exit the app");

    Console.Write("Please select an option 1 or 2:");
    string option = Console.ReadLine();

    switch (option)
    {
            case "1":
            Console.Write("Enter student number: ");
            string number = Console.ReadLine();

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter class number: ");
            string classNumber = Console.ReadLine();

            StudentService studentService = new StudentService();
            studentService.RegisterStudent(number, name, classNumber);
             studentService.ShowStudents();
           

            break;

            case "2":
            Console.Write("Enter student number: ");
            string studentNumber = Console.ReadLine();

            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();

            Console.Write("Enter mark: ");
            string mark = Console.ReadLine();
            int studentMark = Convert.ToInt32(mark);


             GradeService gradeService = new GradeService();
            gradeService.RegisterGrade(studentNumber, subject, studentMark);
              gradeService.ShowGrade();
       

        

            break;

            case "3":

        goto End;
            break;

    default:
        break;
        


    }






goto Start;
End:
Console.WriteLine("Exiting app...");
Console.ReadLine();
