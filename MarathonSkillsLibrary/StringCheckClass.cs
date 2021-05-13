using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarathonSkillsLibrary
{
    public class StringCheckClass
    {
        Regex regex;
        Match match;
        public bool EmailCheck(string emailString)
        {
            regex = new Regex(@"^[_a-z0-9-\+-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$");
            match = regex.Match(emailString);
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool PasswordCheck(string passwordString)
        {
            regex = new Regex(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}");
            match = regex.Match(passwordString);
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool NameCheck(string nameString)
        {
            regex = new Regex(@"^[а-яА-Я\sa-zA-Z]{3,}$");
            match = regex.Match(nameString);
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool CardNumberCheck(string numberString)
        {
            regex = new Regex(@"^[\d]{4}[\s]?[\d]{4}[\s]?[\d]{4}[\s]?[\d]{4}$");
            match = regex.Match(numberString);
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool CardMonthCheck(string monthString)
        {
            regex = new Regex(@"^[\d]{2}$");
            match = regex.Match(monthString);
            if (match.Success && Convert.ToInt32(monthString)<=12)
                return true;
            else
                return false;
        }

        public bool CardYearCheck(int year)
        {
            regex = new Regex(@"^20[\d]{2}$");
            match = regex.Match(year.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool CvcCheck(int cvc)
        {
            regex = new Regex(@"^[\d]{3}$");
            match = regex.Match(cvc.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
