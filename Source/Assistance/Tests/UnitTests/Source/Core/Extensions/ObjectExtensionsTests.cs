// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensionsTests.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>14.12.2015 15:27:22</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance.UnitTests" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="14.12.2015 10:23:54" modified="14.12.2015 15:27:22" lastAccess="14.12.2015 15:27:22">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Tests\UnitTests\Source\Core\Extensions\ObjectExtensionsTests.cs
//     </file>
//     <lines total="303" netLines="256" codeLines="201" allCommentLines="86" commentLines="62" documentationLines="24" blankLines="47" codeRatio="66.34 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework.Tests.Core.Extensions</namespace>
//         <class>ObjectExtensionsTests</class>
//         <class>OnlyReadableProperty</class>
//         <class>OnlyWritableProperty</class>
//         <class>ReadAndWritableProperties</class>
//         <class>ReadAndWritableProperty</class>
//     </identifiers>
// </information>
// <summary>
//     TestClass <see cref="ObjectExtensions"/>.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using Syntony.Framework.Core;
using Syntony.Framework.Core.Extensions;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

// ReSharper disable ExpressionIsAlwaysNull

namespace Syntony.Framework.Tests.Core.Extensions
{
    /// <summary>TestClass <see cref="ObjectExtensions"/>.</summary>
    /// <seealso cref="NUnit.Framework.AssertionHelper" />
    [TestFixture]
    public class ObjectExtensionsTests : AssertionHelper
    {
        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>Check <see cref="ObjectExtensions.HasMethod"/>.</summary>
        [Test]
        public void HasMethod()
        {
            object obj = new object();
            object nullObj = null;

            Assert.That(obj.HasMethod(null), Is.False);
            Assert.That(obj.HasMethod(""), Is.False);
            Assert.That(obj.HasMethod(" "), Is.False);
            Assert.That(obj.HasMethod("AnyMethod"), Is.False);

            Assert.That(nullObj.HasMethod("GetHashCode"), Is.False);
            Assert.That(nullObj.HasMethod(""), Is.False);
            Assert.That(nullObj.HasMethod("    "), Is.False);
            Assert.That(nullObj.HasMethod(null), Is.False);

            Assert.That(obj.HasMethod("GetHashCode"), Is.True);
            Assert.That(obj.HasMethod("ToString"), Is.True);
        }

        /// <summary>Check <see cref="ObjectExtensions.ToStringSafe"/>.</summary>
        [Test]
        public void ToStringSafe()
        {
            object obj = new object();
            object nullObj = null;
            string s = "Hello Syntony!";

            Assert.That(obj.ToStringSafe(), Is.Not.Null);
            Assert.That(nullObj.ToStringSafe(), Is.Not.Null);
            Assert.AreEqual(Constants.NullString, nullObj.ToStringSafe());
            Assert.AreEqual(obj.ToString(), obj.ToStringSafe());
            Assert.AreEqual(s, s.ToStringSafe());
        }

        /// <summary>Check <see cref="ObjectExtensions.GetTypeSafe"/>.</summary>
        /// <devdoc>Compare with <see cref="SystemRuntimeTypeCheck"/>.</devdoc>
        [Test]
        public void GetTypeSafe()
        {
            string str = string.Empty;
            Type strType = str.GetTypeSafe();
            Type strTypeType = strType.GetTypeSafe(); // an accidental call GetType()

            Assert.AreEqual("System.String", strType.ToString()); // returns "System.String" if calling GetType() also
            Assert.AreEqual("System.String", strTypeType.ToString());
                // returns "System.RuntimeType" if calling GetType()

            Assert.AreEqual(Type.GetType("System.RuntimeType"), typeof (string).GetType()); // an accidental call
            Assert.AreEqual(Type.GetType("System.String"), typeof (string).GetTypeSafe());
        }

        /// <summary>Check <see cref="ObjectExtensions.ToTypeStringSafe"/>.</summary>
        [Test]
        public void ToTypeStringSafe()
        {
            object obj = new object();
            object nullObj = null;

            Assert.That(obj.ToTypeStringSafe(), Is.Not.Null);
            Assert.That(nullObj.ToTypeStringSafe(), Is.Not.Null);

            Assert.AreEqual(Constants.NullString, nullObj.ToTypeStringSafe());
            Assert.AreNotEqual(Constants.NullString, obj.ToTypeStringSafe());
            Assert.AreEqual(typeof (object).ToString(), obj.ToTypeStringSafe());
            Assert.AreEqual(typeof (string).ToString(), typeof (string).ToTypeStringSafe());
        }

