using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Microsoft.Extensions.FileProviders;
using System.Net.NetworkInformation;
using TaskManagementBD.DAL.Data;
using Task = TaskManagementBD.Models.Task;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//.AddViewLocalization();

builder.Services.AddDbContext<TMContext>(options =>
{   
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//var optionsBuilder = new DbContextOptionsBuilder<TMContext>();

//var options = optionsBuilder.UseSqlServer("Server=(localdb)MSSQLLocalDB;Database=TaskManagement").Options;

//using (TMContext db = new TMContext(options))
//{
//    //db.Database.EnsureDeleted();
//    db.Database.EnsureCreated();
//    // создаем два объекта User
//    Task user1 = new Task { Name = "Tom", IsCompleted = false };
//    Task user2 = new Task { Name = "Alice", IsCompleted = false };

//    // добавляем их в бд
//    db.Tasks.AddRange(user1, user2);
//    db.SaveChanges();    

//}

//using (TMContext db = new TMContext(options))
//{
//    var users = db.Tasks.ToList();
//    Console.WriteLine("Users list:");
//    foreach (Task u in users)
//    {
//        Console.WriteLine($"{u.Id}.{u.Name} - {u.IsCompleted}");
//    }
//}
