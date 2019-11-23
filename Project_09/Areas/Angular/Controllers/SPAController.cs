using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_09.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ex_09_Project.Areas.Angular.Controllers
{
    [Area("Angular")]
    public class SPAController : Controller
    {
        IBatchRepository repo;
        public SPAController (IBatchRepository repo) { this.repo = repo; }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult TraineeList()
        {
            var data = repo.GetTrainees().Select(x => new {
                x.TraineeId, x.TraineeName, TSP=x.TSP.ToString(), x.BatchId, BatchName=x.Batch.BatchName,Contact=x.Contact,TID=x.TID
            }).ToList();
            return Json(data);
        }
    }
}