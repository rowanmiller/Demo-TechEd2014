EF @ TechEd 2014
===============

This repo includes the completed source code from the demos shows during my [Entity Framework session at TechEd North America 2014](http://channel9.msdn.com/Events/TechEd/NorthAmerica/2014/DEV-B417).

Only code from the EF6 demos is included. The EF7 demos used a bunch of local builds and code that isn't checked into our main repository yet, so I am unable to make that available.

You should be able to open FakeEstate.ListingManager.sln and build from Visual Studio. To run the application you will need to have .\SQLEXPRESS available (there is code in Global.asax.cs to create the database on startup if it doesn't exist). 
