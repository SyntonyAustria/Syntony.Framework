// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Syntony.NUnitTestTemplate.cs" company="Syntony">
//   Copyright © 2012-2012 by Syntony - http://members.aon.at/hahnl - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA / Pepi</author>
// <email>hahnl@aon.at</email>
// <date>25.06.2012 15:16:26</date>
// <information solution="Syntony.TestFramework" project="Syntony.TestFramework.UnitTests" framework=".NET Framework 4.0" kind="Windows (C#)">
//   <file type =".cs" created ="25.06.2012 14:01:15" modified="25.06.2012 14:04:48">
//     C:\Users\Pepi\Documents\Syntony\Projects\Framework\SharedSource\Syntony.NUnitTestTemplate.cs
//   </file>
//   <lines total="174" allCommentLines="111" blankLines="13" codeLines="50" codeRatio="28,74 %" commentLines="79" documentationLines="32" netLines="161"/>
//   <language>.cs</language>
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

    using NUnit.Framework;

    #region Documentation and usings issues

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

        /// <summary>
        /// Use TestFixtureSetup to run code before running the first test in the class.
        /// </summary>
        /// <devdoc>Methods with this attribute are called before the execution of the first test.</devdoc>
        /// <remarks>Defining a TestFixtureSetup method in the base class and another in the derived class. 
        /// NUnit will call base class TestFixtureSetup methods before those in the derived classes.<br/>
        /// If a TestFixtueSetup method fails or throws an exception, none of the tests in the fixture 
        /// are executed and a failure or error is reported.</remarks>
        [TestFixtureSetup]
        public static void TestFixtureSetup()
        {
            string name = MethodBase.GetCurrentMethod().ReflectedType.Name;
            Trace.WriteLine(string.Format("TestClass '{0}' initialized.", name));
        }

        /// <summary>
        /// Use TestFixtureTearDown to run code after all tests in a class have run.
        /// </summary>
        /// <devdoc>Methods with this attribute are called after the execution of ALL tests.</devdoc>
        /// <remarks>Defining a TestFixtureTearDown method in the base class and another in the derived class. 
        /// NUnit will call base class TestFixtureTearDown methods after those in the derived classes.<br/>
        /// So long as any TestFixtureSetup method runs without error, the TestFixtureTearDown method is guaranteed to run. 
        /// It will not run if a TestFixtureSetup method fails or throws an exception.</remarks>
        [TestFixtureTearDown]
        public static void TestFixtureTearDown()
        {
            string name = MethodBase.GetCurrentMethod().ReflectedType.Name;
            Trace.WriteLine(string.Format("TestClass '{0}' stopped.", name));
        }

        /// <summary>
        /// Use TestInitialize to run code before running each test in our class.
        /// </summary>
        /// <devdoc>Methods with this attribute are called before the execution of each TestMethod().</devdoc>
        [Setup]
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