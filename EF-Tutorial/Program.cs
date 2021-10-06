using EF_Tutorial.Controlers;
using EF_Tutorial.Models;
using System;
using System.Linq;

namespace EF_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Major major = null;
            var majorsCtrl = new MajorsController();

            var NewMajor = new Major()
            {
                Id = 0, Code = "Musx", Description = "Music", MinSat = 1595
            };
            try
            {
                var rc = majorsCtrl.Create(NewMajor);
                if (!rc)
                {
                    Console.WriteLine("Creation Failed");
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
            NewMajor.Description = "Classical Music";
            majorsCtrl.Change(NewMajor.Id, NewMajor);

            major = majorsCtrl.GetByPk(2);
            Console.WriteLine(major);

            major = majorsCtrl.GetByPk(9999);
            if (major == null)
            {
                Console.WriteLine("not found");
            }
            var majors = majorsCtrl.GetAll();
            foreach (var m in majors)
            {
                Console.WriteLine($"{m.Description}");
            }
            var code = majorsCtrl.GetByCode("GENB");
            Console.WriteLine($"{code.Code}");
            
        }
    }
}
