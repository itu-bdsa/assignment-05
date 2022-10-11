dotnet run > ../GildedRose.Tests/output.txt

## Guide for setup

    // Install coverlet msbuild testing
    dotnet add package coverlet.msbuild

    // Run This command to see Test Coverage and export it to a cobertura.xml file
    dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
    or dotnet test /p:CollectCoverage=true 
    if you only want to see coveragepercent

    //Generate report Command based on the generated file
        reportgenerator -reports:"GildedRose.Tests/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

    remember to add package ReportGenerator (if it does not work)

    //New project help:
        dotnet new --help

    //SET NEW TEST FOLDER: 
        dotnet new xunit -o [TestFolderName]

    // Dotnet add all relevant folders
        dotnet sln add [testfolder]

    //How to reference testfolder to the folder you want to test:
        dotnet add [testfolder] reference [WhatYouWantToTest(Folder)]