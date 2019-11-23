using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_09.Models
{
    public enum TSP { ACSL,APCL,USSL }
    public class Batch
    {
        public int BatchId { get; set; }
        [Required, StringLength(50), Display(Name = "Batch Name")]
        public string  BatchName { get; set; }

        [Required, Display(Name = "Course Duration Hours")]
        public int CourseHours { get; set; }
       
        //Navigation
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
    public class Trainee
    {
        public int TraineeId { get; set; }
        [Required, StringLength(40), Display(Name = "Employee Name")]
        public string TraineeName { get; set; }
        [Required, StringLength(15)]
        public string Contact { get; set; }
        [Required, StringLength(15)]
        public string TID { get; set; }
   
        [EnumDataType(typeof(TSP))]
        public TSP TSP { get; set; }
        //FK
        [Required, ForeignKey("Batch")]
        public int BatchId { get; set; }
        //Navigation
        public virtual Batch Batch { get; set; }
    }
    public class BatchDbContext : DbContext
    {
        public BatchDbContext(DbContextOptions<BatchDbContext> options) : base(options) { }
        public DbSet<Batch>Batches  { get; set; }
        public DbSet<Trainee>Trainees  { get; set; }
    }
}
