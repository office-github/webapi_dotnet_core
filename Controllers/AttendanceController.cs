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
        // DELETE api/attendance/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(long id)
        {
            return Ok(this.attendanceService.DeleteAttendanceBySymbolNumber(id));
        }
    }
}
