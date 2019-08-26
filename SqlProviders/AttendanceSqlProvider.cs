using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class AttendanceSqlProvider
{
    public string ConnectionString { get; set; }

    public AttendanceSqlProvider(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    public IEnumerable<Attendance> GetAttendance()
    {
        List<Attendance> list = new List<Attendance>();

        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM attendance", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Attendance()
                        {
                            SymbolNumber = reader.GetInt64("symbolnumber"),
                            AttendanceDate = reader.GetDateTime("attendancedate"),
                            IsPresent = reader.GetBoolean("ispresent"),
                        });
                    }
                }
            }
        }
        catch (MySqlException ex) { }

        return list;
    }

    public IEnumerable<Attendance> SearchAttendanceBySymbolNumber(long symbolnumber)
    {
        List<Attendance> list = new List<Attendance>();

        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM attendance where symbolnumber = {symbolnumber}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    list.Add(new Attendance()
                    {
                        SymbolNumber = reader.GetInt64("symbolnumber"),
                        AttendanceDate = reader.GetDateTime("attendancedate"),
                        IsPresent = reader.GetBoolean("ispresent"),
                    });
                }
            }
        }
        catch (MySqlException ex)
        {

        }

        return list;
    }
}