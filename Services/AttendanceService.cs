using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

    private AttendanceSqlProvider attendanceSqlProvider;

    public AttendanceService(AttendanceSqlProvider attendanceSqlProvider)
    {
        this.attendanceSqlProvider = attendanceSqlProvider;
    }

    public IEnumerable<Attendance> GetAttendance()
    {
        try
        {
            return this.attendanceSqlProvider.GetAttendance();
        }
        catch (SqlException ex) { }

        return null;
    }

    public IEnumerable<Attendance> GetAttendanceBySymbolNumber(long symbolNumber)
    {
        try
        {
            return this.attendanceSqlProvider.SearchAttendanceBySymbolNumber(symbolNumber);
        }
        catch (SqlException ex) { }

        return null;
    }
}