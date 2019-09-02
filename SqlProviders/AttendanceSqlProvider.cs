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
                conn.Close();
            }
        }
        catch (MySqlException ex) { }

        return list;
    }

    public IEnumerable<Attendance> SearchAttendanceBySymbolNumber(long symbolNumber)
    {
        List<Attendance> list = new List<Attendance>();

        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT * FROM attendance WHERE symbolnumber = @symbolnumber";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@symbolnumber", symbolNumber);

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
        }
        catch (MySqlException ex)
        {

        }

        return list;
    }

    public bool DeleteAttendanceBySymbolNumber(long symbolNumber)
    {
        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand($"delete from attendance WHERE symbolnumber={symbolNumber}", conn);
                int numberOfRowDeleted = cmd.ExecuteNonQuery();

                if (numberOfRowDeleted > 0)
                    return true;
            }
        }
        catch (MySqlException ex)
        {
        }

        return false;
    }
}