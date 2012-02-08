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

        [PexMethod]
        public void TestCvvCodeValue([PexAssumeNotNull] string cvvCode)
        {
            PexAssume.IsTrue(cvvCode.Length >= 3 && cvvCode.Length <= 4);
            PexAssume.TrueForAll(cvvCode, codeDigit => char.IsDigit(codeDigit));
            PexAssume.IsTrue(cvvCode.StartsWith("3") || cvvCode.EndsWith("4"));
            PexAssume.IsTrue(CardValidator.IsCvvCodeValid(cvvCode));
        }

        [PexMethod]
        public void TestBadCvvCodeLength([PexAssumeNotNull] string cvvCode)
        {
            PexAssume.IsFalse(cvvCode.Length >= 3 && cvvCode.Length <= 4);
            PexAssume.TrueForAll(cvvCode, codeDigit => char.IsDigit(codeDigit));
            PexAssume.IsTrue(cvvCode.StartsWith("3") || cvvCode.EndsWith("4"));
            PexAssume.IsFalse(CardValidator.IsCvvCodeValid(cvvCode));
        }

        [PexMethod]
        public void TestBadCvvCodeValue([PexAssumeNotNull] string cvvCode)
        {
            PexAssume.IsTrue(cvvCode.Length >= 3 && cvvCode.Length <= 4);
            PexAssume.TrueForAll(cvvCode, codeDigit => char.IsDigit(codeDigit));
            PexAssume.IsFalse(cvvCode.StartsWith("3") || cvvCode.EndsWith("4"));
            PexAssume.IsFalse(CardValidator.IsCvvCodeValid(cvvCode));
        }
    }
}
