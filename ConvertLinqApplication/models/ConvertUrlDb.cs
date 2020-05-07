using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertLinqApplication.models
{
  


    public class Url
    {
        public int UrlId { get; set; }
        public string MainUrl { get; set; }
        [MaxLength(15)]
        public string ConvertedUrl { get; set; }
        
    }


    public class Visit
    {
        public int VisitId { get; set; }
        public int CountVisit { get; set; }
        [ForeignKey("Url")]
        public int UserId { get; set; }
        public Url Url { get; set; }


    }
}
