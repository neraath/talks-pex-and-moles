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
    }
}
