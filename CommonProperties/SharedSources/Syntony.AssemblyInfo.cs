// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Syntony.AssemblyInfo.cs" company="Syntony">
//     Copyright © 2004 - 2015 by Syntony / Josef Hahnl - syntony@aon.at - All rights reserved.
// </copyright>
// <author>Ing. Josef Hahnl, MBA - User</author>
// <email>hahnl@aon.at</email>
// <date>11.12.2015 07:25:06</date>
// <information solution="Syntony.Framework" project="Syntony.Framework.Assistance.UnitTests" framework=".NET Framework 4.5.2" kind="Windows (C#)">
//     <file type=".cs" created="06.07.2015 10:25:23" modified="11.12.2015 07:25:06" lastAccess="11.12.2015 07:25:06">
//         E:\Syntony\Projects\Framework\Main\CommonProperties\SharedSources\Syntony.AssemblyInfo.cs
//     </file>
//     <lines total="428" netLines="378" codeLines="89" allCommentLines="289" commentLines="285" documentationLines="4" blankLines="50" codeRatio="20.79 %"/>
//     <language>C#</language>
// </information>
// <summary>
//      This file "Syntony.AssemblyInfo.cs" (located in the "...\CommonProperties\SharedSources\" folder) is part of the complete AssemblyInfo and will be used for all Syntony projects (like Syntony.SyntonyFramework.*.dll).
// </summary>
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pragma warning disable 1587

/// <summary>
/// This file "Syntony.AssemblyInfo.cs" (located in the "...\CommonProperties\SharedSources\" folder)
/// is part of the complete AssemblyInfo and will be used for all Syntony projects (like Syntony.SyntonyFramework.*.dll).
/// </summary>

#pragma warning restore 1587

