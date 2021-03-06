﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Alphacloud.Common.Infrastructure")]
[assembly: AssemblyDescription("Alphacloud infrastructure includes caching abstraction layer and instrumentation runtime.")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ba321126-5c95-4959-9f5b-43c1b249a2ea")]

[assembly: AssemblyVersion("0.5.0.0")]
[assembly: AssemblyFileVersion("0.5.0.0")]

#if NET40
[assembly: InternalsVisibleTo("Tests.Infrastructure.Net40, PublicKey="
    + "002400000480000094000000060200000024000052534131000400000100010013c2547ac065d2"
    + "f3979be28c786c92ef6e04a811d906ad5400f4bbde194b792f6d5f9de09e432d5c000f47ecb7b6"
    + "23ea55bfa0dab68f823ebf8853970eca5ac173f18cde177b74b7992a3b2794df722862ecf505df"
    + "e2e2599f283c2e05e01d23be706a602f28a4fa86a2fed0d79c0c77d8e4893062e343d1b8989e86"
    + "9020a6f2")]
#endif

#if NET45
[assembly: InternalsVisibleTo("Tests.Infrastructure.Net45, PublicKey="
    + "002400000480000094000000060200000024000052534131000400000100010013c2547ac065d2"
    + "f3979be28c786c92ef6e04a811d906ad5400f4bbde194b792f6d5f9de09e432d5c000f47ecb7b6"
    + "23ea55bfa0dab68f823ebf8853970eca5ac173f18cde177b74b7992a3b2794df722862ecf505df"
    + "e2e2599f283c2e05e01d23be706a602f28a4fa86a2fed0d79c0c77d8e4893062e343d1b8989e86"
    + "9020a6f2")]
#endif

#if NET46
[assembly: InternalsVisibleTo("Tests.Infrastructure.Net46, PublicKey="
    + "002400000480000094000000060200000024000052534131000400000100010013c2547ac065d2"
    + "f3979be28c786c92ef6e04a811d906ad5400f4bbde194b792f6d5f9de09e432d5c000f47ecb7b6"
    + "23ea55bfa0dab68f823ebf8853970eca5ac173f18cde177b74b7992a3b2794df722862ecf505df"
    + "e2e2599f283c2e05e01d23be706a602f28a4fa86a2fed0d79c0c77d8e4893062e343d1b8989e86"
    + "9020a6f2")]
#endif
