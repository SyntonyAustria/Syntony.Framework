// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensions.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>14.12.2015 15:26:00</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="14.12.2015 10:30:22" modified="14.12.2015 15:26:00" lastAccess="14.12.2015 15:26:00">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Source\Core\Extensions\ObjectExtensions.cs
//     </file>
//     <lines total="195" netLines="174" codeLines="87" allCommentLines="88" commentLines="23" documentationLines="65" blankLines="21" codeRatio="44.62 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework.Core.Extensions</namespace>
//         <class>ObjectExtensions</class>
//     </identifiers>
// </information>
// <summary>
//     The object extensions.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Reflection;
using JetBrains.Annotations;

namespace Syntony.Framework.Core.Extensions
{
    /// <summary>The object extensions.</summary>
    /// <devdoc>At extension methods also have a look at http://zextensionmethods.codeplex.com/ </devdoc>
    public static class ObjectExtensions
    {
        /// <summary>The runtime type</summary>
        /// <devdoc>System.RuntimeType is internal.</devdoc>
        private static readonly Type RuntimeType = Type.GetType("System.RuntimeType");

        /// <summary>Determines whether the specified object has some method implemented.</summary>
        /// <param name="instance">The object to check.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns><see langword="true"/> if the specified <paramref name="methodName"/> is implemented by <paramref name="instance"/>; otherwise <see langword="false"/>.</returns>
        [ContractAnnotation("instance:null => false; methodName:null => false")]
        public static bool HasMethod([CanBeNull] this object instance, [CanBeNull] string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
            {
                return false;
            }

            Type type = instance?.GetTypeSafe();
            return type.HasMethod(methodName);
        }

        /// <summary>Gets the string representation of the current object in a safe manner using <see cref="Constants.NullString"/> for <see langword1="null"/> objects.</summary>
        /// <param name="instance">The instance to convert into a string.</param>
        /// <returns>A string representation of the current object.</returns>
        /// <remarks>If <paramref name="instance"/> is <see langword="null"/> the method returns <see cref="Constants.NullString"/>; otherwise <see cref="object.ToString()"/> is used.</remarks>
        [NotNull]
        public static string ToStringSafe([CanBeNull] this object instance)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return instance?.ToString() ?? Constants.NullString;
        }

        /// <summary>Gets the <see cref="Type"/> string representation of the current object in a safe manner using <see cref="Constants.NullString"/> for <see langword1="null"/> objects.</summary>
        /// <param name="instance">The instance to convert into a type string.</param>
        /// <returns>A <see cref="Type"/> string representation of the current object.</returns>
        /// <remarks>If <paramref name="instance"/> is <see langword="null"/> the method returns <see cref="Constants.NullString"/>; otherwise <see cref="object.ToString()"/> is used.</remarks>
        /// <devdoc>
        /// System.RuntimeType is a concrete class that derives from the abstract base class System.Type. Since System.RuntimeType is not public, you will typically encounter instances of it as System.Type.
        /// 
        /// Confusion can arise when you are trying to get the type of an object and mistakenly call GetType() on another
        ///     object representing the first object's type, rather than just using that object directly. Then Type.ToString()
        ///     will return "System.RuntimeType" when the object it is called on is representing a Type:
        /// <example>
        /// <b>Test.ObjectExtensions.ToTypeStringSafe</b>
        /// <code><![CDATA[
        /// string str = string.Empty;
        /// Type strType = str.GetType();
        /// Type strTypeType = strType.GetType();
        /// strType.ToString();     // returns "System.String"
        /// strTypeType.ToString(); // returns "System.RuntimeType"
        /// ]]></code></example>
        /// </devdoc>
        [NotNull]
        public static string ToTypeStringSafe([CanBeNull] this object instance)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return instance.GetTypeSafe()?.ToString() ?? Constants.NullString;
        }

        /// <summary>Gets the <see cref="Type"/> of the current object in a safe manner trying to ignore possible mistaken call to <see cref="object.GetType()"/>.</summary>
        /// <param name="instance">The instance to get type string.</param>
        /// <returns>A <see cref="Type"/> object which represent <paramref name="instance"/> instance or <see langword="null"/> if <paramref name="instance"/> is <see langword="null"/>.</returns>
        [ContractAnnotation("null => null; notnull => notnull")]
        [CanBeNull]
        public static Type GetTypeSafe([CanBeNull] this object instance)
        {
            Type type = instance?.GetType(); // this could be a possible mistaken call to GetType()
            if (type == RuntimeType)
            {
                Type t = instance as Type;
                if (t != null)
                {
                    type = t;
                }
            }

            return type;
        }

        /// <summary>Gets all readable properties.</summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="instance">Object to get all readable properties (get accessor).</param>
        /// <returns>An enumerator of all readable properties from <typeparamref name="T" />.</returns>
        /// <remarks><see cref="Constants.DefaultBindingFlags"/> is used.</remarks>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableProperties<T>([CanBeNull] this T instance)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return instance.GetAllReadableProperties(Constants.DefaultBindingFlags);
        }

        /// <summary>Gets all readable properties.</summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="instance">Object to get all readable properties (get accessor).</param>
        /// <param name="bindings">The binding flags.</param>
        /// <returns>An enumerator of all readable properties from <typeparamref name="T" />.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "BindingFlags is a well known name")]
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableProperties<T>([CanBeNull] this T instance, BindingFlags bindings)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return instance == null ? new List<PropertyInfo>() : instance.GetTypeSafe().GetAllReadableProperties(bindings);
        }

        /// <summary>Gets all writable properties.</summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="instance">Object to get all writable properties (set accessor).</param>
        /// <returns>An enumerator of all writable properties from <typeparamref name="T" />.</returns>
        /// <remarks><see cref="Constants.DefaultBindingFlags"/> is used.</remarks>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllWritableProperties<T>([CanBeNull] this T instance)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return instance.GetAllWritableProperties(Constants.DefaultBindingFlags);
        }

        /// <summary>Gets all writable properties.</summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="instance">Object to get all writable properties (set accessor).</param>
        /// <param name="bindings">The binding flags.</param>
        /// <returns>An enumerator of all writable properties from <typeparamref name="T" />.</returns>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllWritableProperties<T>([CanBeNull] this T instance, BindingFlags bindings)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return instance == null ? new List<PropertyInfo>() : instance.GetTypeSafe().GetAllWritableProperties(bindings);
        }

        /// <summary>Gets all properties that are readable and writable (all properties that have a getter and a setter).</summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="instance">Object to get all writable properties (set accessor).</param>
        /// <returns>An enumerator of all writable properties from <typeparamref name="T" />.</returns>
        /// <remarks><see cref="Constants.DefaultBindingFlags"/> is used.</remarks>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableAndWritableProperties<T>([CanBeNull] this T instance)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return instance.GetAllReadableAndWritableProperties(Constants.DefaultBindingFlags);
        }

        /// <summary>Gets all properties that are readable and writable (all properties that have a getter and a setter).</summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="instance">Object to get all writable properties (set accessor).</param>
        /// <param name="bindings">The binding flags.</param>
        /// <returns>An enumerator of all writable properties from <typeparamref name="T" />.</returns>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableAndWritableProperties<T>([CanBeNull] this T instance, BindingFlags bindings)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return instance == null ? new List<PropertyInfo>() : instance.GetTypeSafe().GetAllReadableAndWritableProperties(bindings);
        }
    }
}