// This file "Syntony.AssemblyInfo.cs" (located in "...\CommonProperties\SharedSources\" folder) 
// is the root part of the complete AssemblyInfo file structure and will be used for all Syntony-elements like *.dll and *.exe.
// *****************************************************************************************************************************
// :warning: In common add this file as a LINK to the Visual Studio project :warning:
// :warning: If added as a LINK, changes to Syntony.AssemblyInfo.cs affects on every assembly of the Syntony project (*.exe and *.dll) :warning:
// :warning: So be very careful changing a piece of code inside this file :warning:
// *****************************************************************************************************************************
// There are maximum 5 pieces of AssemblyInfo.cs in a solution which are supported by "CommonProperties\SharedSources\Syntony.Common.props":
//      :one: "Syntony.AssemblyInfo.cs" (located in the "...\CommonProperties\SharedSources\" folder) ... this file should be added as a LINK!
//          This file is detected by MSBuild via $(SharedSources)\$(Company).AssemblyInfo.cs.
//          AssemblyCompany, AssemblyCopyright, AssemblyTrademark, AssemblyConfiguration, AssemblyCulture, NeutralResourcesLanguage
//          CLSCompliant, Security (if OLD_TARGET_FRAMEWORKVERSION is defined), ComVisible, RuntimeCompatibility
//          "Syntony.AssemblyInfo.cs" is the root part of the complete AssemblyInfo and will be used for all Syntony-elements like *.dll and *.exe.
//
//      :two: "Syntony.Framework.AssemblyInfo.cs" (located in the "...\CommonProperties\SharedSources\" folder) ... this file should be added as a LINK!
//          This file is detected by MSBuild via $(SharedSources)\$(Company).Framework.AssemblyInfo.cs and is created by a text template Syntony.Framework.AssemblyInfo.tt.
//          AssemblyProduct, AssemblyVersion, AssemblyFileVersion, SatelliteContractVersion, AssemblyInformationalVersion, ComCompatibleVersion
//          "Syntony.Framework.AssemblyInfo.cs" is part of the complete AssemblyInfo and will be used for all Syntony.Framework elements (Syntony.Framework.*.dll).
//
//      :three: "Syntony.[ProjectName].AssemblyInfo.cs" (located in "...\[ProjectName]\Source\Properties\" folder)
//          This file is detected by MSBuild via $(MSBuildProjectDirectory)\Properties\$(Company).$(MSBuildProjectName).AssemblyInfo.cs.
//          AssemblyTitel, Assembly Description, AssemblyProduct, InternalsVisibleTo, Guid, and all other attributes like special Security or Logging attributes
//          If AssemblyVersion, AssemblyFileVersion, SatelliteContractVersion, AssemblyInformationalVersion, ComCompatibleVersion is set, this file can be created by a text template Syntony.[ProjectName].AssemblyInfo.tt.
//
//      :four:  "Syntony.[ProjectName].Version.AssemblyInfo.cs" (located in "...\[ProjectName]\Source\Properties\" folder)
//          This file is detected by MSBuild via$(MSBuildProjectDirectory)\Properties\$(Company).$(MSBuildProjectName).Version.AssemblyInfo.cs and is created in common by a text template Syntony.[ProjectName].Version.AssemblyInfo.tt.
//          Use this file only for setting different versions if not set in :three: "Syntony.[ProjectName].AssemblyInfo.cs" or :five: "AssemblyInfo.cs"
//          AssemblyVersion, AssemblyFileVersion, SatelliteContractVersion, AssemblyInformationalVersion, ComCompatibleVersion
//
//      :five: "AssemblyInfo.cs" (located in "...\[ProjectName]\Source\Properties\" folder)
//          This file is detected by MSBuild via $(MSBuildProjectDirectory)\Properties\AssemblyInfo.cs
//          Can have the same attributes like "Syntony.[ProjectName].AssemblyInfo.cs" if "Syntony.[ProjectName].AssemblyInfo.cs" is not included.
//          AssemblyTitel, Assembly Description, AssemblyProduct, InternalsVisibleTo, Guid, and all other attributes like special Security or Logging attributes
//          If AssemblyVersion, AssemblyFileVersion, SatelliteContractVersion, AssemblyInformationalVersion, ComCompatibleVersion is set, this file can be created by a text template AssemblyInfo.tt.
//
// There are some symbol definitions:
//      #define SYNTONY because it is a Syntony project ... this symbol is defined in :one: "Syntony.AssemblyInfo.cs"
//      #define SYNTONY_FRAMEWORK if this is a Syntony SyntonyFramework project ... this symbol is defined in :two: "Syntony.Framework.AssemblyInfo.cs"
//      #define OLD_TARGET_FRAMEWORKVERSION if you use .NET target framework less than 4.0 (that means if you use .Net SyntonyFramework 2.0, 3.0 or 3.5)
//
//      #define NEUTRALRESOURCES_EN if English is used as the neutral culture of a Syntony-Assembly (also if NOT defined this is the default behavior) ... NEUTRALRESOURCES_EN can be defined in project properties
//      #define NEUTRALRESOURCES_DE if German is used as the neutral culture of a Syntony-Assembly ... NEUTRALRESOURCES_DE can be defined in project properties
//      if NEUTRALRESOURCES_EN and NEUTRALRESOURCES_DE are NOT defined => NEUTRALRESOURCES_EN is set and English is used as the neutral culture
//
//      #define CLS_COMPLIANT_TRUE to set [assembly: CLSCompliant(true)] ... VISUALSTUDIOPACKAGE, CLS_COMPLIANT_FALSE, CLS_COMPLIANT_TRUE should be defined in project properties
//      #define VISUALSTUDIOPACKAGE or CLS_COMPLIANT_FALSE to set [assembly: CLSCompliant(false)]
//      if neither VISUALSTUDIOPACKAGE, CLS_COMPLIANT_FALSE, CLS_COMPLIANT_TRUE is defined  [assembly: CLSCompliant(true)] is set
//
//      #define MAKE_PACKAGE if you want to add this project result to a NuGet package within Release configuration only -
//          you can define the symbol MAKE_PACKAGE in every AssemblyInfo.cs file as described above or set it in conditional compilation symbols on Build properties project side
//      #define PUBLISH_PACKAGE if you want to push / publish your package to NuGet Gallery within Release configuration only - you can define the symbol PUBLISH_PACKAGE in every AssemblyInfo.cs file as described above
//          you can define the symbol PUBLISH_PACKAGE in every AssemblyInfo.cs file as described above or set it in conditional compilation symbols on Build properties project side
#if !SYNTONY
// This is a SYNTONY project
#define SYNTONY
#endif

#if (!NEUTRALRESOURCES_EN && !NEUTRALRESOURCES_DE)
// English is used as the neutral culture for Syntony projects
#define NEUTRALRESOURCES_EN
#endif

using System;
using System.Reflection;
#if !VISUALSTUDIOPACKAGE
using System.Resources;
#endif
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if OLD_TARGET_FRAMEWORKVERSION
using System.Security.Permissions;
#endif

