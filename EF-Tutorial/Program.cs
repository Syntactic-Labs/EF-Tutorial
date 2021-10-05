using EF_Tutorial.Models;
using System;
using System.Linq;

namespace EF_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var _context = new EdDbContext();
            Console.WriteLine("Major table prac");
            var majors = _context.Majors
                .Where(m => m.Code.Contains("M"))        
                
                .ToList();
            foreach (var m in majors)
            {
                Console.WriteLine($"{m.Code}");
            }
            Console.WriteLine("Student table prac");
            var students = _context.Students
                .Where(s => s.Gpa > 3)
                .ToList();
            foreach (var stud in students)
            {
                Console.WriteLine($"{stud.Firstname} {stud.Lastname} | {stud.Gpa}");
            }
        }
    }
}
