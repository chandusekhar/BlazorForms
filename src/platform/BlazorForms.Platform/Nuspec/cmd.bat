﻿cd C:\repos\BlazorForms\src\platform\BlazorForms.Platform\Nuspec
nuget.exe pack BlazorForms.nuspec -NonInteractive -OutputDirectory c:\temp\Nuget -Verbosity Detailed -version 1.8.2
nuget.exe pack BlazorForms.Rendering.nuspec -NonInteractive -OutputDirectory c:\temp\Nuget -Verbosity Detailed -version 0.8.2

cd C:\repos\BlazorForms\src\rendering\BlazorForms.Rendering.MudBlazorUI\
dotnet pack BlazorForms.Rendering.MudBlazorUI.csproj --output  c:\temp\Nuget

pause