// Defines a company name custom attribute for an assembly manifest.
// The company name is used for the default path (local or roaming user and also for application path)
[assembly: AssemblyCompany("Syntony - Josef Hahnl")]

// Defines a copyright custom attribute for an assembly manifest. 
[assembly: AssemblyCopyright("Copyright © 2004-2015 by Syntony - Josef Hahnl  syntony@aon.at - All rights reserved.")]

// Defines a trademark custom attribute for an assembly manifest. 
[assembly: AssemblyTrademark("https://twitter.com/SyntonyAustria")]

#if SYNTONY_CODE_ANALYSIS
// Specifies the build configuration, such as release or debug, for an assembly.
[assembly: AssemblyConfiguration("DEVLOPMENT-Status with SyntonyCodeAnalysis")]
#elif DEBUG
// Specifies the build configuration, such as release or debug, for an assembly.
[assembly: AssemblyConfiguration("DEVLOPMENT-Status")]
#else
// Specifies the build configuration, such as release or debug, for an assembly
[assembly: AssemblyConfiguration("RELEASE")]
#endif

// Specifies which culture the assembly supports.
// The attribute is used by compilers to distinguish between a main assembly and a satellite assembly. 
// A main assembly contains code and the neutral culture's resources. 
// A satellite assembly contains only resources for a particular culture, as in [assembly:AssemblyCultureAttribute("de")]. 
// Putting this attribute on an assembly and using something other than the empty string (String.EmptyObjects) for the culture name 
// will make this assembly look like a satellite assembly, rather than a main assembly that contains executable code. 
// Labeling a traditional code library with this attribute will break it, 
// because no other code will be able to find the library's entry points at runtime.
// For more information, see the Common Language Infrastructure (CLI) documentation, 
// especially "Partition II: Metadata Definition and Semantics". 
// The documentation is available online at http://msdn.microsoft.com/net/ecma/ and 
// http://www.ecma-international.org/publications/standards/Ecma-335.htm.
[assembly: AssemblyCulture("")]

// Informs the ResourceManager of the neutral culture of an assembly.
// The NeutralResourcesLanguageAttribute informs the ResourceManager of the language used to write the 
// neutral culture's resources for an assembly, and can also inform the ResourceManager of the assembly to use 
// (either the main assembly or a satellite assembly) to retrieve neutral resources using the resource fallback process. 
// When looking up resources in the same culture as the neutral resources language, 
// the ResourceManager automatically uses the resources located in the main assembly, 
// instead of searching for a satellite assembly with the current user interface culture for the current thread. 
// This will improve lookup performance for the first resource you load, and can reduce your working set.
// Apply this attribute to your main assembly, passing it the name of the neutral language that will work with your main assembly. 
// Optionally, you can pass a member of the UltimateResourceFallbackLocation enumeration to indicate the location 
// from which to retrieve fallback resources. Using this attribute is strongly recommended.
// Fallback resources are located in a satellite assembly.
#if VISUALSTUDIOPACKAGE
// currently no support for UltimateResourceFallbackLocation.Satellite
#else
#if NEUTRALRESOURCES_EN
    // English is used as the neutral culture of an Syntony-assembly due to performance improvement.
    // you have to set each Form to Language EN
    [assembly: NeutralResourcesLanguage("en", UltimateResourceFallbackLocation.Satellite)]
#elif NEUTRALRESOURCES_DE
    // German is used as the neutral culture of an Syntony-Assembly due to performance improvement.
    // you have to set each Form to Language De
    [assembly: NeutralResourcesLanguage("de", UltimateResourceFallbackLocation.Satellite)]
#else
    // English is used as the neutral culture of an Syntony-assembly due to globalization. That's the default behavior.
    // you have to set each Form to Language EN
    [assembly: NeutralResourcesLanguage("en", UltimateResourceFallbackLocation.Satellite)]
#endif
#endif

#region CLS

