# Goblin Defence
    We have extracted the itemclass and changed it to an abstract class with two additional abstract methods UpdateQuality and UpdateSellin. We feel that this does not change the inital structure of the program enough to upset the goblin. 

# Coverage 
+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 100% | 96.42% | 100%   |
+---------+------+--------+--------+
| Average | 100% | 96.42% | 100%   |
+---------+------+--------+--------+

# Guide for setup only for group members
## If you want to make a text file with the output
    dotnet run > ../GildedRose.Tests/output.txt

## Setting up coverlet
     Install coverlet msbuild testing
    dotnet add package coverlet.msbuild

     Run This command to see Test Coverage and export it to a cobertura.xml file
    dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
    or dotnet test /p:CollectCoverage=true 
    if you only want to see coveragepercent

    //Generate report Command based on the generated file
        reportgenerator -reports:"GildedRose.Tests/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

    remember to add package ReportGenerator (if it does not work)

# New project help:
        dotnet new --help

## SET NEW TEST FOLDER: 

      dotnet new xunit -o [TestFolderName]

## Dotnet add all relevant folders:

        dotnet sln add [testfolder]

## How to reference testfolder to the folder you want to test:

        dotnet add [testfolder] reference [WhatYouWantToTest(Folder)]