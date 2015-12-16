// --------------------------------------------------------------------------------------------------------------------
// <copyright file="{File}" company="{Company}">
//   Copyright © {CreationDate:yyyy}-{CurrentDate:yyyy} by {Company} - {Website} - All rights reserved.
// </copyright>
// <author>{Author} / {User}</author>
// <email>{Mail}</email>
// <date>{CurrentDate}</date>
// <information solution="{Solution}" project="{Project}" framework="{ProjectTargetFramework}" kind="{ProjectKind}">
//   <file type ="{FileType}" created ="{CreationDate}" modified="{LastModifiedDate}">
//     {FileNameLong}
//   </file>
//   <lines total="{LinesOfCode}" allCommentLines="{AllCommentLines}" blankLines="{BlankLines}" codeLines="{CodeLines}" codeRatio="{CodeRatio:0.00 %}" commentLines="{CommentLines}" documentationLines="{DocumentationLines}" netLines="{NetLines}"/>
//   <language>{Language}</language>
//   <namespace>{Namespace}</namespace>
//   <class>{Class}</class>
//   <Identifiers>
//     {Identifiers:namespace}
//     {Identifiers:class}
//     {Identifiers:struct}
//     {Identifiers:interface}
//     {Identifiers:enum}
//     {Identifiers:delegate}
//     {Identifiers:event}
//   </Identifiers>
// </information>
// <summary>
//   {Summary}
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Syntony.UnitTests
{
    using global::NUnit.Framework;

    using Syntony.TestFramework.NUnit;

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
    
    /// <summary>
    /// Unit test class for a class of the Syntony.Framework.
    /// </summary>
    [TestFixture]
    public class ClassTests : TestBase
    {
        /// <summary>
        /// Test if Method performs correctly.
        /// </summary>
        [Test, MaxTime(2000), Category("Short")]
        [ExpectedException(typeof(AssertionException))]
        public static void TestMethod()
        {
        }
    }
}
