using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PumpLogix;

namespace PumpLogixTests
{
    [TestClass]
    public class CardvalidatorTests
    {
        [TestMethod]
        public void TestValidVisaValidates()
        {
            string cardNumber = "4111111111111111";
            Assert.IsTrue(CardValidator.IsCardNumberValid(cardNumber));
        }

        [TestMethod]
        public void TestInvalidVisaInvalidates()
        {
            string cardNumber = "4111111111111112";
            Assert.IsFalse(CardValidator.IsCardNumberValid(cardNumber));
        }

        [TestMethod]
        public void TestValidDiscoverValidates()
        {
            string cardNumber = "6011111111111117";
            Assert.IsTrue(CardValidator.IsCardNumberValid(cardNumber));
        }

        [TestMethod]
        public void TestInvalidDiscoverInvalidates()
        {
            string cardNumber = "6011111111111118";
            Assert.IsFalse(CardValidator.IsCardNumberValid(cardNumber));
        }

        [TestMethod]
        public void TestValidAmexValidates()
        {
            string cardNumber = "378282246310005";
            Assert.IsTrue(CardValidator.IsCardNumberValid(cardNumber));
        }

        [TestMethod]
        public void TestInvalidAmexInvalidates()
        {
            string cardNumber = "378282246310006";
            Assert.IsFalse(CardValidator.IsCardNumberValid(cardNumber));
        }

        [TestMethod]
        public void TestValidMastercardValidates()
        {
            string cardNumber = "5105105105105100";
            Assert.IsTrue(CardValidator.IsCardNumberValid(cardNumber));
        }

        [TestMethod]
        public void TestInvalidMastercardInvalidates()
        {
            string cardNumber = "5555555555555555";
            Assert.IsFalse(CardValidator.IsCardNumberValid(cardNumber));
        }
    }
}
