using EF_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Tutorial.Controllers
{
    public class StudentsController
    {
        private readonly EdDbContext _context;

        public StudentsController()
        {
            _context = new EdDbContext();
        }
        //gets it all
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        //Gets only 1
        public Student GetByPk(int Id)
        {
            return _context.Students.Find(Id);
        }
        public bool Create(Student student)
        {
            student.Id = 0;
            _context.Students.Add(student);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1)
            {
                throw new Exception("Create failed");
            }
            return true;
        }
        public bool Change(int Id, Student student)
        {
            if (Id != student.Id)
            {
                throw new Exception("Ids don't match!");
            }
            //major.Upated = DateTime.Now;       logs the time and date of changes or actions
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1)
            {
                throw new Exception("Create failed");
            }
            return true;
        }
        public bool Remove(int Id)
        {
            var student = _context.Students.Find(Id);
            if (student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }

    }
}
