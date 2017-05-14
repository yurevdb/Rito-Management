using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace RitoManager.UserManagement
{
    public class BaseUser
    {
        #region Private Variables

        /// <summary>
        /// Object to generate random unique characters
        /// </summary>
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

        #endregion

        #region Public Properties

        /// <summary>
        /// The systems username of the user
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Sirname of the user
        /// </summary>
        [JsonProperty("sirname")]
        public string Sirname { get; set; }

        /// <summary>
        /// Age of the user
        /// </summary>
        [JsonProperty("age")]
        public int Age { get; set; }

        /// <summary>
        /// The access level of the user
        /// </summary>
        [JsonProperty("level")]
        public UserLevel Level { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// The color for the initials icon of the user
        /// </summary>
        [JsonProperty("backgroundcolor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Info about the user
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        #endregion

        #region Base Methods

        /// <summary>
        /// Generates a unique username in the system 
        /// </summary>
        /// <returns></returns>
        protected void GenerateIdentifier()
        {

            int maxSize = 8;
            char[] chars = new char[62];
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }

            Identifier = result.ToString();
        }

        /// <summary>
        /// Generates a random color in string format for the user, this will serve as the background color of the initials icon for the user
        /// </summary>
        protected void GenerateBackgroundColor()
        {
            Random rng = new Random();
            Color color = new Color();
            color = Color.FromArgb(255, rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
            BackgroundColor = color.Name;
        }

        #endregion
    }
}
