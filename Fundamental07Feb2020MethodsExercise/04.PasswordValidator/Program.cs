using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pwd = Console.ReadLine();
            if (!IsSixTenChar(pwd)) Console.WriteLine("Password must be between 6 and 10 characters");      
            if (!IsOnlyLettersDigits(pwd)) Console.WriteLine("Password must consist only of letters and digits");      
            if (!IsMoreTwoDigits(pwd)) Console.WriteLine("Password must have at least 2 digits");
            bool allOk = IsSixTenChar(pwd) && IsOnlyLettersDigits(pwd) && IsMoreTwoDigits(pwd);
            if (allOk) Console.WriteLine("Password is valid");
        }
        static bool IsSixTenChar(string text)
        {
            int textLength = text.Length;
            bool flag = false;
            if (textLength >= 6 && textLength <= 10) flag = true;
            return flag;
        }

        static bool IsOnlyLettersDigits(string text)
        {
            string text1 = text.ToLower();
            int txtLength = text1.Length;
            bool flag = true;
            for (int i = 0; i < txtLength; i++)
            {
                bool isInRange = (text1[i] >= 97 && text1[i] <= 122) || (text1[i] >= 48 && text1[i] <= 57);
                if (!isInRange)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        static bool IsMoreTwoDigits(string text)
        {
            int textLength = text.Length;
            int countDigits = 0;
            bool flag = true;
            for (int i = 0; i < textLength; i++)
            {
                if(text[i] >= '0' && text[i] <= '9') countDigits++;
            }
            if (countDigits < 2) flag = false;
            return flag;
        }
    }
}
