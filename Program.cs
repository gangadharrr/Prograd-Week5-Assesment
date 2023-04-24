using System.Text.RegularExpressions;
namespace Prograd__Week5_Assesment
{
    /*
     *Q1
        Password Validation
        Create a function that validates a password to conform using c#.net to the following rules:
        Length between 6 and 24 characters.
        At least one uppercase letter (A-Z).
        At least one lowercase letter (a-z).
        At least one digit (0-9).
        Maximum of 2 repeated characters.
        "aa" is OK
        "aaa" is NOT OK
        Supported special characters:
        ! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; " ' ? < > , .
        Examples
        ValidatePassword("P1zz@") ➞ false
        // Too short.
        ValidatePassword("Fhg93@") ➞ true
        // OK!
     */
    internal class Program
    {
        
        static bool PasswordValidation(string Password)
        {
            bool IsPasswordValid = true;
            if (Password.Length >= 6 && Password.Length <= 24)
            {
                Regex re = new Regex("[A-Z]+");
                if (re.IsMatch(Password))
                {
                    re = new Regex("[a-z]+");
                    if (re.IsMatch(Password))
                    {
                        re = new Regex("[0-9]+");
                        if (re.IsMatch(Password))
                        {

                            re = new Regex("[!@#$%^&*()+=_{}[:;\"'?<>,.-]+");
                            if (re.IsMatch(Password))
                            {
                                re = new Regex("(.)(\\1){2,}");
                                if (re.IsMatch(Password))
                                {
                                    IsPasswordValid = false;
                                }
                            }
                            else { IsPasswordValid = false; }

                        }
                        else { IsPasswordValid = false; }

                    }
                    else { IsPasswordValid = false; }

                }
                else { IsPasswordValid = false; }
            }
            else { IsPasswordValid = false; }
            return IsPasswordValid;
        }
        static void Main(string[] args)
        {
            string Password = Convert.ToString(Console.ReadLine());
            Console.WriteLine(PasswordValidation(Password));
        }
    }
}