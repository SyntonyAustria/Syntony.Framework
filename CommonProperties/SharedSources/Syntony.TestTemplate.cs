// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Syntony.TestTemplate.cs" company="Syntony">
//   Copyright © 2012-2012 by Syntony - http://members.aon.at/hahnl - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA / Pepi</author>
// <email>hahnl@aon.at</email>
// <date>06.06.2012 09:32:34</date>
// <information solution="Syntony.Framework.CommonObjectRuntime" project="Tests" framework=".NET Framework 4.0" kind="Windows (C#)">
//   <file type =".cs" created ="06.05.2012 17:37:50" modified="06.06.2012 09:30:43">
//     C:\Users\Pepi\Documents\Syntony\Projects\SharedSource\Syntony.TestTemplate.cs
//   </file>
//   <lines total="252" allCommentLines="131" blankLines="28" codeLines="94" codeRatio="37,30 %" commentLines="98" documentationLines="33" netLines="224"/>
//   <language>C#</language>
//   <namespace>Syntony.Tests</namespace>
//   <class>ClassTest</class>
//   <Identifiers>
//     namespaces: Syntony.Tests
//     classes: ClassTest
//   </Identifiers>
// </information>
// <summary>
//   Unit test class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Syntony.Tests
{
    using System.Diagnostics;

    #region Documentation and usings issues

    #region MSTest/NUnit Compatability

    // ReSharper disable RedundantUsingDirective

    // Define MS_TEST or NUNIT_TEST as a conditional compilation symbol in your DEBUG build then you can do testing with your DEBUG test builds
    // directly in Visual Studio. This also means you can debug your tests.
    // Notice, if you use any MS_Test specific functionality that is NOT available in NUnit, it WILL NOT WORK in NUnit!
    // Such functionality includes any direct use of TestContext, any web service related attributes and other stuff I haven’t yet dug up but know exists!
    // Any NUnit functionality WILL work in MSTest since the NUnit Assert is THE Assert class and the NUnit.Framework assembly
    // is referenced and used. Any test assemblies that have been built with MSTEST specified will NOT work in NUnit, therefore
    // it is suggested that from time to time you create a Release build of your tests. If you have used any MSTest only functionality
    // then your build (and consequently the build of your test on the build server) will FAIL. Check it!
    // Notice, ensure your test is in DEBUG build before using VS to create unit tests or it will add MSTest usings into your Release build!
    
    // A comparison of attributes and assertions can be found at:
    // http://xunit.codeplex.com/wikipage?title=Comparisons&referringTitle=Home&ProjectName=xunit
    // http://www.codeproject.com/Articles/5019/Advanced-Unit-Testing-Part-I-Overview
#if !MS_TEST && !NUNIT_TEST
#error ******* Builds should define MS_TEST or NUNIT_TEST as a conditional compilation symbol in Project Properties -> Build Tab ************
#endif

#if MS_TEST
    using System.Diagnostics.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
    
    // Since NUnit’s Assert is a superset of MSTest’s Assert, we’ll treat Assert as the NUnit version and get the extra goodies.
    using Syntony.Framework.Annotations;

    using Assert = NUnit.Framework.Assert;
    using AssertionException = NUnit.Framework.AssertionException;
    using Category = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute;
    using Is = NUnit.Framework.Is;
    using MaxTime = NUnit.Framework.MaxTimeAttribute;
    using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
    using TestFixture = Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute;
    using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
    using SetUp = Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute;
    using TearDown = Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute;
    using TestFixtureSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;
    using TestFixtureTearDown = Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute;

#elif NUNIT_TEST

    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    // The following using declarations allow the Visual Studio auto-generated framework to actually use NUnit attributes.
    // This means that where in the test code below we see the VS generated [TestClass()] attribute, it is “really” [TestFixture],
    // i.e. NUnit style with MSTest syntax – which gets auto-generated and is thus easier to “write” as VS does it for you. 
    using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
    using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;
    using TestClass = NUnit.Framework.TestFixtureAttribute;
    using TestCleanup = NUnit.Framework.TearDownAttribute;
    using TestContext = System.Object;
    using TestInitialize = NUnit.Framework.SetUpAttribute;
    using TestMethod = NUnit.Framework.TestAttribute;
#endif

    // ReSharper restore RedundantUsingDirective
    #endregion

    #region Aspects
    // A unit test is an automated piece of a code (usually a method or a class) that invokes another
    // piece of code and checks the correctness of some assumptions about the logical
    // behavior of that method or class.
    // If the assumptions turn out to be wrong, the unit test has failed.
    // A “unit” is a method or function. It can be written easily and runs
    // quickly. It’s fully automated, trustworthy, readable, and maintainable.
    //  
    // Integration testing means testing two or more dependent software modules as a group.
    //  
    // A unit test should have the following properties: 
    // • It should be automated and repeatable. 
    // • It should be easy to implement. 
    // • Once it’s written, it should remain for future use. 
    // • Anyone should be able to run it. 
    // • It should run at the push of a button. 
    // • It should run quickly. 
    //  
    // Ask yourself the following questions about a unit test: 
    // • Can I run and get results from a unit test I wrote two weeks or months or years ago? 
    // • Can any member of my team run and get the results from unit tests I wrote two months ago? 
    // • Can I run all the unit tests I’ve written in no more than a few minutes? 
    // • Can I run all the unit tests I’ve written at the push of a button? 
    // • Can I write a basic unit test in no more than a few minutes? 
    //  
    // Before writing a unit test you should consider the following questions: 
    // • Right - the results are right? 
    // • Boundaries - all the framework requirement are right? 
    // • Inverse - can inverse relationships be checked? 
    // • Correct - the results can be checked with help of other means? 
    // • Fault - mistake-conditions can be forced? 
    // • Performance - the performance-features are within acceptable borders? 
    //  
    // A test is NOT a unit test if: 
    // • It talks to the database 
    // • It communicates across the network 
    // • It touches the file system 
    // • It can't run at the same time as any of your other unit tests 
    // • You have to do special things to your environment (such as editing config files) to run it.
    // 
    // http://www.rhyous.com/programming-development/csharp-unit-test-tutorial/
    // 
    // • Test one object or class per unit test class 
    // • Name your test class after the class it tests 
    //   * file name: Class.Test.cs 
    //   * class name: public class ClassTest{} 
    //   * test method:  TestMethodTrue() {} 
    // • Perform one test per test function 
    // • A unit test should run on the Build and Continuous Integration (CI) systems. 
    // • A unit test should never alter the system in any way. 
    // • Never assume 100% code coverage means 100% tested. 
    // • Test in the simplest way possible.
    #endregion Aspects

    #endregion Documentation and usings issues

    /// <summary>
    /// Unit test class.
    /// </summary>
    [TestFixture]
    public class ClassTest
    {
        #region Initialization / Cleanup

#pragma warning disable 1587 // XML comment is not placed on a valid language element

#if MS_TEST
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        [NotNull]
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Use ClassInitialize to run code before running the first test in the class
        /// </summary>
        /// <param name="context">The test context.</param>
        /// <devdoc>Methods with this attribute are called before the execution of the first test.</devdoc>
        [TestFixtureSetUp]
        public static void ClassInitialize([NotNull] TestContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null);
            Trace.WriteLine("ClassInitialize " + context.TestName);
        }
#endif

#if NUNIT_TEST
        /// <summary>
        /// Use ClassInitialize to run code before running the first test in the class
        /// </summary>
        /// <devdoc>Methods with this attribute are called before the execution of the first test.</devdoc>
        [TestFixtureSetUp]
        public static void ClassInitialize()
        {
            Trace.WriteLine("ClassInitialize");
        }
#endif
#pragma warning restore 1587

        /// <summary>
        /// Use ClassCleanup to run code after all tests in a class have run.
        /// </summary>
        /// <devdoc>Methods with this attribute are called after the execution of ALL tests.</devdoc>
        [TestFixtureTearDown]
        public static void ClassCleanup()
        {
            Trace.WriteLine("ClassCleanup");
        }

        /// <summary>
        /// Use TestInitialize to run code before running each test in our class.
        /// </summary>
        /// <devdoc>Methods with this attribute are called before the execution of each TestMethod().</devdoc>
        [SetUp]
        public void TestInitialize()
        {
            Trace.WriteLine("TestInitialize started");
            
            // object testObject = new object();
            // ...
            Trace.WriteLine("TestInitialize finished");
        }

        /// <summary>
        /// Use TestCleanup to run code after each test has run in our class.
        /// </summary>
        [TearDown]
        public void TestCleanup()
        {
            Trace.WriteLine("TestCleanup started");
            
            // object testObject = null;
            // ...
            Trace.WriteLine("TestCleanup finished");
        }
        #endregion

        /// <summary>
        /// A default test method.
        /// </summary>
        [Test, MaxTime(2000), Category("Short")]
        public void TestMethodDefault()
        {
            Assert.That(new object(), Is.Not.Null);
        }

        /// <summary>
        /// A default test method with an expected exception.
        /// </summary>
        [Test, MaxTime(2000), Category("Short")]
        [ExpectedException(typeof(AssertionException))]
        public void TestMethodDefaultException()
        {
            Assert.That(new object(), Is.Null);
        }
    }
}
