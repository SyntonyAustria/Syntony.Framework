// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>10.12.2015 17:14:53</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="10.12.2015 16:47:01" modified="10.12.2015 17:14:53" lastAccess="10.12.2015 17:14:53">
//         E:\Syntony\Projects\Framework\Main\Source\Assistance\Source\Framework\Constants.cs
//     </file>
//     <lines total="333" netLines="260" codeLines="129" allCommentLines="134" commentLines="46" documentationLines="88" blankLines="73" codeRatio="38.74 %"/>
//     <language>C#</language>
//     <identifiers>
//         <namespace>Syntony.Framework</namespace>
//         <class>Constants</class>
//     </identifiers>
// </information>
// <summary>
//     Various useful global constants.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
namespace Syntony.Framework
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Text;
    using System.Threading;

    using JetBrains.Annotations;

    using Syntony.Framework.Core;

    /// <summary>Various useful global constants.</summary>
    public static class Constants
    {
        /// <summary>Syntony.SyntonyFramework public key.</summary>
        /// <remarks>
        /// Once an assembly has been signed you can extract the public key token using the ‘sn’ .NET utility.<br />
        /// This string represents the public key extracted by sn.exe -Tp Syntony.SyntonyFramework.dll
        /// <para>
        /// With C# code this string can be reproduced like:<br /><![CDATA[
        /// AssemblyName assemblyName = Assembly.GetExecutingAssembly(typeof(SyntonyFramework)).GetName();
        /// byte[] key = assemblyName.GetPublicKey();
        /// var stringBuilder = new StringBuilder();
        /// foreach (byte b in key)
        /// {
        /// stringBuilder.AppendFormat("{0:X2}", b);
        /// }
        /// return stringBuilder.ToString();
        /// ]]>.
        /// </para>
        /// .
        /// </remarks>
        [NotNull]
        public const string SyntonyPublicKey = "0024000004800000940000000602000000240000525341310004000001000100a92205058259cde2bb2d95f4332966b7790460f1a669a945057f2624ded894c558838528a07ac7193036ebe3b0d6a3a45864d5894d73897c2fc1a14fcde99aa82275475f6baa1fe7593f9168b8e0a8aefcc7ca66dd9c77c94b6d61585250a151d9b6521b5bd4ef331fd46870216caecc3732ebaeddd8b1b0dc61e57afd8ca8be";

        /// <summary>Syntony.SyntonyFramework public key token.</summary>
        [NotNull]
        public const string SyntonyPublicKeyToken = "b57f286edd2a0369";

        /// <summary>Microsoft / ECMA public key.</summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ecma", Justification = "okay here")]
        [NotNull]
        public const string EcmaPublicKey = "00000000000000000400000000000000";

        /// <summary>Microsoft / ECMA public key token.</summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ecma", Justification = "okay here")]
        [NotNull]
        public const string EcmaPublicKeyToken = "b77a5c561934e089";

        /// <summary>Microsoft public key.</summary>
        [NotNull]
        public const string MicrosoftPublicKey = "002400000480000094000000060200000024000052534131000400000100010007d1fa57c4aed9f0a32e84aa0faefd0de9e8fd6aec8f87fb03766c834c99921eb23be79ad9d5dcc1dd9ad236132102900b723cf980957fc4e177108fc607774f29e8320e92ea05ece4e821c0a5efe8f1645c4c0c93c1ab99285d622caa652c1dfad63d745d6f2de5f17e5eaf0fc4963d261c8a12436518206dc093344d5ad293";

        /// <summary>Microsoft public key token.</summary>
        [NotNull]
        public const string MicrosoftPublicKeyToken = "b03f5f7f11d50a3a";

        /// <summary>Microsoft shared library public key.</summary>
        [NotNull]
        public const string SharedLibPublicKey = "0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9";

        /// <summary>Microsoft shared library public key token.</summary>
        [NotNull]
        public const string SharedLibPublicKeyToken = "31bf3856ad364e35";

        /// <summary>The alphabet with lower case letters: "abcdefghijklmnopqrstuvwxyz".</summary>
        [NotNull]
        public const string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>The alphabet with capital letters: "ABCDEFGHIJKLMNOPQRSTUVWXYZ".</summary>
        [NotNull]
        public const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>A string of all binary characters: "01".</summary>
        [NotNull]
        public const string BinaryCharacters = "01";

        /// <summary>A string of all (decimal) number characters: "0123456789".</summary>
        [NotNull]
        public const string NumericCharacters = BinaryCharacters + "23456789";

        /// <summary>A string of all hexadecimal characters: "0123456789ABCDEF".</summary>
        [NotNull]
        public const string HexCharacters = NumericCharacters + "ABCDEF";

        /// <summary>A string of special characters: ",.;:?!/@#$%^)=+*-_{}[]|~".</summary>
        [NotNull]
        public const string SpecialCharacters = ",.;:?!/@#$%^&()=+*-_{}[]<>|~";

        /// <summary>A string of special characters for passwords: "*$-+?_&amp;=!%{}/".</summary>
        [NotNull]
        public const string PasswordSpecialCharacters = "*$-+?_&=!%{}/";

        /// <summary>A "__null__" string for the representation of a <see langword="null" /> instance.</summary>
        [NotNull]
        public const string NullString = "__null__"; // "<null>";

        /// <summary>A string for the representation of an empty collection / array: "&lt;empty&gt;".</summary>
        [NotNull]
        public const string EmptyCollectionString = "<empty>";

        /// <summary>A "&lt;null&gt;" string for the representation of a <see langword="null" /> instance.</summary>
        [NotNull]
        public const string NullXmlString = "<null/>";

        /// <summary>The null XML value. "xsi:nil=\"true\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"".</summary>
        [NotNull]
        public const string NullXmlValue = "xsi:nil=\"true\"";

        /// <summary>The default object name representing a <see langword="null" /> instance.</summary>
        [NotNull]
        public const string DefaultNullValueName = "NullInstance";

        /// <summary>The "&lt;unknown&gt;" string to represent unknown states.</summary>
        [NotNull]
        public const string Unknown = "<unknown>";

        /// <summary>The "&lt;unknown&gt;" string to represent unknown states.</summary>
        [NotNull]
        public const string UnknownXmlValue = "UNKNOWN";

        /// <summary>The EmptyObjects constant holds the empty string value.</summary>
        [NotNull]
        public const string EmptyString = "";

        /// <summary>A single space as a string.</summary>
        [NotNull]
        public const string SpaceString = " ";

        /// <summary>A single space as a character '.'.</summary>
        public const char SpaceCharacter = ' ';

        /// <summary>A single dot as a string ".".</summary>
        [NotNull]
        public const string DotString = ".";

        /// <summary>A double dot as a string "..".</summary>
        [NotNull]
        public const string DoubleDotString = "..";

        /// <summary>A single dot as a character.</summary>
        public const char DotCharacter = '.';

        /// <summary>The string representation of the Boolean value <see langword="true" />: "true".</summary>
        [NotNull]
        public const string True = "true";

        /// <summary>The string representation of the Boolean value <see langword="false" />: "false".</summary>
        [NotNull]
        public const string False = "false";

        /// <summary>The not available string: "N/A".</summary>
        public const string NotAvailable = "N/A";

        /// <summary>Default <see cref="StringBuilder" /> capacity (512 characters).</summary>
        /// <remarks>The default <see cref="StringBuilder" /> capacity new StringBuilder() is 16 characters.</remarks>
        public const int DefaultStringBuilderCapacity = 512;

        /// <summary>Default indentation size for layouts. The default value is 4.</summary>
        public const int DefaultIndentation = 4;

        /// <summary>The default polling delay in milliseconds. Default value is: 15000 (fifteen minutes).</summary>
        public const int DefaultPollDelayInMilliseconds = 15000;

        /// <summary>The default time out for processing (like file watching). The default value is 500 milliseconds.</summary>
        public const int DefaultTimeout = 500;

        /// <summary>The default time out for online operations. The default value is 5000 milliseconds.</summary>
        public const int DefaultOnlineTimeout = 5000;

        /// <summary>The default time out for finishing the logger. The default value is 10000 milliseconds.</summary>
        public const int DefaultLoggerTimeout = 10000;

        /// <summary>The size of a byte in bits (of course 8 bits, but general definition).</summary>
        public const int BitsPerByte = sizeof(byte) * 8;

        /// <summary>The name Syntony: "Syntony".</summary>
        [NotNull]
        public const string SyntonyName = "Syntony";

        /// <summary>The name of the application: "Framework".</summary>
        [NotNull]
        public const string Framework = "Framework";

        /// <summary>The default config file extension.</summary>
        [NotNull]
        public const string ConfigFileExtension = "config";

        /// <summary>The default <see cref="BindingFlags" />. BindingFlags.Instance | BindingFlags.Public.</summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "BindingFlags is a.Net class.")]
        public const BindingFlags PublicInstanceBindingFlags = BindingFlags.Instance | BindingFlags.Public;

        /// <summary>The default <see cref="BindingFlags" />. BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static.</summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "BindingFlags is a.Net class.")]
        public const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;

        /// <summary>The default <see cref="BindingFlags" />. BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase.</summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "BindingFlags is a.Net class.")]
        public const BindingFlags DefaultIgnoreCaseBindingFlags = DefaultBindingFlags | BindingFlags.IgnoreCase;

        /// <summary>The default nonpublic <see cref="BindingFlags" />. BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic.</summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "BindingFlags is a.Net class.")]
        public const BindingFlags DefaultNonpublicBindingFlags = DefaultBindingFlags | BindingFlags.NonPublic;

        /// <summary>The default nonpublic <see cref="BindingFlags" />. BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase.</summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "BindingFlags is a.Net class.")]
        public const BindingFlags DefaultNonpublicIgnoreCaseBindingFlags = DefaultNonpublicBindingFlags | BindingFlags.IgnoreCase;

        /// <summary>A simple "magic" number with value 0x9e3779b97f4a7c13 (11400714819323198483).</summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "okay here")]
        internal const ulong GoldenRatioLong = 0x9e3779b97f4a7c13; // 11400714819323198483

        /// <summary>A simple "magic" number with value 0x85ebca6b (2246822507).</summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "okay here")]
        internal const uint GoldenRatioInt = 0x85ebca6b; // 2246822507

        /// <summary>The exception dispatch information key for adding an <see cref="ExceptionDispatchInfo" /> object to an <see cref="Exception" />.</summary>
        [NotNull]
        internal const string ExceptionDispatchInfo = "ExceptionDispatchInfo";

        /// <summary>The default exception handler policy name ("DefaultExceptionHandlerPolicy").</summary>
        [NotNull]
        internal const string DefaultExceptionPolicyName = "DefaultExceptionHandlerPolicy";

        /// <summary>The default Message if it cannot be retrieved from a resource.</summary>
        [NotNull]
        internal const string InvalidResourceMessage = "Invalid resource for '{0}'.";

        /*
        /// <summary>The root name of the resource file without its extension but including any fully qualified namespace name: "Syntony.Framework.Resources.Resources".</summary>
        /// <devodc>Default location of resource set by <see cref="ResourceLocationAttribute" /> in AssemblyInfo.cs.</devodc>
        [NotNull]
        internal const string SyntonyFrameworkStringResources = SyntonyEnvironment.SyntonyFrameworkDefaultNamespace + ".Resources.Resources";
        */

        /// <summary>The full name of the code contract exception name.</summary>
        internal const string ContractExceptionName = "System.Diagnostics.Contracts.__ContractsRuntime+ContractException";
        /*
        /// <summary>The name of the default Author.</summary>
        /// <remarks>The most generic author. <seealso cref="AuthorAttribute" /></remarks>
        [NotNull]
        internal const string DefaultAuthor = "Ing. Josef Hahnl, MBA";
        */

        /// <summary>The object of type with value message.</summary>
        internal const string ObjectOfTypeWithValue = "Object of Type '{0}' with value '{1}'.";

        /// <summary>The <see cref="VoidObject"/> string representation.</summary>
        [NotNull]
        internal const string VoidStringRepresentation = "()";

        /// <summary>The gigabyte divisor.</summary>
        internal const long GigabyteDivisor = 0x40000000L;

        /// <summary>The gigabyte shift.</summary>
        internal const int GigabyteShiftDivisor = 30;

        /// <summary>The kilobyte divisor.</summary>
        internal const long KilobyteDivisor = 0x400L;

        /// <summary>The kilobyte shift.</summary>
        internal const int KilobyteShiftDivisor = 10;

        /// <summary>The megabyte divisor.</summary>
        internal const long MegabyteDivisor = 0x100000L;

        /// <summary>The megabyte shift.</summary>
        internal const int MegabyteShiftDivisor = 20;

        /// <summary>The terabyte divisor.</summary>
        internal const long TerabyteDivisor = 0x10000000000L;

        /// <summary>The terabyte shift.</summary>
        internal const int TerabyteShiftDivisor = 40;

        /// <summary>The default time out for online operations. The default value is 500 milliseconds more than <see cref="DefaultOnlineTimeout"/>.</summary>
        internal const int DefaultOnlineTimeoutForTests = DefaultOnlineTimeout + 500;

        /// <summary>EmptyObjects is used to indicate that we are looking for something without any info.</summary>
        [NotNull]
        internal static readonly object[] EmptyObjects = new object[0];

        /// <summary>A zero-length Type array - not provided by System.Type for all CLR versions we support. EmptyTypes is used to indicate that we are looking for something without any parameters.</summary>
        [NotNull]
        internal static readonly Type[] EmptyTypes = Type.EmptyTypes;

        /// <summary>A reference to not set object.</summary>
        [NotNull]
        internal static readonly object NotSet = new object();

        /// <summary>The main thread identification.</summary>
        internal static readonly int MainThreadId = Thread.CurrentThread.ManagedThreadId;

        /*
        /// <summary>A standard password for default cipher operations.</summary>
        /// <devdoc>Calling this function several times with the same seed (<see cref="GoldenRatioInt"/>) the returned "random" string is equal.</devdoc>
        [NotNull]
        internal static readonly string GoldenSalt = Randomizer.GenerateCharacters(64, GoldenRatioInt);

        /// <summary>The default salt string.</summary>
        internal static readonly string Salt = GoldenSalt.Substring(0, 13); // "&p%e$p§i!)=";
        */

        /// <summary>The fully qualified type of the Constants class.</summary>
        /// <remarks>Used by the internal methods to record the Type of an event.</remarks>
        [NotNull]
        internal static readonly Type DeclaringType = typeof(Constants);
    }
}
