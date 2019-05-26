using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreApi.Util
{
    public static class PasswordHashing
    {
        private static string ComputeHash(string password, string username)
        {
            string passwordHash = ComputePasswordHash(password);
            string salt = Salt(username);
            return $"{passwordHash}{salt}";
        }

        public static string ComputePasswordHash(string password)
        {
            using (SHA256 passwordHash = SHA256.Create())
            {
                byte[] bytes = passwordHash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private static string Salt(string userName)
        {
            string salt = String.Empty;
            long XORED = 0x00;
            byte[] userNameBytes = ASCIIEncoding.ASCII.GetBytes(userName);

            foreach (byte b in userNameBytes)
            {
                XORED = XORED ^ b;
            }
            Random random = new Random(Convert.ToInt32(XORED));
            for (int i = 0; i < 5; i++)
            {
                salt += random.Next().ToString();
            }
            return salt;
        }
    }
}
