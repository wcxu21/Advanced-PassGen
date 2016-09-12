﻿using System.Text.RegularExpressions;

namespace Advanced_PassGen.Classes
{
    public class Password
    {
        private string _actualPassword;

        public string ActualPassword
        {
            get { return _actualPassword; }
            set
            {
                _actualPassword = value;
                Strength = CheckStrength(_actualPassword);
                Length = value.Length;
            }
        }

        public int Length { get; private set; }
        
        public int Strength { get; private set; }

        /// <summary>
        /// Check how a strong a password is. The higher the score, the safer the password.
        /// </summary>
        /// <param name="password">The password that needs to be evaluated.</param>
        /// <returns>Returns a password score.</returns>
        private static int CheckStrength(string password)
        {
            int score = 0;

            if (string.IsNullOrEmpty(password)) return 0;
            if (password.Length < 1) return 0;
            if (password.Length < 4) return 1;
            if (password.Length >= 8) score++;
            if (password.Length >= 10) score++;
            if (Regex.Match(password, @"\d", RegexOptions.ECMAScript).Success) score++;
            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success && Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success) score++;
            if (Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success) score++;

            return score;
        }
    }
}
