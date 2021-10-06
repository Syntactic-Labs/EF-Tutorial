using EF_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Tutorial.Controlers
{
    public class MajorsController
    {
        private readonly EdDbContext _context;     //get set are not nessicary

        public MajorsController()
        {
            _context = new EdDbContext();
        }
        public List<Major> GetAll()
        {
            return _context.Majors.ToList();
        }
        public Major GetByPk(int Id)
        {
            return _context.Majors.Find(Id);
        }
        public Major GetByCode(string Code)
        {
            return _context.Majors.SingleOrDefault(m => m.Code == Code);
        }
        public bool Create(Major major)
        {
            major.Id = 0;
            _context.Majors.Add(major);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1)
            {
                throw new Exception("Create failed");
            }
            return true;
        }
        public bool Change(int Id, Major major)
        {
            if (Id != major.Id)
            {
                throw new Exception("Ids don't match!");
            }
            //major.Upated = DateTime.Now;       logs the time and date of changes or actions
            _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1)
            {
                throw new Exception("Create failed");
            }
            
            return true;
        }
    }
}
