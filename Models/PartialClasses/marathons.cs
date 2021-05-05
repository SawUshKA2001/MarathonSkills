﻿namespace MarathonSkills.Models
{
    public partial class marathons
    {
        /// <summary>
        /// Высчитываемое значение имени марафона с годом проведения
        /// </summary>
        public string YearName
        {
            get
            {
                return marathon_name + " " + marathon_year.ToString();
            }
        }
    }
}
