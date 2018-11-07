# Pokemon test application

For detailed informations, read "Project_Test_TechnicalManual.docx" at the root of the repository (in French, no english translation).

Pre requisites :

- Visual Studio 2017,
- .NET Framework 4.7.1 Developer Pack, at least,
- Directory "packages" in all projects that require it (NuGet Dependencies).

Known issues :

- Data mapping between EF6 and SQLite DB is not working properly until now (2018-11-04), you should clone sources in C:\DEV\ until it'll be fixed (for Data unit tests only). Even if you clone sources in other location, you should be able to build and launch BackEnd and FrontEnd projects.

Description :

This test project includes 2 parts in C#, using sln files you'll have to use Visual Studio 2017 (I used community edition) and .NET Framework 4.7.1 / 4.7.2 Developer Pack

Instructions :

To Begin, open BackEnd.sln and start PokemonBackEnd project (set it up as a Startup project).
IIS express will start and server will listen on http://localhost:51510.

Then, open FrontEnd.sln and start it up (make it again a Startup project) to display UI.