// Indicates whether a program element is compliant with the Common Language Specification (CLS). 
// You can apply the CLSCompliantAttribute attribute to the following program elements: 
// assembly, module, class, struct, enum, constructor, method, property, field, event, interface, delegate, parameter, and return value. 
// However, the notion of CLS compliance is only meaningful for assemblies, modules, types, and members of types, not parts of a member signature. 
// Consequently, CLSCompliantAttribute is ignored when applied to parameter or return value program elements.
// If no CLSCompliantAttribute is applied to a program element, then by default:
// 1) The assembly is not CLS-compliant.
// 2) The type is CLS-compliant only if its enclosing type or assembly is CLS-compliant.
// 3) The member of a type is CLS-compliant only if the type is CLS-compliant.
// If an assembly is marked as CLS-compliant, any publicly exposed type in the assembly that is not CLS-compliant must be marked with 
// CLSCompliantAttribute using a false argument. Similarly, if a class is marked as CLS-compliant, 
// you must individually mark all members that are not CLS-compliant.
// All non-compliant members must provide corresponding CLS-compliant alternatives.
// Attributes that are applied to assemblies or modules must occur after the C# using (Imports in Visual Basic) clauses and before the code.
#if (CLS_COMPLIANT_FALSE && CLS_COMPLIANT_TRUE)
#error CLS_COMPLIANT_FALSE and CLS_COMPLIANT_FALSE is defined - delete one of this definitions
#elif (CLS_COMPLIANT_FALSE || VISUALSTUDIOPACKAGE)
[assembly: CLSCompliant(false)]
#elif (CLS_COMPLIANT_TRUE)
[assembly: CLSCompliant(true)]
#else
// by default we want to be CLS compliant
[assembly: CLSCompliant(true)]
#endif

#endregion CLS

#region Security

#if OLD_TARGET_FRAMEWORKVERSION
    
// PermissionSet: Allows security actions for a PermissionSet to be applied to code using declarative security.
// The PermissionSetAttribute properties Name, File, and XML are mutually exclusive, 
// meaning that a permission set can have as its source only one of the following: 
// a named permission set, 
// a file containing an XML representation of a permission set, 
// or a string containing an XML representation of a permission set.
// The scope of the declaration that is allowed depends on the SecurityAction that is used. 
// A SecurityAction performed on a PermissionSet is the equivalent of 
// performing that action on each of the permissions within the set.
// The security information declared by a security attribute is stored in the metadata of the attribute target 
// and is accessed by the system at run time. Security attributes are used only for declarative security. 
// For imperative security, use the corresponding permission class.
// example: [assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode=true)]
// SecurityAction: Specifies the security actions that can be performed using declarative security.
// Member name: Result
// Tooltip: The calling code can access the resource identified by the current permission object, 
// even if callers higher in the stack have not been granted permission to access the resource.
// Member name: Demand
// Tooltip: All callers higher in the call stack are required to have been granted the permission 
// specified by the current permission object. 
// Member name: Deny
// Tooltip: The ability to access the resource specified by the current permission object is denied to callers, 
// even if they have been granted permission to access it.
// Member name: InheritanceDemand
// Tooltip: The derived class inheriting the class or overriding a method is required to have been granted 
// the specified permission.  
// Member name: LinkDemand
// Tooltip: The immediate caller is required to have been granted the specified permission. 
// For more information on declarative security and link demands, see Declarative Security Used with Class and Member Scope.
// Member name: PermitOnly
// Tooltip: Only the resources specified by this permission object can be accessed, 
// even if the code has been granted permission to access other resources.
// Member name: RequestMinimum 
// Tooltip: The request for the minimum permissions required for code to run. 
// This action can only be used within the scope of the assembly.  
// Member name: RequestOptional
// Tooltip: The request for additional permissions that are optional (not required to run). 
// This request implicitly refuses all other permissions not specifically requested. 
// This action can only be used within the scope of the assembly.   
// Member name: RequestRefuse 
// Tooltip: The request that permissions that might be misused will not be granted to the calling code. 
// This action can only be used within the scope of the assembly.
[assembly:PermissionSet(SecurityAction.RequestMinimum, Name = "Nothing")]


// Allows security actions for EnvironmentPermission to be applied to code using declarative security. This class cannot be inherited.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
// Environment variable names are case-insensitive. Multiple environment variable names are specified by separating the names using PathSeparator.
[assembly:EnvironmentPermission(SecurityAction.RequestRefuse)]

// Allows security actions for FileDialogPermission to be applied to code using declarative security. This class cannot be inherited.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:FileDialogPermission(SecurityAction.RequestRefuse)]

