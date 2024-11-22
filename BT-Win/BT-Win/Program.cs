using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BT_Win
{
    internal class Program
    {


        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student(1, "A", 18));
            students.Add(new Student(2, "B", 17));
            students.Add(new Student(2, "C", 16));
            students.Add(new Student(2, "D", 14));
            students.Add(new Student(2, "E", 15));

            Console.WriteLine(" Danh sach hoc sinh ");
            students.ForEach(student => Console.WriteLine(student));

            Console.WriteLine("Danh sach hs tu 15 den 18 tuoi:");
            var Age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            foreach (var student in Age15to18)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }
            Console.WriteLine();

            Console.WriteLine("Danh sach hoc sinh co ten bat dau bang A :");
            var NameA = students.Where(t => t.Name.StartsWith("A"));
            foreach (var student in NameA)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }

            int Tong = students.Sum(s => s.Age);
            Console.WriteLine("Tong tuoi hoc sinh = " + Tong);
            Console.WriteLine();

            var oldestAge = students.OrderByDescending(s => s.Age).ToList();
            Student student1 = students.FirstOrDefault();
            Console.WriteLine($"Hoc sinh co tuoi lon nhat : ID: {student1.Id}, Name: {student1.Name}, Age: {student1.Age}");

            Console.WriteLine("Danh sach hoc sinh theo tuoi tang dan :");
            var sortedStudents = students.OrderBy(s => s.Age);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }

        }
    }
}
