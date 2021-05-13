using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarathonSkillsLibrary;

namespace MarathonSkillsLibraryUnitTests
{
    [TestClass]
    public class StringCheckClassTests
    {
        StringCheckClass strObj = new StringCheckClass();
        [TestMethod]
        public void EmailCheck_EmptyStringInserted_falseReturned()
        {
            //Arrange
            string emailString = String.Empty;
            //Act
            bool result = strObj.EmailCheck(emailString);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EmailCheck_LetterStringInserted_falseReturned()
        {
            //Arrange
            string emailString = "letters";
            //Act
            bool result = strObj.EmailCheck(emailString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void EmailCheck_NumberStringInserted_falseReturned()
        {
            //Arrange
            string emailString = "12345";
            //Act
            bool result = strObj.EmailCheck(emailString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void EmailCheck_SymbolStringInserted_falseReturned()
        {
            //Arrange
            string emailString = "*@#$";
            //Act
            bool result = strObj.EmailCheck(emailString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void EmailCheck_CorrectEmailStringInserted_trueReturned()
        {
            //Arrange
            string emailString = "sawin.world@gmail.com";
            //Act
            bool result = strObj.EmailCheck(emailString);
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void PasswordCheck_LettersStringInserted_falseReturned()
        {
            //Arrange
            string passwordString = "password";
            //Act
            bool result = strObj.PasswordCheck(passwordString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void PasswordCheck_NumberStringInserted_falseReturned()
        {
            //Arrange
            string passwordString = "12345";
            //Act
            bool result = strObj.PasswordCheck(passwordString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void PasswordCheck_UpperLettersStringInserted_falseReturned()
        {
            //Arrange
            string passwordString = "PASSWORD";
            //Act
            bool result = strObj.PasswordCheck(passwordString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void PasswordCheck_SymbolsStringInserted_falseReturned()
        {
            //Arrange
            string passwordString = "@#$%^";
            //Act
            bool result = strObj.PasswordCheck(passwordString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void PasswordCheck_CorrectPasswordStringInserted_trueReturned()
        {
            //Arrange
            string passwordString = "PassW*rd1488";
            //Act
            bool result = strObj.PasswordCheck(passwordString);
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void NameCheck_LettersStringInserted_trueReturned()
        {
            //Arrange
            string nameString = "Letters Name";
            //Act
            bool result = strObj.NameCheck(nameString);
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void NameCheck_IncorrectStringInserted_falseReturned()
        {
            //Arrange
            string nameString = "C*rrupt9d_Str1n6";
            //Act
            bool result = strObj.NameCheck(nameString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardNumberCheck_IncorrectStringInserted_falseReturned()
        {
            //Arrange
            string cardString = "card_number";
            //Act
            bool result = strObj.CardNumberCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardNumberCheck_ShortStringInserted_falseReturned()
        {
            //Arrange
            string cardString = "012300";
            //Act
            bool result = strObj.CardNumberCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardNumberCheck_LongStringInserted_falseReturned()
        {
            //Arrange
            string cardString = "12341234123412341234123412341234";
            //Act
            bool result = strObj.CardNumberCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardNumberCheck_CorrectNumbeStringInserted_trueReturned()
        {
            //Arrange
            string cardString = "1234 12341234 1234";
            //Act
            bool result = strObj.CardNumberCheck(cardString);
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CardMonthCheck_ShortStringInserted_falseReturned()
        {
            //Arrange
            string cardString = "1";
            //Act
            bool result = strObj.CardMonthCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardMonthCheck_LongStringInserted_falseReturned()
        {
            //Arrange
            string cardString = "112";
            //Act
            bool result = strObj.CardMonthCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardMonthCheck_WrongStringInserted_falseReturned()
        {
            //Arrange
            string cardString = "99";
            //Act
            bool result = strObj.CardMonthCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardMonthCheck_MonthStringInserted_trueReturned()
        {
            //Arrange
            string cardString = "09";
            //Act
            bool result = strObj.CardMonthCheck(cardString);
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CardYearCheck_ShortStringInserted_trueReturned()
        {
            //Arrange
            int cardString = 20;
            //Act
            bool result = strObj.CardYearCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CardYearCheck_YearStringInserted_trueReturned()
        {
            //Arrange
            int cardString = 2009;
            //Act
            bool result = strObj.CardYearCheck(cardString);
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CvcCheck_ShortStringInserted_trueReturned()
        {
            //Arrange
            int cardString = 12;
            //Act
            bool result = strObj.CvcCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CvcCheck_LongStringInserted_trueReturned()
        {
            //Arrange
            int cardString = 1222;
            //Act
            bool result = strObj.CvcCheck(cardString);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CvcCheck_CvcStringInserted_trueReturned()
        {
            //Arrange
            int cardString = 122;
            //Act
            bool result = strObj.CvcCheck(cardString);
            //Assert
            Assert.IsTrue(result);
        }


    }
}
