using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class UserSqlProvider
{
    public string ConnectionString { get; set; }

    public UserSqlProvider(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    public IEnumerable<User> GetUsers()
    {
        List<User> list = new List<User>();

        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new User()
                    {
                        SymbolNumber = reader.GetInt64("symbolnumber"),
                        FullName = reader.GetString("fullname"),
                        Email = reader.GetString("email"),
                        PhoneNo = reader.GetInt64("phoneno")
                    });
                }
            }
        }

        return list;
    }
}