using System.Security.Cryptography;

namespace ValconLibrary.Helpers
{
    public static class PasswordHelper
    {
        public static Tuple<string, string> HashPassword(string password)
        {
            int iterations = 1000;
            var sBytes = new byte[password.Length];
            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
            var salt = Convert.ToBase64String(sBytes);

            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes, iterations);

            return new Tuple<string, string>
            (
                Convert.ToBase64String(derivedBytes.GetBytes(256)),
                salt
            );
        }
    }
}
