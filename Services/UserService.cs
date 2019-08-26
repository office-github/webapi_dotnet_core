using System;
using System.Collections.Generic;

public class UserService
{
    List<User> userList = new List<User> {
        new User {
            SymbolNumber = 1,
            FullName = "Ranjan Mishra",
            Email = "r@gmail.com",
            PhoneNo = 9876543210
        },
        new User {
            SymbolNumber = 2,
            FullName = "Bijay Kumar Yadav",
            Email = "b@gmail.com",
            PhoneNo = 8976543210
        },
        new User {
            SymbolNumber = 3,
            FullName = "Dilbahadur KC",
            Email = "d@gmail.com",
            PhoneNo = 9776543210
        },
        new User {
            SymbolNumber = 4,
            FullName = "Manoj Kapri",
            Email = "m@gmail.com",
            PhoneNo = 8876543210
        },
        new User {
            SymbolNumber = 5,
            FullName = "Gudu Yadav",
            Email = "g@gmail.com",
            PhoneNo = 8676543210
        }
    };

    private UserSqlProvider userSqlProvider;

    public UserService(UserSqlProvider userSqlProvider)
    {
        this.userSqlProvider = userSqlProvider;
    }

    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = new List<User>();

        try
        {
            users = this.userSqlProvider.GetUsers();
        }
        catch (Exception) { }

        return users;
    }

    public User GetUserBySymbolNumber(long symbolNumber)
    {
        User user = new User();

        try
        {
            user = this.userSqlProvider.GetUserBySymbolNumber(symbolNumber);
        }
        catch (Exception) { }

        return user;
    }

    public bool AddUser(User user)
    {
        try
        {
            return this.userSqlProvider.AddUser(user);
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateUser(User user)
    {
        try
        {
            return this.userSqlProvider.UpdateUser(user);
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteUser(long symbolNumber)
    {
        try
        {
            return this.userSqlProvider.DeleteUser(symbolNumber);
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}