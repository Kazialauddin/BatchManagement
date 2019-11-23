using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_09.Data;
using Project_09.Models;

namespace Project_09.Controllers
{
    public class HomeController : Controller
    {
         BatchDbContext db = null;
        ApplicationDbContext appDb;
        public HomeController(BatchDbContext db, ApplicationDbContext appDb)
        {
            this.db = db;
            this.appDb =appDb;
            this.db.Database.EnsureCreated();
            this.appDb.Database.EnsureCreated();
            if (!this.db.Batches.Any()) this.SeedDummy();
        }


        public IActionResult Index()
        {
            this.db.Database.EnsureCreated();
         
            if (!this.db.Batches.Any()) this.SeedDummy();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private void SeedDummy()
        {
            db.Batches.AddRange(new Batch[]
                {
                    new Batch{BatchName="ESAD-CS/39",CourseHours=1080},
                    new Batch{BatchName="NT/39",CourseHours=960},
                    new Batch{BatchName="GAVE/39",CourseHours=960 }

                });

            db.SaveChanges();
            db.Trainees.AddRange(new Trainee[]
            {
                    new Trainee{ TraineeName="Kazi", TID="1247335", TSP=TSP.ACSL, Contact="01684094421",BatchId=1},
                   new Trainee{ TraineeName="Helal Uddin", TID="124766", TSP=TSP.ACSL, Contact="01681095451",BatchId=1},
            });
            db.SaveChanges();

        }
    }
}
