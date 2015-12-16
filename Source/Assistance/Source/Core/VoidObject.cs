// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="VoidObject.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>14.12.2015 16:05:04</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="10.12.2015 17:06:18" modified="14.12.2015 16:05:04" lastAccess="14.12.2015 16:05:04">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Source\Core\VoidObject.cs
//     </file>
//     <lines total="179" netLines="163" codeLines="94" allCommentLines="69" commentLines="28" documentationLines="41" blankLines="16" codeRatio="52.51 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework.Core</namespace>
//         <class>VoidObject</class>
//         <class>VoidResult</class>
//     </identifiers>
// </information>
// <summary>
//     Represents a type with no value - alternative to C# void in situations where void can't be used.
// </summary>
// <workItems>
//     <TODO>implement ILogger and call: Logger.LogTrace(stringBuilder.ToString());</TODO>
// </workItems>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Syntony.Framework.Core.Extensions;

namespace Syntony.Framework.Core
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    /// <summary>Represents a type with no value - alternative to C# void in situations where void can't be used.</summary>
    /// <seealso cref="System.IEquatable{VoidObject}" />
    /// <remarks>Represents a type with a single value. This type is often used to denote the successful completion of a void-returning method (C#) or a Sub procedure (Visual Basic).</remarks>
    [Serializable]
    public class VoidObject : IEquatable<VoidObject>
    {
        /// <summary>The static <see cref="VoidObject" /> object.</summary>
        private static readonly VoidObject DefaultVoidObject = new VoidObject();

        /// <summary>Prevents a default instance of the <see cref="VoidObject" /> struct from being created.</summary>
        private VoidObject()
        {
        }

        /// <summary>Gets a static <see cref="VoidObject" /> instance.</summary>
        /// <value>The static <see cref="VoidObject" /> instance.</value>
        public static VoidObject Default => DefaultVoidObject;

        /// <summary>Gets a static <see langword="null" /> instance.</summary>
        /// <value>The static <see langword="null" /> instance.</value>
        [CanBeNull]
        public static object Null
        {
            get
            {
                Contract.Ensures(Contract.Result<object>() == null);
                return null;
            }
        }

        /// <summary>Gets a static empty object array (Constants.EmptyArray).</summary>
        /// <value>The empty.</value>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "No performance problem. OK here!")]
        [NotNull]
        public static object[] EmptyObjects => Constants.EmptyObjects;

        /// <summary>Determines whether the two specified VoidObject values are equal. Because VoidObject has a single value, this always returns <see langword="true"/>.</summary>
        /// <param name="first">The first VoidObject value to compare.</param>
        /// <param name="second">The second VoidObject value to compare.</param>
        /// <returns>Because VoidObject has a single value, this always returns true.</returns>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "first", Justification = "Parameter required for operator overloading.")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "second", Justification = "Parameter required for operator overloading.")]
        public static bool operator ==(VoidObject first, VoidObject second)
        {
            return true;
        }

        /// <summary>Determines whether the two specified VoidObject values are not equal. Because VoidObject has a single value, this always returns <see langword="false"/>.</summary>
        /// <param name="first">The first VoidObject value to compare.</param>
        /// <param name="second">The second VoidObject value to compare.</param>
        /// <returns>Because VoidObject has a single value, this always returns false.</returns>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "first", Justification = "Parameter required for operator overloading.")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "second", Justification = "Parameter required for operator overloading.")]
        public static bool operator !=(VoidObject first, VoidObject second)
        {
            return false;
        }

        /// <summary>No operation.</summary>
        /// <remarks>Meaningful for empty catch clause to remove ReSharper warnings.</remarks>
        [Conditional("DEBUG")]
        [Conditional("SYNTONY_CODE_ANALYSIS")]
        public static void Nop()
        {
        }

        /// <summary>No operation.</summary>
        /// <param name="value">A value that is never used.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <remarks>Meaningful for empty catch clause to remove ReSharper warnings and log the exception in DEBUG mode.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "what else could we do?")]
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "That's C#")]
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Code Contracts / ReSharper annotations")]
        [Conditional("DEBUG"), Conditional("SYNTONY_CODE_ANALYSIS")]
        public static void Nop([CanBeNull] object value, [NotNull, CallerMemberName] string memberName = Constants.EmptyString, [NotNull, CallerFilePath] string sourceFilePath = Constants.EmptyString, [CallerLineNumber] int sourceLineNumber = 0)
        {
            Contract.Requires(memberName != null);
            Contract.Requires(sourceFilePath != null);

            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Exception at: member name '{0}' - source file path {1}:line {2}.", memberName, sourceFilePath, sourceLineNumber);
                stringBuilder.AppendLine();
                stringBuilder.Append("Value: '");
                stringBuilder.Append(value.ToStringSafe());
                stringBuilder.AppendLine("'");
                stringBuilder.Append("Type:  '");
                stringBuilder.Append(value.ToTypeStringSafe());
                stringBuilder.AppendLine("'");
                try
                {
                    // TODO: implement ILogger and call: Logger.LogTrace(stringBuilder.ToString());
                    Debug.WriteLine(stringBuilder.ToString());
                }
                catch (Exception)
                {
                    Nop();
                }
            }
            catch (Exception)
            {
                Nop();
            }
        }
        /// <summary>Determines whether the specified VoidObject values is equal to the current VoidObject. Because VoidObject has a single value, this always returns true.</summary>
        /// <param name="other">An object to compare to the current VoidObject value.</param>
        /// <returns>Because VoidObject has a single value, this always returns true.</returns>
        public bool Equals(VoidObject other) => true;

        /// <summary>Determines whether the specified System.Object is equal to the current VoidObject.</summary>
        /// <param name="obj">The System.Object to compare with the current VoidObject.</param>
        /// <returns><see langword="true" /> if the specified System.Object is a VoidObject value; otherwise, <see langword="false" />.</returns>
        public override bool Equals([CanBeNull] object obj) => obj is VoidObject;

        /// <summary>Returns the hash code for the current <see cref="VoidObject"/> value.</summary>
        /// <returns>A hash code for the current <see cref="VoidObject"/> value.</returns>
        public override int GetHashCode() => 0;

        /// <summary>Returns a string representation of the current <see cref="VoidObject"/> value.</summary>
        /// <returns>String representation of the current <see cref="VoidObject"/> value.</returns>
        public override string ToString() => Constants.VoidStringRepresentation;

        /// <summary>
        /// This class is used as the task type for instances of <see cref="TaskCompletionSource{TResult}" /> intended to represent a <see cref="Task" /> which is not a <see cref="Task{TResult}" />. 
        /// Since this type is not externally visible, users will not be able to cast the task to a <see cref="Task" />.
        /// </summary>
        // ReSharper disable once ConvertToStaticClass
        internal sealed class VoidResult
        {
            /// <summary>Prevents a default instance of the <see cref="VoidResult" /> class from being created.</summary>
            private VoidResult()
            {
            }
        }
    }
}