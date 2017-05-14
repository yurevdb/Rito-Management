using ServerControl.Core;
using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace RitoManager.Core
{
    public class Password
    {
        private static MD5 md5 = new MD5CryptoServiceProvider();

        /// <summary>
        /// Function to hash a <see cref="SecureString"/>. 
        /// </summary>
        /// <param name="SecureString">The password to hash</param>
        /// <returns>Array with hashed password and salt</returns>
        public static Tuple<byte[], byte[]> Hash(SecureString SecureString)
        {
            // Salt for the hashing of the password
            byte[] salt = new byte[20];

            // Generate salt
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(salt);
            }

            // !ATTENTION! very bad must be changed
            // var pass = Encoding.ASCII.GetBytes(SecureString.Unsecure());

            byte[] tobehashed = new byte[salt.Length + SecureString.Length];

            for (int i = 0; i < (salt.Length + SecureString.Length) - 1; i++)
            {
                if (i < SecureString.Length)
                    tobehashed[i] = Encoding.ASCII.GetBytes(SecureString.Unsecure())[i];
                else
                    tobehashed[i] = salt[i - SecureString.Length];
            }

            var hash = md5.ComputeHash(tobehashed);
            
            return Tuple.Create(hash, salt);
        }

        /// <summary>
        /// Checks if the given password equals the given hashed password
        /// </summary>
        /// <param name="Password">The password to check</param>
        /// <param name="Hash">The hashed password to check</param>
        /// <param name="Salt">The salt of the hashed password</param>
        /// <returns><see cref="bool"/> that represents if the password is correct</returns>
        public static bool CheckHash(SecureString Password, byte[] Hash, byte[] Salt)
        {
            // !ATTENTION! very bad must be changed
            // var pass = Encoding.ASCII.GetBytes(Password.Unsecure());

            byte[] tobehashed = new byte[Salt.Length + Password.Length];

            for (int i = 0; i <= (Salt.Length + Password.Length) - 1; i++)
            {
                if (i < Password.Length)
                    tobehashed[i] = Encoding.ASCII.GetBytes(Password.Unsecure())[i];
                else
                    tobehashed[i] = Salt[i - Password.Length];
            }
            
            var hash = md5.ComputeHash(tobehashed);
            
            return CompareHash(Hash, hash);
        }

        private static bool CompareHash(byte[] Array1, byte[] Array2)
        {
            var value = true;

            for(int i = 0; i <= Array1.Length; i++)
            {
                if (Array1[i] != Array2[i])
                    value = false;
            }
            
            return value;
        }
    }
}
