﻿using EF_Tutorial.Controlers;
using EF_Tutorial.Controllers;
using EF_Tutorial.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Tutorial
{
    class Program
    {   //async example refer to MajorsController lines 20 - 22
        //*           *  Task is replaces Void
        async static Task Main(string[] args)
        {
            var majCtrl = new MajorsController();
            //             *
            var majors = await majCtrl.GetAll();
            //abreveated for each
            majors.ForEach(m => Console.WriteLine(m));

            var major = await majCtrl.GetByPk(1);
            Console.WriteLine(major);
        }
        







        //static void mctl() { 
        //    Major major = null;
        //    var majorsCtrl = new MajorsController();

        //    var NewMajor = new Major()
        //    {
        //        Id = 0, Code = "Musx", Description = "Music", MinSat = 1595
        //    };
        //    try
        //    {
        //        var rcl = majorsCtrl.Create(NewMajor);
        //        if (!rcl)
        //        {
        //            Console.WriteLine("Creation Failed");
        //        }
        //    } catch (Exception ex)
        //    {
        //        Console.WriteLine($"Exception occurred: {ex.Message}");
        //    }
        //    NewMajor.Description = "Classical Music";
        //    majorsCtrl.Change(NewMajor.Id, NewMajor);

        //    var rc = majorsCtrl.Remove(NewMajor.Id);
        //    if (!rc)
        //    {
        //        Console.WriteLine("Remove Failed");
        //    }

        //    major = majorsCtrl.GetByPk(2);
        //    Console.WriteLine(major);

        //    major = majorsCtrl.GetByPk(9999);
        //    if (major == null)
        //    {
        //        Console.WriteLine("not found");
        //    }
        //    var majors = majorsCtrl.GetAll();
        //    foreach (var m in majors)
        //    {
        //        Console.WriteLine($"{m.Description}");
        //    }
        //    var code = majorsCtrl.GetByCode("GENB");
        //    Console.WriteLine($"{code.Code}");
            
        //}
    }
}
