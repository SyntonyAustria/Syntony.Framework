// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensionsTests.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>14.12.2015 14:39:35</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance.UnitTests" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="14.12.2015 13:40:41" modified="14.12.2015 14:39:35" lastAccess="14.12.2015 14:39:35">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Tests\UnitTests\Source\Core\Extensions\TypeExtensionsTests.cs
//     </file>
//     <lines total="200" netLines="169" codeLines="126" allCommentLines="62" commentLines="47" documentationLines="15" blankLines="31" codeRatio="63.00 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework.Tests.Core.Extensions</namespace>
//         <class>OnlyReadableProperty</class>
//         <class>OnlyWritableProperty</class>
//         <class>ReadAndWritableProperty</class>
//         <class>TypeExtensionsTests</class>
//     </identifiers>
// </information>
// <summary>
//     TestClass <see cref="TypeExtensions"/>.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using Syntony.Framework.Core.Extensions;

// ReSharper disable ConditionIsAlwaysTrueOrFalse

// ReSharper disable ExpressionIsAlwaysNull

namespace Syntony.Framework.Tests.Core.Extensions
{
    /// <summary>TestClass <see cref="TypeExtensions"/>.</summary>
    /// <seealso cref="NUnit.Framework.AssertionHelper" />
    [TestFixture]
    public class TypeExtensionsTests : AssertionHelper
    {
        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>Check <see cref="TypeExtensions.HasMethod"/>.</summary>
        [Test]
        public void HasMethod()
        {
            Type type = typeof (object);
            Type nullType = null;

            Assert.That(type.HasMethod(null), Is.False);
            Assert.That(type.HasMethod(""), Is.False);
            Assert.That(type.HasMethod(" "), Is.False);
            Assert.That(type.HasMethod("AnyMethod"), Is.False);

            Assert.That(nullType.HasMethod("GetHashCode"), Is.False);
            Assert.That(nullType.HasMethod(""), Is.False);
            Assert.That(nullType.HasMethod("    "), Is.False);
            Assert.That(nullType.HasMethod(null), Is.False);

            Assert.That(type.HasMethod("GetHashCode"), Is.True);
            Assert.That(type.HasMethod("ToString"), Is.True);

            Assert.That(typeof (string).HasMethod("IsNullOrEmpty"), Is.True); // static method
            Assert.That(typeof (string).HasMethod("ToUpper"), Is.True); // instance method
            Assert.That(typeof (string).HasMethod("GetStringLength"), Is.False); // method not implemented
        }

        /// <summary>Check <see cref="TypeExtensions.GetAllReadableProperties(Type)"/>.</summary>
        [Test]
        public void GetAllReadableProperties()
        {
            Type type = typeof (object);
            Type nullType = null;
            Type stringType = typeof (string);
            Type writablePropertyType = typeof(OnlyWritableProperty);
            Type readablePropertyType = typeof(OnlyReadableProperty);
            Type readAndWritablePropertyType = typeof(ReadAndWritableProperty);
            Type readAndWritablePropertiesType = typeof(ReadAndWritableProperties);

            Assert.That(nullType.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(nullType.GetAllReadableProperties(), Is.Empty);

            Assert.That(type.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(type.GetAllReadableProperties(), Is.Empty); // object has no properties

            Assert.That(stringType.GetAllReadableProperties(), Is.Not.Null);
            Assert.That(stringType.GetAllReadableProperties(), Is.Not.Empty); // string has readable properties

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
            Type type = typeof (object);
            Type nullType = null;
            Type stringType = typeof (string);
            Type writablePropertyType = typeof(OnlyWritableProperty);
            Type readablePropertyType = typeof (OnlyReadableProperty);
            Type readAndWritablePropertyType = typeof (ReadAndWritableProperty);
            Type readAndWritablePropertiesType = typeof(ReadAndWritableProperties);

            Assert.That(nullType.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(nullType.GetAllWritableProperties(), Is.Empty);

            Assert.That(type.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(type.GetAllWritableProperties(), Is.Empty); // object has no properties

            Assert.That(stringType.GetAllWritableProperties(), Is.Not.Null);
            Assert.That(stringType.GetAllWritableProperties(), Is.Empty); // string has no writable properties

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
            Type type = typeof(object);
            Type nullType = null;
            Type stringType = typeof(string);
            Type onlyWritablePropertyType = typeof(OnlyWritableProperty);
            Type onlyReadablePropertyType = typeof(OnlyReadableProperty);
            Type readAndWritablePropertyType = typeof(ReadAndWritableProperty);
            Type readAndWritablePropertiesType = typeof(ReadAndWritableProperties);

            Assert.That(nullType.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(nullType.GetAllReadableAndWritableProperties(), Is.Empty);

            Assert.That(type.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(type.GetAllReadableAndWritableProperties(), Is.Empty); // object has no properties

            Assert.That(stringType.GetAllReadableAndWritableProperties(), Is.Not.Null);
            Assert.That(stringType.GetAllReadableAndWritableProperties(), Is.Empty); // string has no writable but readable properties

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
            [NotNull]
            [UsedImplicitly]
            public string Caption { get; } = "OnlyReadableProperty Default caption";
        }

        // <summary>A helper class with one readable and writable property.</summary>
        private class ReadAndWritableProperty
        {
            /// <summary>Gets or sets the caption.</summary>
            /// <value>The caption.</value>
            [NotNull]
            [UsedImplicitly]
            public string Caption { get; set; } = "ReadAndWritableProperty Default caption";
        }

        // <summary>A helper class with two readable and writable properties.</summary>
        private class ReadAndWritableProperties
        {
            /// <summary>Gets or sets the caption.</summary>
            /// <value>The caption.</value>
            [NotNull]
            [UsedImplicitly]
            public string Caption { get; set; } = "ReadAndWritableProperty Default caption";

            /// <summary>Gets or sets the length of the caption.</summary>
            /// <value>The length of the caption.</value>
            [UsedImplicitly]
            public int CaptionLength { get; set; } = 12;
        }
    }
}