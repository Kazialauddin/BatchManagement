using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_09.Models;
using Project_09.ViewModels;

namespace Project_09.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        BatchDbContext db = null;
        public BatchRepository(BatchDbContext db) {
            this.db = db;
            if (!this.db.Batches.Any()) this.SeedDummy();
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

        public IQueryable<Batch> GetBatches()
        {
            return db.Batches;
        }
        public IEnumerable<Trainee> GetTrainees()
        {
            return db.Trainees.Include(x => x.Batch);
        }

        public IQueryable<BatchVM> GetSummary()
        {
            return db.Batches.Include(x => x.Trainees)
                 .Select(x => new BatchVM
                 {
                     BatchId = x.BatchId,
                     BatchName = x.BatchName,
                     TraineeCount = x.Trainees.Count
                 }).AsQueryable();
        }
        public Batch GetBatchById(int id)
        {
            return db.Batches.FirstOrDefault(x => x.BatchId == id);
        }
        public void InsertBatch(Batch batch)
        {
            db.Batches.Add(batch);
            db.SaveChanges();
        }
       

        public void EditBatch(Batch batch)
        {
            db.Entry(batch).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteBatch(int id)
        {
            var batch = new Batch { BatchId = id };
            db.Entry(batch).State = EntityState.Deleted;
            db.SaveChanges();
        }

        
    }
}
