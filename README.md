# test

For detailed informations, read "Project_Test_TechnicalManual.docx" at the root of the repository (in French, no english traduction).

Pre requisites :
- Visual Studio 2017,
- .NET Framework 4.7.1 Developer Pack, at least,
- Directory "packages" in all projects that require it (NuGet Dependencies).

This test project includes 2 parts in C#, using sln files you'll have to use Visual Studio 2017 (I used community edition) and .NET Framework 4.7.1 / 4.7.2 Developer Pack

To Begin, open BackEnd.sln and start PokemonBackEnd project (set it up as a Startup project).
It'll listen on localhost:51510 with IIS Express.

Then, open FrontEnd.sln and start it up (make it again a Startup project).
