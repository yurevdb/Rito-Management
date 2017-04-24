using System.Security.Cryptography;
using System.Text;

namespace RitoManager.UserManagement
{
    public class BaseUser
    {
        #region Public Properties

        /// <summary>
        /// The systems username of the user
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sirname of the user
        /// </summary>
        public string Sirname { get; set; }

        /// <summary>
        /// Accountnumber of the user
        /// </summary>
        public long Accountnumber { get; set; }

        /// <summary>
        /// Age of the user
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The access level of the user
        /// </summary>
        public UserLevel Level { get; set; }

        #endregion

        #region Base Methods

        /// <summary>
        /// Generates a unique username in the system 
        /// </summary>
        /// <returns></returns>
        public string GenerateIdentifier()
        {

            int maxSize = 8;
            int minSize = 5;
            char[] chars = new char[62];
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {

            }

            return $"";
        }

        #endregion
    }
}