// Allows security actions for FileIOPermission to be applied to code using declarative security.
// Files and directories are specified using absolute paths. When accessing files, a security check is performed when the file is created or opened. 
// The security check is not done again unless the file is closed and reopened. 
// Checking permissions when the file is first accessed minimizes the impact of the security check on application performance because opening a file happens only once, 
// while reading and writing can happen multiple times.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
// CAUTION: Unrestricted FileIOPermission grants permission for all paths within a file system, 
// including multiple path-names that can be used to access a single given file. To Deny access to a file, you must Deny all possible paths to the file. 
// For example, if \\server\share is mapped to the network drive X, to Deny access to \\server\share\file, 
// you must Deny \\server\share\file, X:\file and any other path that you can use to access the file.
[assembly:FileIOPermission(SecurityAction.RequestRefuse)]

// Allows security actions for IsolatedStorageFilePermission to be applied to code using declarative security.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:IsolatedStorageFilePermission(SecurityAction.RequestRefuse)]

// Allows security actions for PublisherIdentityPermission to be applied to code using declarative security. This class cannot be inherited.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The properties CertFile, SignedFile, and X509Certificate are mutually exclusive.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
// In the .NET SyntonyFramework versions 1.0 and 1.1, identity permissions cannot have an Unrestricted permission state value. 
// In the .NET SyntonyFramework version 2.0, identity permissions can have any permission state value. 
// This means that in version 2.0, identity permissions have the same behavior as permissions that implement the IUnrestrictedPermission interface. 
// For information on executing version 2.0 applications with version 1.1 code access security (CAS) policy, see <legacyV1CASPolicy> Element.
// By default, code access security does not check for Publisher evidence. Unless your computer has a custom code group based on the 
// PublisherMembershipCondition class, you can improve performance by bypassing Authenticode signature verification. 
// This is accomplished by configuring the runtime to not provide Publisher evidence for code access security. 
// For more information about how to configure this option and which applications can use it, see the <generatePublisherEvidence> element.
[assembly:PublisherIdentityPermission(SecurityAction.RequestRefuse)]

// Allows security actions for ReflectionPermission to be applied to code using declarative security. 
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:ReflectionPermission(SecurityAction.RequestRefuse)]

// Allows security actions for RegistryPermission to be applied to code using declarative security. This class cannot be inherited.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:RegistryPermission(SecurityAction.RequestRefuse)]

// Allows security actions for SecurityPermission to be applied to code using declarative security. This class cannot be inherited.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:SecurityPermission(SecurityAction.RequestRefuse, UnmanagedCode = false)]

// Allows security actions for SiteIdentityPermission to be applied to code using declarative security. This class cannot be inherited.
// Site identity is only defined for code from URLs with the protocols of HTTP, HTTPS, and FTP. 
// A site is the string between the "//" after the protocol of a URL and the following "/", if present, for example, www.fourthcoffee.com in the 
// URL http://www.fourthcoffee.com/process/grind.htm. This excludes port numbers. 
// If a given URL is http://www.fourthcoffee.com:8000/, the site is www.fourthcoffee.com, not www.fourthcoffee.com:8000.
// Sites can be matched exactly, or by a wildcard ("*") prefix at the dot delimiter. 
// For example, the site name string *.fourthcoffee.com matches fourthcoffee.com as well as www.fourthcoffee.com. Without a wildcard, 
// the site name must be a precise match. The site name string * will match any site, but will not match code that has no site evidence.
// In the .NET SyntonyFramework versions 1.0 and 1.1, demands on the identity permissions are effective even when the calling assembly is fully trusted. 
// That is, although the calling assembly has full trust, a demand for an identity permission fails if the assembly does not meet the demanded criteria. 
// In the .NET SyntonyFramework version 2.0, demands for identity permissions are ineffective if the calling assembly has full trust. 
// This assures consistency for all permissions, eliminating the treatment of identity permissions as a special case.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:SiteIdentityPermission(SecurityAction.RequestRefuse)]

// Allows security actions for UIPermission to be applied to code using declarative security. This class cannot be inherited.
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:UIPermission(SecurityAction.RequestRefuse)]

