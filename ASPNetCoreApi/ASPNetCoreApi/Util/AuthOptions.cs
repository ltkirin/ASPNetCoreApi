using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreApi.Util
{
    public class AuthOptions
    {
        /// <summary>
        /// Token issuer
        /// </summary>
        public const string ISSUER = "AirsoftBase"; 
        /// <summary>
        /// Uadience service for token
        /// </summary>
        public const string AUDIENCE = "http://localhost:51884/"; 
        /// <summary>
        /// Encryption key
        /// </summary>
        const string KEY = "VERYVERYLONGCODEVERYVERYLONGCODEVERYVERYLONGCODE"; 
        /// <summary>
        /// Token lifetime (minutes)
        /// </summary>
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
