using System.Security.Cryptography;
using System.Text;
using ConfigurationManager.Core.Contract.Users;

namespace ConfigurationManager.Core.Helpers;

public static class PasswordHelper
{
    public static void GeneratePassword(string password, out string hash, out string salt)
    {
        var rnd = RandomNumberGenerator.Create();
        var saltBytes = new byte[16];
        rnd.GetBytes(saltBytes);
        salt = Convert.ToBase64String(saltBytes);

        var md = SHA512.Create();
        var saltedPass = password + salt;
        hash = Convert.ToBase64String(md.ComputeHash(Encoding.Unicode.GetBytes(saltedPass)));
    }

    public static bool ComparePassword(User user, string password)
    {
        var md = SHA512.Create();
        var saltedPass = password + user.Salt;
        var hash = Convert.ToBase64String(md.ComputeHash(Encoding.Unicode.GetBytes(saltedPass)));

        return hash == user.Password;
    }
}