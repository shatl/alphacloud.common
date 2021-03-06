﻿#region copyright

// Copyright 2013-2016 Alphacloud.Net
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

#endregion

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("Alphacloud.Common.Core")]
[assembly: AssemblyDescription("Alphacloud.Common core functionality")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("4528d049-8f75-4e1a-9946-c96d9892bf8a")]
[assembly: AssemblyVersion("0.5.0.0")]
[assembly: AssemblyFileVersion("0.5.0.0")]

#if NET40

    [assembly: InternalsVisibleTo("Tests.Core.Net40, PublicKey="
        + "002400000480000094000000060200000024000052534131000400000100010013c2547ac065d2"
        + "f3979be28c786c92ef6e04a811d906ad5400f4bbde194b792f6d5f9de09e432d5c000f47ecb7b6"
        + "23ea55bfa0dab68f823ebf8853970eca5ac173f18cde177b74b7992a3b2794df722862ecf505df"
        + "e2e2599f283c2e05e01d23be706a602f28a4fa86a2fed0d79c0c77d8e4893062e343d1b8989e86"
        + "9020a6f2")]
#endif

#if NET45
    [assembly: InternalsVisibleTo("Tests.Core.Net45, PublicKey="
        +"002400000480000094000000060200000024000052534131000400000100010013c2547ac065d2"
        +"f3979be28c786c92ef6e04a811d906ad5400f4bbde194b792f6d5f9de09e432d5c000f47ecb7b6"
        +"23ea55bfa0dab68f823ebf8853970eca5ac173f18cde177b74b7992a3b2794df722862ecf505df"
        +"e2e2599f283c2e05e01d23be706a602f28a4fa86a2fed0d79c0c77d8e4893062e343d1b8989e86"
        +"9020a6f2")]
#endif

#if NET46
    [assembly: InternalsVisibleTo("Tests.Core.Net46, PublicKey="
        +"002400000480000094000000060200000024000052534131000400000100010013c2547ac065d2"
        +"f3979be28c786c92ef6e04a811d906ad5400f4bbde194b792f6d5f9de09e432d5c000f47ecb7b6"
        +"23ea55bfa0dab68f823ebf8853970eca5ac173f18cde177b74b7992a3b2794df722862ecf505df"
        +"e2e2599f283c2e05e01d23be706a602f28a4fa86a2fed0d79c0c77d8e4893062e343d1b8989e86"
        +"9020a6f2")]
#endif