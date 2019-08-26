using System;
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

    public User GetUserBySymbolNumber(long symbolNumber)
    {
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM user where symbolnumber = {symbolNumber}", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new User()
                    {
                        SymbolNumber = reader.GetInt64("symbolnumber"),
                        FullName = reader.GetString("fullname"),
                        Email = reader.GetString("email"),
                        PhoneNo = reader.GetInt64("phoneno")
                    };
                }
            }
        }

        return null;
    }

    public bool AddUser(User user)
    {
        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"Insert into user values ({user.SymbolNumber}, {user.FullName}, {user.Email}, {user.PhoneNo})", conn);
                int rowNumber = cmd.ExecuteNonQuery();
                return true;
            }
        }
        catch (Exception ex)
        {
        }

        return false;
    }

    public bool UpdateUser(User user)
    {
        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE user SET fullname={user.FullName}, email={user.Email}, phoneno{user.PhoneNo} WHERE symbolnumber={user.SymbolNumber}", conn);
                int rowNumber = cmd.ExecuteNonQuery();
                return true;
            }
        }
        catch (Exception ex)
        {
        }

        return false;
    }

    public bool DeleteUser(long symbolNumber)
    {
        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"delete from user WHERE symbolnumber={symbolNumber}", conn);
                int rowNumber = cmd.ExecuteNonQuery();
                return true;
            }
        }
        catch (Exception ex)
        {
        }

        return false;
    }
}