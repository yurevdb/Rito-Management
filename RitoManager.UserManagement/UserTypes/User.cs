using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RitoManager.UserManagement
{
    public class User : BaseUser
    {
        #region Public Properties

        /// <summary>
        /// The amount of money the user has
        /// </summary>
        [JsonProperty("money")]
        public long Money { get; set; }

        /// <summary>
        /// A list of recent transactions
        /// </summary>
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an amount of money to the users bankaccount
        /// </summary>
        /// <param name="amount">The amount to add</param>
        /// <param name="sender">The sender off the money</param>
        /// <param name="recipient"></param>
        public void AddMoney(long amount, User recipient, ExternUser sender)
        {
            Transactions.Add(new Transaction()
            {
                PreviousAmount = Money,
                CurrentAmount = Money+amount,
                Recipient = sender,
                Sender = recipient
            });

            Money += amount;
        }

        /// <summary>
        /// Withdraws an amount of money to the sers bankaccount
        /// </summary>
        /// <param name="amount">The amount to withdraw</param>
        /// <param name="sender">The sender off the money</param>
        /// <param name="recipient"></param>
        public void WithdrawMoney(long amount, User sender, ExternUser recipient)
        {
            Transactions.Add(new Transaction()
            {
                PreviousAmount = Money,
                CurrentAmount = Money - amount,
                Recipient = recipient,
                Sender = sender
            });

            Money -= amount;
        }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Specified constructor
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="sirname">Sirname of the user</param>
        /// <param name="age">Age of the user</param>
        /// <param name="accountnumber">Accountnumber of the user</param>
        /// <param name="level"><see cref="UserLevel"/> of the user, default <see cref="UserLevel.User"/></param>
        public User(string name, string sirname, int age, long accountnumber, UserLevel level)
        {
            Identifier = GenerateIdentifier(); //GenerateIdentifier()
            Name = name;
            Sirname = sirname;
            Age = age;
            Accountnumber = accountnumber;
            Level = level;
        }

        #endregion

        #region Helpers

        public void SaveUser(User user)
        {
            var users = new List<BaseUser>();

            // Get the list of users
            users = JsonConvert.DeserializeObject<List<BaseUser>>(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RitoManager_Users.json");

            // Add the given user to the list
            users.Add(user);

            // Save the list again
            string json = JsonConvert.SerializeObject(users);

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RitoManager_Users.json"))
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RitoManager_Users.json");

            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RitoManager_Users.json", json);

            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RitoManager_Users.json"))
            {
                sw.WriteLine(json);
            }
        }

        #endregion
    }
}
