// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantsTests.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>14.12.2015 10:39:08</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance.UnitTests" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="10.12.2015 16:43:49" modified="14.12.2015 10:39:08" lastAccess="14.12.2015 10:39:08">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Tests\UnitTests\Source\Framework\ConstantsTests.cs
//     </file>
//     <lines total="94" netLines="86" codeLines="53" allCommentLines="33" commentLines="22" documentationLines="11" blankLines="8" codeRatio="56.38 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework.Tests.Framework</namespace>
//         <class>ConstantsTests</class>
//     </identifiers>
// </information>
// <summary>
//     TestClass ConstantsTests.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
namespace Syntony.Framework.Tests.Framework
{
    using System;

    using NUnit.Framework;

    /// <summary>TestClass ConstantsTests.</summary>
    /// <seealso cref="NUnit.Framework.AssertionHelper" />
    [TestFixture]
    public class ConstantsTests : AssertionHelper
    {
        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>Passes the test.</summary>
        [Test]
        public void PassTest()
        {
            Assert.Pass("My first passing test.");
        }

        /// <summary>
        /// Check Syntony name.
        /// </summary>
        [Test]
        public void SyntonyName()
        {
            Assert.AreEqual("Syntony", Constants.SyntonyName);
        }

        /// <summary>Check NotSet property.</summary>
        [Test]
        public void NotSet()
        {
            Assert.AreEqual(Constants.NotSet, Constants.NotSet);
            Assert.AreSame(Constants.NotSet, Constants.NotSet);
            Assert.IsNotNull(Constants.NotSet);
        }

        /// <summary>Check EmptyObjects property.</summary>
        [Test]
        public void EmptyObjects()
        {
            Assert.AreEqual(Constants.EmptyObjects, Constants.EmptyObjects);
            Assert.AreSame(Constants.EmptyObjects, Constants.EmptyObjects);
            Assert.That(Constants.EmptyObjects, Is.Not.Null);
            Assert.That(Constants.EmptyObjects, Is.Empty);
        }

        /// <summary>Check EmptyTypes property.</summary>
        [Test]
        public void EmptyTypes()
        {
            Assert.AreEqual(Constants.EmptyTypes, Constants.EmptyTypes);
            Assert.AreEqual(Constants.EmptyTypes, Type.EmptyTypes);
            Assert.AreSame(Constants.EmptyTypes, Constants.EmptyTypes);
            Assert.AreSame(Constants.EmptyTypes, Type.EmptyTypes);
            Assert.That(Constants.EmptyTypes, Is.Not.Null);
            Assert.That(Constants.EmptyTypes, Is.Empty);
        }

        /// <summary>Check <see cref="Constants.NullString"/> is not <see langword="null"/>.</summary>
        [Test]
        public void NullString()
        {
            Assert.That(Constants.NullString, Is.Not.Null);
        }
    }
}