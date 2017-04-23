using System.Collections.Generic;

namespace RitoManager.UserManagement
{
    public class User : BaseUser
    {
        #region Public Properties

        /// <summary>
        /// The amount of money the user has
        /// </summary>
        public long Money { get; set; }

        /// <summary>
        /// A list of recent transactions
        /// </summary>
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
        /// Default constructor of a <see cref="User"/>
        /// </summary>
        public User() { }

        /// <summary>
        /// Specified constructor
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="sirname">Sirname of the user</param>
        /// <param name="age">Age of the user</param>
        /// <param name="accountnumber">Accountnumber of the user</param>
        /// <param name="level"><see cref="UserLevel"/> of the user, default <see cref="UserLevel.User"/></param>
        public User(string name, string sirname, int age, int accountnumber, UserLevel level)
        {
            Username = GenerateUsername(level);
            Name = name;
            Sirname = sirname;
            Age = age;
            Accountnumber = accountnumber;
            Level = level;
        }

        #endregion
    }
}
