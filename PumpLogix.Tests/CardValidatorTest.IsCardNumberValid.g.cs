// <copyright file="CardValidatorTest.IsCardNumberValid.g.cs">Copyright �  2012</copyright>
// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace PumpLogix
{
    public partial class CardValidatorTest
    {
[TestMethod]
[PexGeneratedBy(typeof(CardValidatorTest))]
public void IsCardNumberValid345()
{
    bool b;
    b = this.IsCardNumberValid("");
    Assert.AreEqual<bool>(false, b);
}
    }
}
