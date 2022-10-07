dotnet run > ../GildedRose.Tests/output.txt

    
    // Install coverlet msbuild testing
    dotnet add package coverlet.msbuild
    
    // Run This command to see Test Coverage
    dotnet test /p:CollectCoverage=true

    New project help:
        dotnet new --help

    SET NEW TEST FOLDER: 
        dotnet new xunit -o [TestFolderName]

    // Dotnet add all relevant folders
        dotnet sln add [testfolder]

    //How to reference testfolder to the folder you want to test:
        dotnet add [testfolder] reference [WhatYouWantToTest(Folder)]