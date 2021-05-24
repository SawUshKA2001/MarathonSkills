using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkillsLibrary
{
    /// <summary>
    /// Логика для BMI калькулятора
    /// </summary>
    public class BmiCalculatorClass
    {
        /// <summary>
        /// Вычисление индекса массы тела
        /// </summary>
        /// <param name="weightKg">Вес в килограмах</param>
        /// <param name="heightCm">Рост в сантиметрах</param>
        /// <returns>
        /// Возвращает индекс массы тела числом
        /// </returns>
        public static double CalculateBmi(int weightKg, int heightCm)
        {
            if (weightKg > 0 && heightCm > 0)
            {
                return Math.Round(Convert.ToDouble(weightKg / ((heightCm / 100) ^ 2)), 2);
            }
            else return 0;
        }

        /// <summary>
        /// Подбор категории для индекса массы тела
        /// </summary>
        /// <param name="bmi">Индекс массы тела</param>
        /// <returns>
        /// Статус индекса массы тела
        /// </returns>
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
