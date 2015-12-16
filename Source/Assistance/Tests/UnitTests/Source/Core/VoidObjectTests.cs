// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="VoidObjectTests.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>14.12.2015 16:21:23</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance.UnitTests" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="14.12.2015 08:29:56" modified="14.12.2015 16:21:23" lastAccess="14.12.2015 16:21:23">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Tests\UnitTests\Source\Core\VoidObjectTests.cs
//     </file>
//     <lines total="158" netLines="140" codeLines="103" allCommentLines="39" commentLines="27" documentationLines="12" blankLines="18" codeRatio="65.19 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework.Tests.Core</namespace>
//         <class>VoidObjectTests</class>
//     </identifiers>
// </information>
// <summary>
//     TestClass ConstantsTests.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System.Diagnostics;
using NUnit.Framework;
using Syntony.Framework.Core;
// ReSharper disable ExpressionIsAlwaysNull

namespace Syntony.Framework.Tests.Core
{
    /// <summary>TestClass ConstantsTests.</summary>
    /// <seealso cref="NUnit.Framework.AssertionHelper" />
    [TestFixture]
    public class VoidObjectTests : AssertionHelper
    {
        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>Cleanups this instance.</summary>
        [TearDown]
        public void Cleanup()
        {
        }

        /// <summary>Check existence of <see cref="VoidObject.VoidResult"/>.</summary>
        [Test]
        public void VoidResult()
        {
            VoidObject.VoidResult voidResult = default(VoidObject.VoidResult);
            Assert.That(voidResult, Is.Null);
            Assert.That(typeof (VoidObject.VoidResult), Is.Not.Null);
        }

        /// <summary>Check <see langword="null"/> is same as <see cref="VoidObject.Null"/>.</summary>
        [Test]
        public new void Null()
        {
            Assert.AreEqual(null, VoidObject.Null);
            Assert.AreSame(null, VoidObject.Null);
            Assert.AreSame(VoidObject.Null, VoidObject.Null);
        }

        /// <summary>Check <see cref="VoidObject.EmptyObjects"/>.</summary>
        [Test]
        public new void Empty()
        {
            Assert.That(VoidObject.EmptyObjects, Is.Not.Null);
            Assert.AreEqual(Constants.EmptyObjects, VoidObject.EmptyObjects);
            Assert.AreSame(Constants.EmptyObjects, VoidObject.EmptyObjects);
            Assert.AreSame(VoidObject.EmptyObjects, VoidObject.EmptyObjects);
        }

        /// <summary>Check <see cref="VoidObject"/>.</summary>
        [Test]
        public void Constructor()
        {
            VoidObject obj1 = VoidObject.Default;
            VoidObject obj2 = VoidObject.Default;

            Assert.That(obj1, Is.Not.Null);
            Assert.That(obj2, Is.Not.Null);
        }

        /// <summary>Check <see cref="VoidObject"/>.</summary>
        [Test]
        public new void ToString()
        {
            VoidObject obj1 = VoidObject.Default;
            VoidObject obj2 = VoidObject.Default;

            Assert.AreEqual(obj1.ToString(), obj2.ToString());
            Assert.AreEqual(Constants.VoidStringRepresentation, obj1.ToString());
            Assert.AreSame(Constants.VoidStringRepresentation, obj1.ToString());
        }

        /// <summary>Check <see cref="VoidObject"/>.</summary>
        [Test]
        public void Compare()
        {
            VoidObject obj1 = VoidObject.Default;
            VoidObject obj2 = VoidObject.Default;

            Assert.That(obj1 == obj2, Is.True);
            Assert.That(obj2 == obj1, Is.True);
#pragma warning disable CS1718 // Comparison made to same variable
            // ReSharper disable once EqualExpressionComparison
            Assert.That(obj1 == obj1, Is.True);
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.That(obj1 != obj2, Is.False);
            Assert.That(obj2 != obj1, Is.False);

            Assert.That(obj1.Equals(obj2), Is.True);
            Assert.That(obj2.Equals(obj2), Is.True);
            Assert.That(obj2.Equals(obj1), Is.True);

            Assert.AreEqual(0, obj1.GetHashCode());
            Assert.AreEqual(0, obj2.GetHashCode());

            Assert.That(obj1.Equals((object)obj2), Is.True);
        }

        /// <summary>Check <see cref="VoidObject.Nop()"/>.</summary>
        [Conditional("DEBUG")]
        [Conditional("SYNTONY_CODE_ANALYSIS")]
        [Test]
        public void Nop()
        {
            VoidObject.Nop();
        }

        /// <summary>Check <see cref="VoidObject.Nop()"/>.</summary>
        [Conditional("DEBUG")]
        [Conditional("SYNTONY_CODE_ANALYSIS")]
        [Test]
        public void NopWithValue()
        {
            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(tr1);
            string s = "Hello Syntony!";
            VoidObject.Nop(s);
            Debug.Listeners.Clear();
        }

        [Test]
        public void Default()
        {
            // VoidObject voidObject = new VoidObject(); // compiler error
            Assert.That(VoidObject.Default, Is.Not.Null);
            Assert.AreEqual(VoidObject.Default, VoidObject.Default);
            Assert.AreSame(VoidObject.Default, VoidObject.Default);
            Assert.AreEqual(Constants.VoidStringRepresentation, VoidObject.Default.ToString());
            Assert.AreSame(Constants.VoidStringRepresentation, VoidObject.Default.ToString());
        }
    }
}