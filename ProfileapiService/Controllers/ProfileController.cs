using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileapiService.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ProfileapiService.Controllers
{

    [ApiController]
    public class ProfileController : ControllerBase
    {
        private DataContext db = new DataContext();
        [Route("api/Profile")]
        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            try
            {
                var profiles = db.Profile.ToList();
                return Ok(profiles);
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("api/GetProfileSkillSet")]
        [HttpGet("GetProfileSkillSet")]
        public async Task<IActionResult> GetProfileSkillSet(int id)
        {
            try
            {
                var profileskillset = (from a in db.ProfileSkillSet
                                       where a.ProfileId ==id
                                       select new ProfileSkillSet { ProfileSkillId = a.ProfileSkillId, ProfileId = a.ProfileId, SkillSet = a.SkillSet }).ToList();
                return Ok(profileskillset);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }

        }
        [Route("api/CreateProfileSkillset")]
        [HttpPost("CreateProfileSkillset")]
        public async Task<IActionResult> CreateProfileSkillset([FromBody] ProfileSkillSet profileskillset)
        {
            try
            {
                db.ProfileSkillSet.Add(profileskillset);
                db.SaveChanges();
                var k = profileskillset.ProfileId;
                return Ok("Profileskillset  created successfully");
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [Route("api/updateProfileSkillset")]
        [HttpPut("updateProfileSkillset")]
        public async Task<IActionResult> updateProfileSkillset([FromBody] ProfileSkillSet profileskillset)
        {
            try
            {
                db.Entry(profileskillset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(profileskillset);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }
        [Route("api/deleteProfileSkillset")]
        [HttpDelete("deleteProfileSkillset/{id}")]
        public async Task<IActionResult> deleteProfileSkillset([FromBody] ProfileSkillSet profileskillset)
        {
            try
            {
                var result=(from a in db.ProfileSkillSet
                            where a.ProfileId ==profileskillset.ProfileId select a);
                db.Remove(result);
                db.SaveChanges();
                            
                return Ok("Profile Deleted successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

        [Route("api/add")]
        [HttpPost("add")]
        public async Task<IActionResult> add([FromBody] Profile profile, int profile1)
        {
            try
            {
                int x = 0;
                return Ok(x);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [Route("api/create")]
        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] Profile profile)
        {
            try
            {
                db.Profile.Add(profile);
                db.SaveChanges();
                var k = profile.ProfileId;
                return Ok("Profile created successfully");
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [Route("api/update")]
        [HttpPut("update")]
        public async Task<IActionResult> update([FromBody] Profile profile)
        {
            try
            {
                db.Entry(profile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(profile);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

        [Route("api/delete")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete([FromBody] Profile id)
        {
            try
            {
                if (id.ProfileId != 0)
                {
                    db.Profile.Remove(db.Profile.Find(id.ProfileId));
                    db.SaveChanges();
                }
                return Ok("Profile Deleted successfully");
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return BadRequest();
            }
        }

     
        [Route("api/UploadFile")]
        [HttpPost("UploadFile")]
       public async Task<IActionResult> UploadFile(IFormFile file, int id)
        {
            id = 3;
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "locker", id.ToString()+ file.FileName);
                     

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("File uploaded successfully");
        }

        //private string url = "http://xxxxxxxxx/api/image/";
        [Route("api/UploadImageAsync")]
        [HttpPost("UploadImageAsync")]
        public async Task UploadImageAsync(Stream image, string fileName)
        {
            HttpContent fileStreamContent = new StreamContent(image);
            fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "file", FileName = fileName };
            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "locker", fileName);
            using (var client = new HttpClient())
                
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent);
                var response = await client.PostAsync(path, formData); 
                // return response.IsSuccessStatusCode;
            }
            //return Ok("File uploaded successfully");
        }



    }
}