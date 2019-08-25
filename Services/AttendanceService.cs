using System;
using System.Collections.Generic;

public class AttendanceService
{
    List<Attendance> attendanceList = new List<Attendance> {
        new Attendance {
            SymbolNumber = 1,
            AttendanceDate = DateTime.Now,
            IsPresent = true
        },
        new Attendance {
            SymbolNumber = 2,
            AttendanceDate = DateTime.Now,
            IsPresent = true
        },
        new Attendance {
            SymbolNumber = 3,
            AttendanceDate = DateTime.Now,
            IsPresent = false
        },
        new Attendance {
            SymbolNumber = 4,
            AttendanceDate = DateTime.Now,
            IsPresent = true
        },
        new Attendance {
            SymbolNumber = 5,
            AttendanceDate = DateTime.Now,
            IsPresent = false
        }
    };

    public IEnumerable<Attendance> GetAttendance()
    {
        return attendanceList;
    }

    public IEnumerable<Attendance> GetAttendanceBySymbolNumber(long symbolNumber)
    {
        foreach(Attendance attendance in attendanceList) {
            if(attendance.SymbolNumber == symbolNumber) {
                yield return attendance;
            }
        }
    }

    public bool AddAttendance(Attendance attendance)
    {
        try
        {
            attendanceList.Add(attendance);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateAttendance(Attendance attendance)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteAttendance(Attendance attendance)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}