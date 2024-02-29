using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementBD.Data;

namespace TaskManagementBD.Models
{
    public class Repository
    {
        private static List<Task> tasks = CreateList();
        

        //= new List<Task>();



        public static List<Task> CreateList()
        {
            var _tasks = new List<Task>();
            var options = new DbContextOptionsBuilder<TMContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;")
                    .Options;

            using (TMContext db = new TMContext(options))
            {
                //db.Add(new Task() { Name = "pechen1", Description = "lylylyly" });
                // db.Add(new Task() { Name = "pechen2", Description = "blbylyblybly" });
                // db.SaveChanges();
                
               _tasks = (from task in db.Tasks select task).ToList<Task>();    
            }
            return _tasks;

        }


        public static IEnumerable<Task> Tasks
        {
            get {
                return tasks;
            }            
        }

        public static Task TakeTasks(int num)
        {
             return tasks[num];//[Convert.ToInt32(num)];
        }

        public static void AddTask(Task _task)
        {
            tasks.Add(_task);
        }

        public static void UpdateTask(Task _task)
        {
            var options = new DbContextOptionsBuilder<TMContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;")
                    .Options;

            using (TMContext db = new TMContext(options))
            {
                db.Tasks.Update(_task);
                //db.Add(new Task() { Name = "pechen1", Description = "lylylyly" });
                // db.Add(new Task() { Name = "pechen2", Description = "bbyybyby" });
                 db.SaveChanges();

                
            }
        }


    }
}
