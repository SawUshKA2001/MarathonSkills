using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarathonSkillsLibrary;

namespace MarathonSkillsLibraryUnitTests
{
    /// <summary>
    /// Тестовый класс для BmiCalculatorClass
    /// </summary>
    [TestClass]
    public class BmiCalculatorClassTests
    {
        /// <summary>
        /// Тест на нулевые входные данные
        /// </summary>
        [TestMethod]
        public void CalculateBmi_ZeroZeroInserted_ZeroReturned()
        {
            // Arrange
            int height = 0;
            int weight = 0;
            double expectedResult = 0;
            // Act
            double result = BmiCalculatorClass.CalculateBmi(weight, height);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        /// <summary>
        /// Тест на отрицательные входные данные
        /// </summary>
        [TestMethod]
        public void CalculateBmi_NegativesInserted_ZeroReturned()
        {
            // Arrange
            int height = -1;
            int weight = -3;
            double expectedResult = 0;
            // Act
            double result = BmiCalculatorClass.CalculateBmi(weight, height);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        /// <summary>
        /// Тест на корректность вычислений
        /// </summary>
        [TestMethod]
        public void CalculateBmi_55and180Inserted_18Returned()
        {
            // Arrange
            int height = 180;
            int weight = 55;
            double expectedResult = 18;
            // Act
            double result = BmiCalculatorClass.CalculateBmi(weight, height);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Тест на отрицательное значение BMI
        /// </summary>
        [TestMethod]
        public void GetBmiCategory_NegativeInserted_NedovesReturned()
        {
            // Arrange
            double bmi = -1;
            string expectedResult = "Недовес";
            // Act
            string result = BmiCalculatorClass.GetBmiCategory(bmi);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Тест на входящий ноль
        /// </summary>
        [TestMethod]
        public void GetBmiCategory_ZeroInserted_NedovesReturned()
        {
            // Arrange
            double bmi = 0;
            string expectedResult = "Недовес";
            // Act
            string result = BmiCalculatorClass.GetBmiCategory(bmi);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Тест на корректное выведение значения "Норма"
        /// </summary>
        [TestMethod]
        public void GetBmiCategory_20Inserted_NormaReturned()
        {
            // Arrange
            double bmi = 20;
            string expectedResult = "Норма";
            // Act
            string result = BmiCalculatorClass.GetBmiCategory(bmi);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Тест на корректное выведение значения "Перевес"
        /// </summary>
        [TestMethod]
        public void GetBmiCategory_27Inserted_PerevesReturned()
        {
            // Arrange
            double bmi = 27;
            string expectedResult = "Перевес";
            // Act
            string result = BmiCalculatorClass.GetBmiCategory(bmi);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Тест на корректное выведение значения "Ожирение"
        /// </summary>
        [TestMethod]
        public void GetBmiCategory_35Inserted_OjirenieReturned()
        {
            // Arrange
            double bmi = 35;
            string expectedResult = "Ожирение";
            // Act
            string result = BmiCalculatorClass.GetBmiCategory(bmi);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Тест на корректное выведение значения "Сильное ожирение"
        /// </summary>
        [TestMethod]
        public void GetBmiCategory_BigNumberInserted_SilnoeOjirenieReturned()
        {
            // Arrange
            double bmi = 100;
            string expectedResult = "Сильное ожирение";
            // Act
            string result = BmiCalculatorClass.GetBmiCategory(bmi);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
