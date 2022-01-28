using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Helpers;

namespace ConfigurationManager.Tests.Users;

public static class UsersTestData
{
    public static User ExistUserDocument
    {
        get
        {
            PasswordHelper.GeneratePassword("1234", out var hash, out var salt);
            return new User 
            {
                Id = 1,
                Password = hash,
                Salt = salt,
                Login = "test@test.test"
            };
        }
    }

    public static User DeletionUserDocument
    {
        get
        {
            PasswordHelper.GeneratePassword("1234", out var hash, out var salt);
            return new User 
            {
                Id = 2,
                Password = hash,
                Salt = salt,
                Login = "testtt@test.test"
            };
        }
    }

    public static User UpdateUserDocument
    {
        get
        {
            PasswordHelper.GeneratePassword("1234", out var hash, out var salt);
            return new User 
            {
                Id = 3,
                Password = hash,
                Salt = salt,
                Login = "testtt@test.test"
            };
        }
    }
}