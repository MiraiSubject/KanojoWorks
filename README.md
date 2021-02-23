# KanojoWorks

A cross platform visual novel framework using [osu!framework](https://github.com/ppy/osu).

## Requirements

- A desktop platform with the [.NET 5.0 SDK](https://dotnet.microsoft.com/download) or higher installed.
- When running on linux, please have a system-wide ffmpeg installation available to support video decoding.
- When running on Windows 7 or 8.1, *[additional prerequisites](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50&pivots=os-windows#dependencies)** may be required to correctly run .NET 5 applications if your operating system is not up-to-date with the latest service packs.
- When working with the codebase, we recommend using an IDE with intellisense and syntax highlighting, such as [Visual Studio 2019+](https://visualstudio.microsoft.com/vs/), [Jetbrains Rider](https://www.jetbrains.com/rider/) or [Visual Studio Code](https://code.visualstudio.com/).

## Current Status

Package status: None available at the moment.
TL;DR: A lot is still changing and will probably break. 

- Some basic containers essential for scaling content are available for consumers to use.
- A container for providing choice in a novel has controller and keyboard support and is mostly functional. 
- Some basic essential user interface elements are available.
- An incomplete settings page is available, with currently support for changing window mode, scaling mode and changing the resolution.

**NuGet package support will come once this project is in a more feature complete state, so stay tuned!**

## Objectives

This framework is intended to provide a user-friendly, but also advanced, visual novel framework. This is also a medium for me to program with a certain end goal in mind and to get to know osu!framework itself better.

- Anywhere a graphical component is implemented, I try to make it generic and derivable for further customisation. 

### Building

Build configurations for the recommended IDEs (listed above) are included. You should use the provided Build/Run functionality of your IDE to get things going. When testing or building new components, it's highly encouraged you use the `VisualTests` project/configuration. The goal is to eventually release an example visual novel as well so can see your changes in context.

- Visual Studio / Rider users should load the project via one of the platform-specific .slnf files, rather than the main .sln. This will allow access to template run configurations.

## Licence

This framework is licensed under the [MIT licence](https://opensource.org/licenses/MIT). Please see [the licence file](LICENCE) for more information. [tl;dr](https://tldrlegal.com/license/mit-license) you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.

The BASS audio library (a dependency of this framework) is a commercial product. While it is free for non-commercial use, please ensure to [obtain a valid licence](http://www.un4seen.com/bass.html#license) if you plan on distributing any application using it commercially.