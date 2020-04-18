using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOffer.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Job Description")]
        [AllowHtml]//to allow get html code from the view inside this filed
        public string JobContent { get; set; }
        
        [Display(Name = "Job Picture")]
        public string JobImage { get; set; }
        [Required]
        [Display(Name = "Job Category")]
        public int CategoryId { get; set; }

        public string UserID { get; set; }//the job publisher 
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}