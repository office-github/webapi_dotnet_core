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

    public IEnumerable<User> GetUsers()
    {
        return userList;
    }

    public User GetUserBySymbolNumber(long symbolNumber)
    {
        foreach (User user in userList)
        {
            if (user.SymbolNumber == symbolNumber)
            {
                return user;
            }
        }

        return null;
    }

    public bool AddUser(User user)
    {
        try
        {
            userList.Add(user);
            return true;
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
            return true;
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
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}