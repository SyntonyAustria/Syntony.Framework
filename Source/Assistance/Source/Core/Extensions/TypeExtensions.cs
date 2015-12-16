// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>14.12.2015 13:40:07</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="14.12.2015 13:08:21" modified="14.12.2015 13:40:07" lastAccess="14.12.2015 13:40:07">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Source\Core\Extensions\TypeExtensions.cs
//     </file>
//     <lines total="122" netLines="108" codeLines="56" allCommentLines="52" commentLines="22" documentationLines="30" blankLines="14" codeRatio="45.90 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework.Core.Extensions</namespace>
//         <class>TypeExtensions</class>
//     </identifiers>
// </information>
// <summary>
//     Extensions to help working with types.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Syntony.Framework.Core.Extensions
{
    /// <summary>Extensions to help working with types.</summary>
    /// <devdoc>At extension methods also have a look at http://zextensionmethods.codeplex.com/ </devdoc>
    public static class TypeExtensions
    {
        /// <summary>Determines whether the specified type has method implemented. Searches for the public method with the specified name.</summary>
        /// <param name="type">The type to check.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns><see langword="true"/> if the specified <paramref name="methodName"/> is implemented by <paramref name="type"/>; otherwise <see langword="false"/>.</returns>
        [ContractAnnotation("type:null => false; methodName:null => false")]
        public static bool HasMethod([CanBeNull]this Type type, [CanBeNull]string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
            {
                return false;
            }

            try
            {
                return type?.GetMethod(methodName) != null;
            }
            catch (AmbiguousMatchException)
            {
                return true; // More than one method is found with the specified name
            }
        }

        /// <summary>Gets all readable properties.</summary>
        /// <param name="type">Type to get all readable properties (get accessor).</param>
        /// <returns>An enumerator of all readable properties from <paramref name="type" />.</returns>
        /// <remarks><see cref="Constants.DefaultBindingFlags"/> is used.</remarks>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableProperties([CanBeNull] this Type type)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return type.GetAllReadableProperties(Constants.DefaultBindingFlags);
        }

        /// <summary>Gets all readable properties.</summary>
        /// <param name="type">Type to get all readable properties (get accessor).</param>
        /// <param name="bindings">The binding flags.</param>
        /// <returns>An enumerator of all readable properties from <paramref name="type" />.</returns>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableProperties([CanBeNull] this Type type, BindingFlags bindings)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return type == null ? new List<PropertyInfo>() : from t in type.GetProperties(bindings) where t.CanRead select t;
        }

        /// <summary>Gets all writable properties.</summary>
        /// <param name="type">Type to get all writable properties (set accessor).</param>
        /// <returns>An enumerator of all writable properties from <paramref name="type" />.</returns>
        /// <remarks><see cref="Constants.DefaultBindingFlags"/> is used.</remarks>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllWritableProperties([CanBeNull] this Type type)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return type.GetAllWritableProperties(Constants.DefaultBindingFlags);
        }

        /// <summary>Gets all writable properties.</summary>
        /// <param name="type">Type to get all writable properties (set accessor).</param>
        /// <param name="bindings">The binding flags.</param>
        /// <returns>An enumerator of all writable properties from <paramref name="type" />.</returns>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllWritableProperties([CanBeNull] this Type type, BindingFlags bindings)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return type == null ? new List<PropertyInfo>() : from t in type.GetProperties(bindings) where t.CanWrite select t;
        }

        /// <summary>Gets all properties that are readable and writable (all properties that have a getter and a setter).</summary>
        /// <param name="type">Type to get all readable and writable properties (get and set accessor).</param>
        /// <returns>An enumerator of all readable and writable properties from <paramref name="type" />.</returns>
        /// <remarks><see cref="Constants.DefaultBindingFlags"/> is used.</remarks>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableAndWritableProperties([CanBeNull] this Type type)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return type.GetAllReadableAndWritableProperties(Constants.DefaultBindingFlags);
        }

        /// <summary>Gets all properties that are readable and writable (all properties that have a getter and a setter).</summary>
        /// <param name="type">Type to get all readable and writable properties (get and set accessor).</param>
        /// <param name="bindings">The binding flags.</param>
        /// <returns>An enumerator of all readable and writable properties from <paramref name="type" />.</returns>
        [NotNull]
        public static IEnumerable<PropertyInfo> GetAllReadableAndWritableProperties([CanBeNull] this Type type, BindingFlags bindings)
        {
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            return type == null ? new List<PropertyInfo>() : from t in type.GetProperties(bindings) where t.CanRead && t.CanWrite select t;
        }
    }
}