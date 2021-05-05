using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkillsLibrary
{
    public class BmiCalculatorClass
    {
        public static double CalculateBmi(int weightKg, int heightCm)
        {
            return Math.Round(Convert.ToDouble(weightKg/((heightCm/100)^2)), 2);
        }

        public static string GetBmiCategory(double bmi)
        {
            if (bmi <= 18.5) return "Недовес";
            else if (bmi > 18.5 && bmi < 25) return "Норма";
            else if (bmi >= 25 && bmi < 30) return "Перевес";
            else if (bmi >= 30 && bmi < 40) return "Ожирение";
            else return "Сильное ожирение";
        }
    }
}
