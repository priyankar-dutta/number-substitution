# number-substitution
This repository is the developed solution for the problem set for Senior Technical Lead evaluation for Airportr. There are 3 separate folders in the repository:

NumberSubstitution.First - Solution for the first problem

NumberSubstitution.Second - Solution for the second problem

NumberSubstitution.Third - Solution for the third problem

## Pre-requisites
.NET 6 is required for building and running the solution in Visual Studio

A connection is also required to Nuget package library for downloading dependent Nuget packages for the solution

## Assumptions made while building the solution
- A Console Application is acceptable as a solution for demonstrating the working code
- User will provide inputs using the console which will then be used to evaluate outputs
- An appsettings.json file has been used to save the application settings (explained in detail later) - Any updates to the pre-provided configuration should be done by making changes to the appsettings.json file
- There is a lot of shared code that is repeated within the solution folders to allow for seeing the difference in working codes between the solutions
- Unit Tests have been written using NUnit and NSubstitute for mocking and is considered acceptable as no instruction was provided for using any particular framework for writing tests
- Unit Tests have not been written for Program.cs and Startup.cs files as those are placeholders for demonstrating the solution - only core solution code has been covered using tests
- In case of a situation that any two of the configurable numbers (3 & 5 as per the problem statement) are multiples of each other (e.g. 3 and 6 instead of 3 and 5) - it has been assumed that 6 will output the phrase for both 3 and 6 and not just 6 as its not explicitly clear from the problem statement what should happen in such scenarios - if this behaviour is required to be changed then it requires a small code change which can be done
- Solution has been built keeping extensibility in mind (e.g. multiple numbers to be configurable and not just 2, and same for override to allow for multiple overriding numbers)
- The appsettings.json file will be handled correctly and proper values will be set - any improper values set in appsettings.json will cause the solution to give runtime errors - this is by design

## Explaining the appsettings.json file
The appsettings.json file has been introduced to allow for changing and introducing more configurable data for the problem
For example: For NumberSubstitution.First the appsettings.json file has the following:

`
{
  "AppSettings": {
    "NumberReplacementDictionaryData": {
      "3": "fizz",
      "5": "buzz"
    }
  }
}
`

If more configurable values are required to be introduced it can be done by adding more values to the dictionary. An example below where 2 has been added as an extra value and the output for 5 has been changed:

`
{
  "AppSettings": {
    "NumberReplacementDictionaryData": {
      "3": "fizz",
      "5": "newoutput",
      "2": "mazz"
    }
  }
}
`

The appsettings.json file for the 2nd and 3rd problems has an additional setting to allow more numbers to be added to the override list. The concept is same. 

## Some Examples with modified appsettings.json files

Problem 3: Inputs 1 and 35

appsettings.json 

`
{
  "AppSettings": {
    "NumberReplacementDictionaryData": {
      "3": "fizz",
      "5": "buzz",
      "2": "mazz"
    },
    "NumberReplacementOverrideDictionaryData": {
      "3": "lucky",
      "4": "unlucky"
    }
  }
}
`

Output:

Main:

1 mazz lucky unlucky buzz mazzfizz 7 mazz fizz mazzbuzz 11 mazzfizz lucky unlucky fizzbuzz mazz 17 mazzfizz 19 mazzbuzz fizz mazz lucky unlucky buzz mazz fizz mazz 29 lucky lucky lucky lucky luckyunlucky lucky

Summary:

integer: 6 mazz: 6 lucky: 8 unlucky: 3 buzz: 2 mazzfizz: 3 fizz: 3 mazzbuzz: 2 fizzbuzz: 1 luckyunlucky: 1
