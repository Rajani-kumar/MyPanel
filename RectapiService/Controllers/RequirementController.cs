using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RectapiService.Models;

namespace RectapiService.Controllers
{
    
    public class RequirementController : ControllerBase
    {

        private DataContext db = new DataContext();
        [Authorize]
        [Route("api/Requirement")]
        [HttpGet]
        public async Task<IActionResult> GetAllRequirements()
        {
            try
            {
                var requirements = db.Requirement.ToList();
                return Ok(requirements);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }

        }
        [Route("api/find")]
        [HttpGet]
        public async Task<IActionResult> find(int id)
        {
            try
            {
                var requirement= db.Requirement.Find(id); 
                return Ok(requirement);
            }
           catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }


        [Route("api/delete")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                db.Requirement.Remove(db.Requirement.Find(id));
                db.SaveChanges(); 
                return Ok("Requirement  Deleted successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

        [Route("api/create")]
        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody]Requirement requirement)
        {
            try
            {
                db.Requirement.Add(requirement);
                db.SaveChanges();
                return Ok("Requirement  Created successfully");
            }
            catch(Exception ex)
            {
                string e = ex.Message;
                return BadRequest();
            }
        }
        [Route("api/update")]
        [HttpPut("update")]
        public async Task<IActionResult> update([FromBody]Requirement requirement)
        {
            try
            {
                db.Entry(requirement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(requirement);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }
    }
}