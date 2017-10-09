namespace OnboardingExperience
{

    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }



    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAccountOwner { get; set; }

        public string EmailAddress { get; set; }
        
        public string AType { get; set; }
        
        /// <summary>
        /// Should be a 9-digit Account number:
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Should be a secure 4-digit pin number:
        /// </summary>
        public string AccountPin { get; set; }
    }
}
