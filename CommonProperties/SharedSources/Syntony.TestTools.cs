// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Syntony.TestTools.cs" company="Syntony">
//   Copyright © 2012-2012 by Syntony - http://members.aon.at/hahnl - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA / Pepi</author>
// <email>hahnl@aon.at</email>
// <date>11.05.2012 13:02:29</date>
// <information solution="Syntony.Framework.CommonObjectRuntime" project="Tests" framework=".NET Framework 4.0" kind="Windows (C#)">
//   <file type =".cs" created ="28.03.2012 13:22:25" modified="11.05.2012 13:00:22">
//     C:\Users\Pepi\Documents\Syntony\Projects\SharedSource\Syntony.TestTools.cs
//   </file>
//   <lines total="214" allCommentLines="68" blankLines="29" codeLines="122" codeRatio="57,01 %" commentLines="31" documentationLines="37" netLines="185"/>
//   <language>C#</language>
//   <namespace>Syntony.Tests</namespace>
//   <class>TestTools</class>
//   <Identifiers>
//     namespaces: Syntony.Tests
//     classes: TestTools
//   </Identifiers>
// </information>
// <summary>
//   A class for useful testing tools.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Syntony.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Syntony.Framework.Annotations;
    using Syntony.Framework.Core.Reflection;
    using Syntony.Framework.Diagnostics;

    /// <summary>
    /// A class for useful testing tools.
    /// </summary>
    public static class TestTools
    {
        /// <summary>
        /// Tests the thread safety of an <see cref="Action"/>.
        /// </summary>
        /// <param name="action">The action delegate.</param>
        /// <param name="numberOfThreads">The number of threads to create.</param>
        /// <exception cref="ArgumentNullException">action is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Number of threads invalid!</exception>
        public static void TestThreadSafety([NotNull] Action action, int numberOfThreads = 2)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (numberOfThreads <= 0)
            {
                throw new ArgumentException("Number of threads invalid!");
            }

            Task[] tasks = new Task[numberOfThreads];

            for (int i = 0; i < numberOfThreads; i++)
            {
                tasks[i] = new Task(action);
                tasks[i].Start();
            }

            Thread.Sleep(0); // Suspends the current thread for a specified time. 0 indicates that this thread should be suspended to allow other waiting threads to execute.

            for (int i = 0; i < numberOfThreads; i++)
            {
                tasks[i].Wait(); // Waits for the Task to complete execution
            }

            ForceGarbageCollector();
        }

        /// <summary>
        /// Simples the performance diagram.
        /// </summary>
        /// <param name="action">The action delegate.</param>
        /// <param name="iterations">The number of loops running the <paramref name="action"/> delegate for each thread.</param>
        /// <param name="numberOfThreads">The number of threads to create.</param>
        /// <param name="runActionOnceForInitialization">if set to <see langword="true"/> <paramref name="action"/> is called once before starting the iterations.</param>
        /// <exception cref="ArgumentNullException">action is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Number of threads invalid!</exception>
        public static void SimplePerformanceDiagram([NotNull] Action action, long iterations, int numberOfThreads = 1, bool runActionOnceForInitialization = false)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (numberOfThreads <= 0)
            {
                throw new ArgumentException("Number of threads invalid!");
            }

            double[] results = new double[numberOfThreads];
            double initialization = 0.0;
            if (runActionOnceForInitialization)
            {
                initialization = Profiler.DefaultProfiler.Start(action);
            }

            Profiler[] profilers = new Profiler[numberOfThreads];
            Task<double>[] tasks = new Task<double>[numberOfThreads];

            for (int i = 0; i < numberOfThreads; i++)
            {
                int i1 = i;
                profilers[i1] = new Profiler();
                tasks[i] = Task<double>.Factory.StartNew(() => profilers[i1].Start(action, iterations));
            }

            Thread.Sleep(0); // Suspends the current thread for a specified time. 0 indicates that this thread should be suspended to allow other waiting threads to execute.

            for (int i = 0; i < numberOfThreads; i++)
            {
                tasks[i].Wait(); // Waits for the Task to complete execution
            }

            for (int i = 0; i < numberOfThreads; i++)
            {
                results[i] = tasks[i].Result; // store results
            }

            double min = results.Min();
            double diff = 50 / (results.Max() - min);

            Trace.WriteLine(new string('*', 80));
            Trace.WriteLine(string.Format("Simple performance diagram for {0}", Reflect.NameOfAction(action)));
            Trace.WriteLine(new string('*', 80));
            if (runActionOnceForInitialization)
            {
                Trace.WriteLine(string.Format("Initialization for {0} = {1:#0.000000} seconds", Reflect.NameOfAction(action), initialization));
                Trace.WriteLine(new string('*', 80));
            }

            for (int i = 0; i < results.Length; i++)
            {
                Trace.WriteLine(string.Format("{0:0##} | {1} {2:#0.000000} seconds", i + 1, new string('*', (int)(5 + (diff * (results[i] - min)))), results[i]));
            }

            Trace.WriteLine(string.Format("{0} | {1} {2:#0.000000} seconds", "Avg", new string('*', (int)(5 + (diff * (results.Average() - min)))), results.Average()));
            Trace.WriteLine(new string('*', 80));

            ForceGarbageCollector();
        }

        /// <summary>
        /// Find all public types inherited from a base type (also interfaces) including the base type if inside <paramref name="assembly"/> .
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="baseType">Base type or interface.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of all found types.</returns>
        /// <remarks>This will also allow you to specify an interface and find all the types which implement it.</remarks>
        /// <exception cref="ArgumentNullException">assembly</exception>
        [NotNull]
        public static IEnumerable<Type> GetAllDerivedTypes([NotNull] Assembly assembly, [NotNull] Type baseType)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            if (baseType == null)
            {
                throw new ArgumentNullException("baseType");
            }

            // If the IsSubclassOf is the converse of IsAssignableFrom.That is, if t1.IsSubclassOf(t2) is true, then t2.IsAssignableFrom(t1) is also true.
            return assembly.GetTypes().Where(type => baseType.IsAssignableFrom(type) && type.IsPublic);
        }

        /// <summary>
        /// Find all public types inherited from a base class (without interfaces) excluding the base type if inside <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="baseType">Base class.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of all found types.</returns>
        /// <exception cref="ArgumentNullException">assembly</exception>
        [NotNull]
        public static IEnumerable<Type> GetAllSubclassesOf([NotNull] Assembly assembly, [NotNull] Type baseType)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            if (baseType == null)
            {
                throw new ArgumentNullException("baseType");
            }

            // If the IsSubclassOf is the converse of IsAssignableFrom.That is, if t1.IsSubclassOf(t2) is true, then t2.IsAssignableFrom(t1) is also true.
            return assembly.GetTypes().Where(type => type.IsSubclassOf(baseType) && type.IsPublic);
        }

        /// <summary>
        /// Forces an immediate garbage collection of all generations.
        /// </summary>
        private static void ForceGarbageCollector()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
