using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private AttendanceService attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        // GET api/attendance
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> Get()
        {
            return Ok(this.attendanceService.GetAttendance());
        }

        //GET api/attendance/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Attendance>> Get(long id)
        {
            return Ok(this.attendanceService.GetAttendanceBySymbolNumber(id));
        }

        // POST api/attendance
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Attendance attendance)
        {
            return Ok(this.attendanceService.AddAttendance(attendance));
        }

        // PUT api/attendance/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(long id, [FromBody] Attendance attendance)
        {
            return Ok(this.attendanceService.UpdateAttendance(attendance));
        }

        // DELETE api/attendance/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromBody] Attendance attendance)
        {
            return Ok(this.attendanceService.DeleteAttendance(attendance));
        }
    }
}
