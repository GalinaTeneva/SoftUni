using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();

            bool isLengthValid = CheckPassLength(inputPassword);
            bool areCharsValid = CheckPassCharsType(inputPassword);
            bool areDigitsValid = CheckPassDigitsNum(inputPassword);

            if (!isLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!areCharsValid)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!areDigitsValid)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isLengthValid && areCharsValid && areDigitsValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool CheckPassLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }

        static bool CheckPassCharsType(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckPassDigitsNum(string password)
        {
            int digitsCounter = 0;
            foreach(char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitsCounter++;
                }
                if (digitsCounter == 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
