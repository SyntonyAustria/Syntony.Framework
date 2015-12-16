// ---------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigAdapter.cs" company="Syntony">
//     Copyright © 2015-2015 by Syntony - http://members.aon.at/hahnl - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - Pepi</author>
// <email>hahnl@aon.at</email>
// <date>01.04.2015 10:26:27</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance" framework=".NET Framework unknown
//     value: 262405" kind="Windows (C#)">
//     <file type=".cs" created="01.04.2015 10:26:18" modified="01.04.2015 10:26:27" lastAccess="01.04.2015 10:26:27">
//         D:\Syntony\Projects\Framework\Main\Source\Assistance\Source\Configuration\IConfigAdapter.cs
//     </file>
//     <lines total="71" allCommentLines="38" blankLines="5"
//         codeLines="28" codeRatio="39.44 %" commentLines="28"
//         documentationLines="10" netLines="66"/>
//     <language>C#</language>
//     <namespace>Syntony.Framework.Configuration</namespace>
//     <class>ConfigAdapterContract</class>
//     <identifiers>
//         <namespace>Syntony.Framework.Configuration</namespace>
//         <class>ConfigAdapterContract</class>
//         <interface>IConfigAdapter</interface>
//     </identifiers>
// </information>
// <summary>
//     A writable configuration source.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace Syntony.Framework.Configuration
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using Syntony.Framework.Core;

    /// <summary>A writable configuration source.</summary>
    [ContractClass(typeof(ConfigAdapterContract))]
    public interface IConfigAdapter
    {
        /// <summary>Access a config setting.</summary>
        /// <value>The <see cref="System.String"/>.</value>
        /// <param name="name">Name of the setting.</param>
        /// <returns>Value if found; otherwise <see langword="null" />.</returns>
        string this[string name] { get; set; }
    }

    /// <summary>Contracts for <see cref="IConfigAdapter" />.</summary>
    [ExcludeFromCodeCoverage, ContractClassFor(typeof(IConfigAdapter))]
    internal abstract class ConfigAdapterContract : IConfigAdapter
    {
        /// <summary>Gets or sets the <see cref="System.String"/> with the specified name.</summary>
        /// <value>The <see cref="System.String"/>.</value>
        /// <param name="name">The name.</param>
        /// <returns>Value if found; otherwise <see langword="null" />.</returns>
        string IConfigAdapter.this[string name]
        {
            get
            {
                Contract.Requires(!string.IsNullOrEmpty(name));
                return string.Empty;
            }

            set
            {
                Contract.Requires(!string.IsNullOrEmpty(name));

                VoidObject.Nop(value);
            }
        }
    }
}