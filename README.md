# Bug Tracker 2024
- Web app in C# that allows for users to track bugs

## To run Tracker itself:
- Cd into Bug_Tracker_App
- Install Dependancies 
- Run with dotnet watch run (for live reloads)


## Packages to install:
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-ef

<!-- dotnet add package Newtonsoft.Json
dotnet add package System.Data.SQLite -->



## Resources used:
- https://api.stackexchange.com/docs
- https://www.youtube.com/watch?v=9QomwwjQdP4


## Goals:
- Want to have a feed for every issue where people can comment and put an sla/converse with the customer
- Want to have a login system for each user (with a database maybe oauth)
- want to get get sample data from stackoverflow api to fill out tickets
- want to use docker / github actions to create a pipeline for deployment
- want to write my own unit tests that make sense
- want to write my own integration tests
- want to write my own documentation
- have a page of template requests (ie: request hardware, network outage, fix printer, onboard employee, etc)