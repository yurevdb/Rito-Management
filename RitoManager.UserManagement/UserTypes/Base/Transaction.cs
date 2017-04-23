namespace RitoManager.UserManagement
{
    public class Transaction
    {
        /// <summary>
        /// Last amount of money of the user
        /// </summary>
        public long PreviousAmount { get; set; }

        /// <summary>
        /// The current amount of money of the user
        /// </summary>
        public long CurrentAmount { get; set; }

        /// <summary>
        /// The recipient
        /// </summary>
        public ExternUser Recipient { get; set; }

        /// <summary>
        /// The sender
        /// </summary>
        public User Sender { get; set; }
    }
}
