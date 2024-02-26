using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hash
{
    public class Hash
    {
        //Rb 25. Hashiranje samo upisane lozinke
        public static byte[] HashPassword(string password)
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordSaltBytes = Encoding.UTF8.GetBytes(password);

                return sha256.ComputeHash(passwordSaltBytes);
            }
        }

        //Rb 25. hashiranje lozinke sa soli i paprom
        public static byte[] HashPasswordSaltPepper(string password, string salt, string pepper)
        {
            using (var sha256 = new SHA256Managed())
            {
                string psPass = password + salt + pepper;
                byte[] passwordSaltBytes = Encoding.UTF8.GetBytes(psPass);

                return sha256.ComputeHash(passwordSaltBytes);
            }
        }     
    }
}
