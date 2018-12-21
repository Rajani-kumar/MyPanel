using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewapiService.Models
{
    public class InterviewHistory
    {
        public int InterviewHistoryId { get; set; }
        public int InterviewId { get; set; }
        public int ProfileId { get; set; }
        public int Level { get; set; }
        public string Feedback { get; set; }
        public string Status { get; set; }
        public string ScheduledBy { get; set; }
        public DateTime ScheduledOn { get; set; }
    }
}
