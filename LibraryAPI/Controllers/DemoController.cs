using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    public class DemoController : ControllerBase 
    {
        [HttpGet("/status")]
        public ActionResult GetTheStatus()
        {
            return Ok(new { Message = "All is Good", CreatedAt = DateTime.Now });
        }

        [HttpGet("/employees/{employeeId:int}")]
        public ActionResult GetEmployee(int employeeId)
        {
            return Ok(new { EmployeId = employeeId, Name = "Tom Foolery" });
        }

        [HttpGet("/blogs/{year:int}/{month:int}/{day:int}")]
        public ActionResult GetBlogPosts(int year, int month, int day)
        {
            return Ok($"Getting the blog posts for {month}/{day}/{year}");
        }

        [HttpGet("/agents")]
        public ActionResult GetAgents([FromQuery] string state = "All")
        {
            return Ok($"Getting Agents from State {state}");
        }

        [HttpGet("/whoami")]
        public ActionResult GetUserAgent([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"I see you are running {userAgent}");
        }
    }
}
