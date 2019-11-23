using Project_09.Models;
using Project_09.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_09.Repositories
{
    public interface IBatchRepository
    {
        IQueryable<BatchVM> GetSummary();
        IQueryable<Batch> GetBatches();
        IEnumerable<Trainee> GetTrainees();
        Batch GetBatchById(int id);
        void InsertBatch(Batch batch);
        void EditBatch(Batch dept);
        void DeleteBatch(int id);

    }
}
