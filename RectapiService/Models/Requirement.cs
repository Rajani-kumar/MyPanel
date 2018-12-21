using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectapiService.Models
{
    public class Requirement
    {
        public int RequirementId { get; set; }
        public string Description { get; set; }
        public int NoOfOpenings { get; set; }
        public string SkillSet { get; set; }
        public int Status { get; set; }
        public string RaisedBy { get; set; }
        public DateTime RaisedDate { get; set; }
        public string Owner { get; set; }
        public string Client { get; set; }
        public string Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
