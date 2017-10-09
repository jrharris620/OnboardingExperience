using System;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;

namespace OnboardingExperience
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();

            SpeakAndWrite("Welcome to your Onboarding Experience");

            user.FirstName = AskQuestion("What is your first name?");
            SpeakAndWrite("Hello " + user.FirstName + "!");

            user.LastName = AskQuestion("What is your last name?");
            SpeakAndWrite("Awesome! Nice to meet you " + user.FirstName + " " + user.LastName + "!");

            user.AType = AskQuestion("What type of account do you have?");
            SpeakAndWrite("Okay! You want to access your " + user.AType + " account.");

            user.IsAccountOwner = AskBoolQuestion("Are you the account owner? ");
            SpeakAndWrite("Wonderful! You are the account owner! ");

            user.AccountNumber = AskAcctNumber("What is your 9-digit Routing Number? ", 9);
            SpeakAndWrite("Excellent! Your Routing Number is: " + user.AccountNumber);

            user.AccountPin = AskAcctNumber("Can you please pick 4 digits for your pin? ", 4);
            SpeakAndWrite("Thanks! Your Account Pin is now: " + user.AccountPin);

            user.EmailAddress = AskQuestion("What is your e-mail address?");
            SpeakAndWrite("Great! A verification email has been sent to " + user.EmailAddress + "!");

            SpeakAndWrite("Thank you for completing the Onboard Experience!");


            SpeakAndWrite("Have a wonderful day!");



            Console.ReadLine();

        }

        static string AskQuestion(string question)
        {
            SpeakAndWrite(question);
            return Console.ReadLine();

        }

        /// <summary>
        /// The purpose of this method is to make the text speak.
        /// </summary>
        /// <param name="stringToSpeak">To speak the questions and responses</param>
        private static void SpeakAndWrite(string stringToSpeak)
        {
            Console.WriteLine(stringToSpeak);
            var syn = new SpeechSynthesizer();
            syn.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            syn.Speak(stringToSpeak);
        }

        /// <summary>
        /// The purpose of this message is to ask a bool question with a yes or no option
        /// </summary>
        /// <param name="question">Question to be asked</param>
        /// <returns>True for yes, or False for no</returns>
        static bool AskBoolQuestion(string question)
        {
            var IsAccountOwner = false;

            while (!IsAccountOwner)
            {
                var response = AskQuestion(question + "y or n ");

                if (response == "y")
                {
                    IsAccountOwner = true;
                }
                else if (response == "n")
                {
                    SpeakAndWrite("ERROR: You will need to create an account to continue!");
                }
                else AskQuestion(question + " Type 'y' for 'Yes' or 'n' for 'No', you dumbass!");
            }

            return IsAccountOwner;
        }

        public static AccountType AType(string question)
        {
            AccountType? aType = null;

            while (aType == null)
            {
                var response = AskQuestion(question);

                if (Enum.TryParse(response, out AccountType actualType))
                {
                    aType = actualType;

                }
            }

            return (AccountType) aType;
        }

        string aType = ("'Checking,' 'Savings,' or 'Business");

        public string AType1 { get => aType; set => aType = value; }


        /// <summary>
        /// The purpose of this method is to ask an int question
        /// </summary>
        /// <param name="question">Question to be asked</param>
        /// <param name="length">Makes sure that the user only enters the required length of characters</param>
        /// <returns></returns>

        static string AskAcctNumber(string question, int length)
        {
            string numberString = null;

            while (numberString == null)
            {
                var response = AskQuestion(question);

                if (response.Length == length && Int32.TryParse(response, out int _))
                {
                    numberString = response;
                }


            }
            return numberString;
        }

        
    }
}