// Allows security actions for ZoneIdentityPermission to be applied to code using declarative security. This class cannot be inherited. 
// The scope of the declaration that is allowed depends on the SecurityAction that is used.
// In the .NET SyntonyFramework versions 1.0 and 1.1, demands on the identity permissions are effective even when the calling assembly is fully trusted. 
// That is, although the calling assembly has full trust, a demand for an identity permission fails if the assembly does not meet the demanded criteria. 
// In the .NET SyntonyFramework version 2.0, demands for identity permissions are ineffective if the calling assembly has full trust. 
// This assures consistency for all permissions, eliminating the treatment of identity permissions as a special case.
// The security information declared by a security attribute is stored in the metadata of the attribute target and is accessed by the system at run time. 
// Security attributes are used only for declarative security. For imperative security, use the corresponding permission class.
[assembly:ZoneIdentityPermission(SecurityAction.RequestRefuse)]
#else

// [assembly: AllowPartiallyTrustedCallers] // Allows an assembly to be called by partially trusted code. Without this declaration, only fully trusted callers are able to use the assembly
#if DEBUG
[assembly: SecurityRules(SecurityRuleSet.Level2, SkipVerificationInFullTrust = false)]
#else
[assembly: SecurityRules(SecurityRuleSet.Level2, SkipVerificationInFullTrust = true)]
#endif

#endif

#endregion Security

#region COM

// Controls accessibility of an individual managed type or member, or of all types within an assembly, to COM.
// You can apply this attribute to assemblies, interfaces, classes, structures, delegates, enumerations, fields, methods, or properties.
// The default is true, which indicates that the managed type is visible to COM.
// This attribute is not needed to make public managed assemblies and types visible; they are visible to COM by default.
// Only public types can be made visible. The attribute cannot be used to make an otherwise internal or protected type visible to COM
// or to make members of a non-visible type visible.
// Setting the attribute to false on the assembly hides all public types within the assembly.
// You can selectively make types within the assembly visible by setting the individual types to true.
// Setting the attribute to false on a specific type hides that type and its members.
// However, you cannot make members of a type visible if the type is invisible.
// Setting the attribute to false on a type prevents that type from being exported to a type library; classes are not registered; 
// interfaces are never responsive to unmanaged QueryInterface calls.
// Unless you explicitly set a class and its members to false,
// inherited classes can expose to COM base class members that are invisible in the original class.
// For example, if you set ClassA to false and do not apply the attribute to its members,
// the class and its members are invisible to COM. However, if you derive ClassB from ClassA and export ClassB to COM,
// ClassA members become visible base class members of ClassB.
// The System.Runtime.InteropServices.ComVisible attribute indicates whether COM clients can use the library.
// Good design dictates that developers explicitly indicate COM visibility. The default value for this attribute
// is 'true'. However, the best design is to mark the assembly ComVisible false, and then mark types, interfaces,
// and individual members as ComVisible true, as appropriate.
[assembly: ComVisible(false)]

#endregion COM

#region RuntimeCompatibility

// Specifies whether to wrap exceptions that do not derive from the Exception class with a RuntimeWrappedException object.
// Some languages, such as C++, allow you to throw exceptions of any type.
// Other languages, such as Microsoft C# and Visual Basic, require that every thrown exception be derived from the Exception class.
// To maintain compatibility between languages, the common language runtime (CLR) wraps objects that
// do not derive from Exception in a RuntimeWrappedException object.
// You can use the RuntimeCompatibilityAttribute class to specify whether exceptions should appear wrapped inside
// catch blocks and exception filters for an assembly. Many language compilers, including the Microsoft C# and Visual Basic compilers,
// apply this attribute by default to specify the wrapping behavior.
// Notation that the runtime still wraps exceptions even if you use the RuntimeCompatibilityAttribute class to specify that
// you do not want them wrapped. In this case, exceptions are unwrapped only inside catch blocks or exception filters.
// WrapNonExceptionThrows = true means if exceptions that do not derive from the Exception class
// should appear wrapped with a RuntimeWrappedException object.
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

#endregion RuntimeCompatibility

#region CompilationRelaxations
// // Literal strings (strings declared in source code) are by default interned into a pool to save memory.
// // Although it saves memory when the same literal string is used multiple times,
// // it costs some CPU to maintaining the pool and once a string is put into the pool it stays there until the process is stopped.
// // Using CompilationRelaxationsAttribute you can tell the JIT compiler that you really don't want it to intern all the literal strings.
// // Controls the strictness of the code generated by the common language runtime's just-in-time (JIT) compiler.
// // NoStringInterning marks an assembly as not requiring string-literal interning.
// [assembly: CompilationRelaxations(CompilationRelaxations.NoStringInterning)]
#endregion CompilationRelaxations
