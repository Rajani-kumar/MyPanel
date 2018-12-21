using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileapiService.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int RequirementId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string AltContactNo { get; set; }
        public string Source { get; set; }
        public string SourceDescription { get; set; }
        public string ProfileResume { get; set; }
        public DateTime? ProfileCreatedDate { get; set; }


    }
}
