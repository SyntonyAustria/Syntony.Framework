// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="Syntony">
//   Copyright © 2012 by Syntony - http://members.aon.at/hahnl - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA / Pepi</author>
// <email>hahnl@aon.at</email>
// <date>05.04.2012 15:53:15</date>
// <information solution="Syntony.Framework.Solution" project="Syntony.Framework.Annotations" framework=".NET Framework 4.0" kind="Windows (C#)">
//   <file type =".cs" created ="05.04.2012 14:53:09" modified="05.04.2012 15:53:15">
//     C:\Users\Pepi\Documents\Syntony\Projects\Framework\Main\Source\Framework\Source\Annotations\Properties\AssemblyInfo.cs
//   </file>
//   <lines total="85" allCommentLines="47" blankLines="16" codeLines="22" codeRatio="25,88 %" commentLines="47" documentationLines="0" netLines="69"/>
//   <language>C#</language>
//   <namespace></namespace>
//   <class></class>
//   <Identifiers>
//   </Identifiers>
// </information>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
#region FileDescription
// This file AssemblyInfo.cs is the last (close-fitting) part of the AssemblyInfo for an specific assembly.
// It will be used together with Syntony.AssemblyInfo.cs and Syntony.SyntonyFramework.AssemblyInfo.cs for attributing Syntony.SyntonyFramework.dll
// #define OLD_TARGET_FRAMEWORKVERSION if you use .NET target framework less than 4.0 (that means if you use .Net SyntonyFramework 2.0, 3.0 or 3.5)
#endregion FileDescription

#region Using Directives

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if OLD_TARGET_FRAMEWORKVERSION
using System.Security.Permissions;
#endif

#endregion

#region General information

// Defines an assembly title custom attribute for an assembly manifest.
// The assembly title is a friendly name, which can include spaces.
[assembly: AssemblyTitle("Syntony.Framework.Annotations.dll")]

// Defines a friendly default alias for an assembly manifest.
// This is a friendly default alias in cases where the assembly name is not friendly or is a GUID.
[assembly: AssemblyDefaultAlias("Syntony.Framework.Annotations.dll")]

// Provides a text description for an assembly.
// When you right-click the assembly file in Windows Explorer, this attribute appears as the Comments value on the Version tab of the file properties dialog box.
[assembly: AssemblyDescription("Syntony.Framework.Annotations.dll")]

#endregion General information

#region InternalsVisibleTo

// Specifies that all nonpublic types in an assembly are visible to another assembly.
// Use PublicKey - InternalsVisibleTo.exe (Syntony\Common Properties\Tools) to get the public key of an assembly.
[assembly: InternalsVisibleTo("Syntony.Framework.CommonObjectRuntime, PublicKey=0024000004800000940000000602000000240000525341310004000001000100A92205058259CDE2BB2D95F4332966B7790460F1A669A945057F2624DED894C558838528A07AC7193036EBE3B0D6A3A45864D5894D73897C2FC1A14FCDE99AA82275475F6BAA1FE7593F9168B8E0A8AEFCC7CA66DD9C77C94B6D61585250A151D9B6521B5BD4EF331FD46870216CAECC3732EBAEDDD8B1B0DC61E57AFD8CA8BE")]
[assembly: InternalsVisibleTo("Syntony.Framework.Core, PublicKey=0024000004800000940000000602000000240000525341310004000001000100A92205058259CDE2BB2D95F4332966B7790460F1A669A945057F2624DED894C558838528A07AC7193036EBE3B0D6A3A45864D5894D73897C2FC1A14FCDE99AA82275475F6BAA1FE7593F9168B8E0A8AEFCC7CA66DD9C77C94B6D61585250A151D9B6521B5BD4EF331FD46870216CAECC3732EBAEDDD8B1B0DC61E57AFD8CA8BE")]
#if DEBUG
// Present internals in DEBUG mode due to testing.
[assembly: InternalsVisibleTo("Syntony.Framework.Annotations.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100A92205058259CDE2BB2D95F4332966B7790460F1A669A945057F2624DED894C558838528A07AC7193036EBE3B0D6A3A45864D5894D73897C2FC1A14FCDE99AA82275475F6BAA1FE7593F9168B8E0A8AEFCC7CA66DD9C77C94B6D61585250A151D9B6521B5BD4EF331FD46870216CAECC3732EBAEDDD8B1B0DC61E57AFD8CA8BE")]
#endif

#endregion InternalsVisibleTo

#region COM

// Supplies an explicit System.Guid when an automatic GUID (Globally Unique Identifier) is undesirable.
// The string passed to the attribute must be in a format that is an acceptable constructor argument for the type Guid. 
// To avoid conflicts with the type GUID, use the long name GuidAttribute explicitly. 
// Only use an explicit GUID when a type must have a specific GUID. 
// If the attribute is omitted, a GUID is assigned automatically.
[assembly: Guid("231BB6D3-13C6-48E5-84BF-5BCFDA878801")]

#endregion COM

#region Security

#if OLD_TARGET_FRAMEWORKVERSION
    
    // Allows security actions for FileIOPermission to be applied to code using declarative security.
    // Files and directories are specified using absolute paths. When accessing files, a security check is performed when the file is created or opened. 
    // The security check is not done again unless the file is closed and reopened. 
    // Checking permissions when the file is first accessed minimizes the impact of the security check on application performance because opening a file happens only once, 
    // while reading and writing can happen multiple times.
    // The scope of the declaration that is allowed depends on the SecurityAction that is used.
    // The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
    // Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
    // CAUTION: Unrestricted FileIOPermission grants permission for all paths within a file system, 
    // including multiple pathnames that can be used to access a single given file. To Deny access to a file, you must Deny all possible paths to the file. 
    // For example, if \\server\share is mapped to the network drive X, to Deny access to \\server\share\file, 
    // you must Deny \\server\share\file, X:\file and any other path that you can use to access the file.
[assembly:FileIOPermission(SecurityAction.RequestMinimum)]
#endif

#endregion Security