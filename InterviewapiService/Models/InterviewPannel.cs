using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewapiService.Models
{
    public class InterviewPannel
    {
        [Key]
        public int PannelId { get; set; }
        public int InterviewId { get; set; }
        public string InterviewerName { get; set; }
       
    }
}
