using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileapiService.Models
{
    public class ProfileSkillSet
    {
        [Key]
        public int ProfileSkillId { get; set; }
        public int ProfileId { get; set; }
        public string SkillSet { get; set; }
        
    }
}
