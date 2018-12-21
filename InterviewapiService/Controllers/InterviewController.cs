using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InterviewapiService.Models;
namespace InterviewapiService.Controllers
{
    
    public class InterviewController : ControllerBase
    {
        private DataContext db = new DataContext();
        [Route("api/GetAllInterviews")]
        [HttpGet("GetAllInterviews")]
        public async Task<IActionResult> GetAllInterviews()
        {
            try
            {
                var interviews = db.Interview.ToList();
                return Ok(interviews);
            }
            catch
            {
                return BadRequest();
            }

        }


        [Route("api/GetAllInterviewPannels")]
        [HttpGet("GetAllInterviewPannels")]
        public async Task<IActionResult> GetAllInterviewPannels()
        {
            try
            {
                var interviewPannels = db.InterviewPannel.ToList();
                return Ok(interviewPannels);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }

        }

        [Route("api/GetInterviewById")]
        [HttpGet("GetInterviewById")]
        public async Task<IActionResult> GetInterviewById(int id)
        {
            try
            {
                var interview = (from a in db.Interview
                                       where a.ProfileId == id
                                       select new Interview { InterviewId = a.InterviewId, ProfileId = a.ProfileId, Level = a.Level, Feedback = a.Feedback, Status = a.Status, ScheduledBy=a.ScheduledBy, ScheduledOn=a.ScheduledOn }).ToList();
                return Ok(interview);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }

        }

        [Route("api/GetAllInterviewPannelById")]
        [HttpGet("GetAllInterviewPannelById")]
        public async Task<IActionResult> GetAllInterviewPannelById(string name)
        {
            try
            {
                var interviewpannel = (from a in db.InterviewPannel
                                 where a.InterviewerName == name
                                 select new InterviewPannel { InterviewId = a.InterviewId, PannelId=a.PannelId, InterviewerName=a.InterviewerName }).ToList();
                return Ok(interviewpannel);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }

        }

        [Route("api/CreateInterview")]
        [HttpPost("CreateInterview")]
        public async Task<IActionResult> CreateInterview([FromBody] Interview interview)
        {
            try
            {
                db.Interview.Add(interview);
                db.SaveChanges();
                var k = interview.ProfileId;
                return Ok("Interview  created successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

        [Route("api/CreateInterviewPannel")]
        [HttpPost("CreateInterviewPannel")]
        public async Task<IActionResult> CreateInterviewPannel([FromBody] InterviewPannel interviewpannel)
        {
            try
            {
                db.InterviewPannel.Add(interviewpannel);
                db.SaveChanges();
                var k = interviewpannel.PannelId;
                return Ok("Interview Pannel  created successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }


        [Route("api/InterviewHistory")]
        [HttpPost("InterviewHistory")]
        public async Task<IActionResult> CreateInterviewHistory([FromBody] InterviewHistory interviewhistory)
        {
            try
            {
                db.InterviewHistory.Add(interviewhistory);
                db.SaveChanges();
                var k = interviewhistory.InterviewHistoryId;
                return Ok("InterviewHistory  created successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

        [Route("api/updateInterview")]
        [HttpPut("updateInterview")]
        public async Task<IActionResult> UpdateInterview([FromBody] Interview interview)
        {
            try
            {
                db.Entry(interview).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(interview);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

        [Route("api/UpdateInterviewPannel")]
        [HttpPut("UpdateInterviewPannel")]
        public async Task<IActionResult> UpdateInterviewPannel([FromBody] InterviewPannel interviewpannel)
        {
            try
            {
                db.Entry(interviewpannel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(interviewpannel);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

        [Route("api/deleteInterview")]
        [HttpDelete("deleteInterview/{id}")]
        public async Task<IActionResult> deleteInterview([FromBody] Interview interview)
        {
            try
            {
                
                var result = (from a in db.Interview
                                 where a.ProfileId == interview.ProfileId 
                               select new Interview { InterviewId = a.InterviewId, ProfileId = a.ProfileId, Level = a.Level, Feedback = a.Feedback, Status = a.Status, ScheduledBy = a.ScheduledBy, ScheduledOn = a.ScheduledOn }).ToList();
                db.Interview.RemoveRange(result);
                db.SaveChanges();

                return Ok("Interview Deleted successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }
        [Route("api/DeleteInterviewPannel")]
        [HttpDelete("DeleteInterviewPannel/{id}")]
        public async Task<IActionResult> DeleteInterviewPannel([FromBody] InterviewPannel interviewpannel)
        {
            try
            {

                var result = (from a in db.InterviewPannel
                              where a.InterviewId == interviewpannel.InterviewId
                              select new InterviewPannel { InterviewId = a.InterviewId, PannelId = a.PannelId, InterviewerName = a.InterviewerName}).ToList();
                db.InterviewPannel.RemoveRange(result);
                db.SaveChanges();

                return Ok("Interview Pannel Deleted successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }



    }
}