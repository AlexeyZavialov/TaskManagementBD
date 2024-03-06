using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementBD.Data;

namespace TaskManagementBD.Models
{
    public class Repository
    {
        private static List<Task> tasks = CreateList();

        public enum OptionsTask
        {
            take = 1,
            add = 2,
            delete = 3,
            update = 4
        }

        public static List<Task> CreateList()
        {
            var _tasks = new List<Task>();
            var options = new DbContextOptionsBuilder<TMContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;")
                    .Options;

            using (TMContext db = new TMContext(options))                            
               _tasks = (from task in db.Tasks select task).ToList<Task>();    
            
            return _tasks;
        }

        public static IEnumerable<Task> Tasks
        {
            get {
                return tasks;
            }            
        }

        public static Task? ActionTasks(OptionsTask act, int num = 0, Task? _task = null)
        {
            var options = new DbContextOptionsBuilder<TMContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;")
                    .Options;

            using (TMContext db = new TMContext(options))
            {
                switch (act)
                {
                    case OptionsTask.take: return tasks[num];

                    case OptionsTask.add:
                        tasks.Add(_task);
                        db.Add(_task);
                        break;

                    case OptionsTask.delete:
                        tasks.Remove(_task);
                        db.Remove(_task);
                        break; 
                    
                    case OptionsTask.update:
                        db.Tasks.Update(_task); break;
                }
                db.SaveChanges();
            }
            return null;           
        }
       
    }
}
