using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_09.Models;
using Project_09.Repositories;
using Project_09.ViewModels;

namespace Project_09.Controllers
{
    [Authorize]
    public class BatchesController : Controller
    {
        IBatchRepository repo;
        public BatchesController(IBatchRepository repo) { this.repo = repo; }
        [AllowAnonymous]
        public IActionResult Index(int pg = 1)
        {
            var data = repo.GetBatches().OrderBy(x => x.BatchId);
            ViewBag.Pager = new PagerModel
            {
                TotalPages = (int)Math.Ceiling((double)data.Count() / 5),
                CurrentPage = pg
            };
            return View(data.Skip((pg - 1) * 5).Take(5).ToList());
        }
        [AllowAnonymous]
        public IActionResult Summary(int pg = 1, string sort = "", string search = "")
        {
            //Thread.Sleep(2000);
            var data = repo.GetSummary();
            ViewBag.Pager = new PagerModel
            {
                TotalPages = (int)Math.Ceiling((double)data.Count() / 5),
                CurrentPage = pg
            };
            if (sort == "") { ViewBag.NameSort = "name"; }
            ViewBag.NameSort = sort == "name" ? "name_desc" : "name";
            ViewBag.CountSort = sort == "count" ? "count_desc" : "count";

            ViewBag.CurrentSort = sort == "" ? "name" : sort;
            ViewBag.Search = search;
            switch (sort)
            {
                case "name":
                    data = data.OrderBy(x => x.BatchName);
                    break;
                case "name_desc":
                    data = data.OrderByDescending(x => x.BatchName);
                    break;
                case "count":
                    data = data.OrderBy(x => x.TraineeCount);
                    break;
                case "count_desc":
                    data = data.OrderByDescending(x => x.TraineeCount);
                    break;
                default:
                    data = data.OrderBy(x => x.BatchId);
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.BatchName.ToLower().StartsWith(search.ToLower()));
            }
            var modelData = data.Skip((pg - 1) * 5).Take(5).ToList();
            ///////////////////////////////////////////////////////////////////////
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_BatchSummary", modelData);
            }
            ///////////////////////////////////////////////////////////////////////
            return View(modelData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Batch dept)
        {
            if (ModelState.IsValid)
            {
                repo.InsertBatch(dept);
                return RedirectToAction("Index");
            }
            return View(dept);
        }
        public IActionResult Edit(int id)
        {
            var batch = repo.GetBatchById(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }
        [HttpPost]
        public IActionResult Edit(Batch batch)
        {
            if (ModelState.IsValid)
            {
                repo.EditBatch(batch);
                return RedirectToAction("Index");
            }
            return View(batch);
        }
        public IActionResult Delete(int id)
        {
            var batch = repo.GetBatchById(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ApplyDelete(int id)
        {

            repo.DeleteBatch(id);
            return RedirectToAction("Index");


        }


    }
}