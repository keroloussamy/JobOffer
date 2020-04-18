using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobOffer.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
        public string Cv { get; set; }
        public DateTime ApplyTime { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }//the applier searcher


        public virtual Job Job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}