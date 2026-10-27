using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ConsoleApp2
{
    public class GradeService
    {
        public static List<GradeDto> Grades = new List<GradeDto>();

        public void RegisterGrade(string studentNo, string studentSubject, int mark)
        {
            int maxId = Grades.Count == 0 ? 0 : Grades.Max(x => x.GradeId);

          StudentDto item =  StudentService.Students.Where(x => x.No == studentNo).FirstOrDefault();

            GradeDto grade = new GradeDto
            {
                GradeId = maxId + 1,
                StudentId = item.Id,
                Subject = studentSubject,
                Mark = mark
                 
            };

            Grades.Add(grade);
            Console.WriteLine("Student grade is added successfully!");
            
        }

        public void ShowGrade()
        {
            foreach (var item in Grades) {

                Console.WriteLine($"Student subject {item.Subject}, Student mark {item.Mark}");
            }
        }
    }
}