        /// <summary>Check <see cref="ObjectExtensions.ToTypeStringSafe"/>.</summary>
        [Test]
        public void SystemRuntimeTypeCheck()
        {
            string str = string.Empty;
            Type strType = str.GetType();
            Type strTypeType = strType.GetType(); // an accidental call

            Assert.AreEqual("System.String", strType.ToString()); // returns "System.string"
            Assert.AreEqual("System.RuntimeType", strTypeType.ToString()); // returns "System.RuntimeType"   

            Type runtimeType = Type.GetType("System.RuntimeType");
            if (runtimeType == strTypeType)
            {
                Assert.Pass("RuntimeType detected. Test passed.");
            }

            Assert.Fail("RuntimeType not detected. Test failed.");
        }
        /// <summary>Check <see cref="TypeExtensions.GetAllReadableProperties(Type)"/>.</summary>
        [Test]
        public void GetAllReadableProperties()
        {
            object obj = new object();
            object nullObject = null;
            string stringObject = "Hello Syntony!";
            OnlyWritableProperty writablePropertyType = new OnlyWritableProperty();
            OnlyReadableProperty readablePropertyType = new OnlyReadableProperty();
            ReadAndWritableProperty readAndWritablePropertyType = new ReadAndWritableProperty();
            ReadAndWritableProperties readAndWritablePropertiesType = new ReadAndWritableProperties();

            Assert.That(nullObject.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(nullObject.GetAllReadableProperties(), Is.Empty);

            Assert.That(obj.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(obj.GetAllReadableProperties(), Is.Empty); // object has no properties

            Assert.That(stringObject.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(stringObject.GetAllReadableProperties(), Is.Not.Empty); // string has readable properties

            Assert.That(writablePropertyType.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(writablePropertyType.GetAllReadableProperties(), Is.Empty); // class OnlyWritableProperty has no readable properties

            Assert.That(readAndWritablePropertyType.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(readAndWritablePropertyType.GetAllReadableProperties(), Is.Not.Empty); // class ReadAndWritableProperty has one readable property

            Assert.That(readablePropertyType.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(readablePropertyType.GetAllReadableProperties(), Is.Not.Empty); // class OnlyReadableProperty has readable properties
            Assert.AreEqual(1, readablePropertyType.GetAllReadableProperties().Count()); // class OnlyReadableProperty has one readable properties

            Assert.That(readAndWritablePropertiesType.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(readAndWritablePropertiesType.GetAllReadableProperties(), Is.Not.Empty); // class ReadAndWritableProperties has two readable properties
            Assert.AreEqual(2, readAndWritablePropertiesType.GetAllReadableProperties().Count()); // class ReadAndWritableProperties has two readable properties
        }

        /// <summary>Check <see cref="TypeExtensions.GetAllWritableProperties(Type)"/>.</summary>
        [Test]
        public void GetAllWritableProperties()
        {
            object obj = new object();
            object nullObject = null;
            string stringObject = "Hello Syntony!";
            OnlyWritableProperty writablePropertyType = new OnlyWritableProperty();
            OnlyReadableProperty readablePropertyType = new OnlyReadableProperty();
            ReadAndWritableProperty readAndWritablePropertyType = new ReadAndWritableProperty();
            ReadAndWritableProperties readAndWritablePropertiesType = new ReadAndWritableProperties();

            Assert.That(nullObject.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(nullObject.GetAllWritableProperties(), Is.Empty);

            Assert.That(obj.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(obj.GetAllWritableProperties(), Is.Empty); // object has no properties

            Assert.That(stringObject.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(stringObject.GetAllWritableProperties(), Is.Empty); // string has no writable properties

            Assert.That(writablePropertyType.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(writablePropertyType.GetAllWritableProperties(), Is.Not.Empty); // class OnlyWritableProperty has writable properties
            Assert.AreEqual(1, writablePropertyType.GetAllWritableProperties().Count()); // class OnlyWritableProperty has one writable properties

            Assert.That(readablePropertyType.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(readablePropertyType.GetAllWritableProperties(), Is.Empty); // class OnlyReadableProperty has no writable properties

            Assert.That(readAndWritablePropertyType.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(readAndWritablePropertyType.GetAllWritableProperties(), Is.Not.Empty); // class ReadAndWritableProperty has one writable property
            Assert.AreEqual(1, readAndWritablePropertyType.GetAllWritableProperties().Count()); // class ReadAndWritableProperty has one writable property

            Assert.That(readAndWritablePropertiesType.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(readAndWritablePropertiesType.GetAllWritableProperties(), Is.Not.Empty); // class ReadAndWritableProperties has two writable properties
            Assert.AreEqual(2, readAndWritablePropertiesType.GetAllWritableProperties().Count()); // class ReadAndWritableProperties has two writable properties
        }

        /// <summary>Check <see cref="TypeExtensions.GetAllReadableAndWritableProperties(Type)"/>.</summary>
        [Test]
        public void GetAllReadableAndWritableProperties()
        {
            object obj = new object();
            object nullObject = null;
            string stringObject = "Hello Syntony!";
            OnlyWritableProperty onlyWritablePropertyType = new OnlyWritableProperty();
            OnlyReadableProperty onlyReadablePropertyType = new OnlyReadableProperty();
            ReadAndWritableProperty readAndWritablePropertyType = new ReadAndWritableProperty();
            ReadAndWritableProperties readAndWritablePropertiesType = new ReadAndWritableProperties();

            Assert.That(nullObject.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(nullObject.GetAllReadableAndWritableProperties(), Is.Empty);

            Assert.That(obj.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(obj.GetAllReadableAndWritableProperties(), Is.Empty); // object has no properties

            Assert.That(stringObject.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(stringObject.GetAllReadableAndWritableProperties(), Is.Empty); // string has no writable but readable properties

            Assert.That(onlyWritablePropertyType.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(onlyWritablePropertyType.GetAllReadableAndWritableProperties(), Is.Empty); // class OnlyWritableProperty has one writable property that is not readable

            Assert.That(onlyReadablePropertyType.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(onlyReadablePropertyType.GetAllReadableAndWritableProperties(), Is.Empty); // class OnlyReadableProperty has one readable property that is not writable

            Assert.That(readAndWritablePropertyType.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(readAndWritablePropertyType.GetAllWritableProperties(), Is.Not.Empty); // class ReadAndWritableProperty has one writable property
            Assert.AreEqual(1, readAndWritablePropertyType.GetAllWritableProperties().Count()); // class ReadAndWritableProperty has one writable property

            Assert.That(readAndWritablePropertiesType.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(readAndWritablePropertiesType.GetAllReadableAndWritableProperties(), Is.Not.Empty); // class ReadAndWritableProperties has two writable properties
            Assert.AreEqual(2, readAndWritablePropertiesType.GetAllReadableAndWritableProperties().Count()); // class ReadAndWritableProperties has two writable properties
        }

        /// <summary>A helper class with one writable property only (one setter no getter).</summary>
        private class OnlyWritableProperty
        {
            private string caption = "OnlyWritableProperty Default caption";

            /// <summary>Sets the caption.</summary>
            /// <value>The caption.</value>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [NotNull]
            [UsedImplicitly]
            public string Caption
            {
                set
                {
                    if (value != null && caption != value)
                    {
                        caption = value;
                    }
                }
            }
        }

        /// <summary>A helper class with one readable property only (one getter no setter).</summary>
        private class OnlyReadableProperty
        {
            /// <summary>Gets the caption.</summary>
            /// <value>The caption.</value>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [NotNull]
            [UsedImplicitly]
            public string Caption { get; } = "OnlyReadableProperty Default caption";
        }

        // <summary>A helper class with one readable and writable property.</summary>
        private class ReadAndWritableProperty
        {
            /// <summary>Gets or sets the caption.</summary>
            /// <value>The caption.</value>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [NotNull]
            [UsedImplicitly]
            public string Caption { get; set; } = "ReadAndWritableProperty Default caption";
        }

        // <summary>A helper class with two readable and writable properties.</summary>
        private class ReadAndWritableProperties
        {
            /// <summary>Gets or sets the caption.</summary>
            /// <value>The caption.</value>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [NotNull]
            [UsedImplicitly]
            public string Caption { get; set; } = "ReadAndWritableProperty Default caption";

            /// <summary>Gets or sets the length of the caption.</summary>
            /// <value>The length of the caption.</value>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [UsedImplicitly]
            public int CaptionLength { get; set; } = 12;
        }
    }
}