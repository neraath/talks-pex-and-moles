// <copyright file="CardValidatorTest.cs">Copyright ©  2012</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PumpLogix;

namespace PumpLogix
{
    [TestClass]
    [PexClass(typeof(CardValidator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CardValidatorTest
    {
        [PexMethod]
        public bool IsCardNumberValid(string cardNumber)
        {
            bool result = CardValidator.IsCardNumberValid(cardNumber);
            return result;
            // TODO: add assertions to method CardValidatorTest.IsCardNumberValid(String)
        }

        [PexMethod]
        public void TestValidCardNumber([PexAssumeNotNull] string cardNumber)
        {
            PexAssume.IsTrue(cardNumber.Length >= 15);
            PexAssume.TrueForAll(cardNumber, cardDigit => char.IsDigit(cardDigit));
            PexAssume.IsTrue(CardValidator.IsCardNumberValid(cardNumber));
        }

        [PexMethod]
        public void TestInvalidLength(string cardNumber)
        {
            PexAssume.IsNotNullOrEmpty(cardNumber);
            PexAssume.IsTrue(cardNumber.Length < 15);
            PexAssume.TrueForAll(cardNumber, digit => char.IsDigit(digit));
            PexAssume.IsFalse(CardValidator.IsCardNumberValid(cardNumber));
        }

        [PexMethod]
        public void TestInvalidCharacters([PexAssumeNotNull] string cardNumber)
        {
            PexAssume.IsTrue(cardNumber.Length >= 15);
            PexAssume.TrueForAny(cardNumber, cardCharacter => !char.IsDigit(cardCharacter));
            PexAssume.IsFalse(CardValidator.IsCardNumberValid(cardNumber));
        }
    }
}
