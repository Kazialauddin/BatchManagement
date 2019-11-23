using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_09.ViewModels
{
    public class BatchVM
    {
        public int BatchId { get; set; }
        [Display(Name = "Batch Name")]
        public string BatchName { get; set; }
        [Display(Name = "Course Hours")]
        public int CourseHours { get; set; }
       
        public int TraineeCount { get; set; }

    }
}
