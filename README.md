# Host4Travel
## About

  Nowadays, as an alternative to applications like Airbnb, Couchsurfing, 
  which are preferred by students and travelers for free or for a fee,
  for people who do not want to allocate a budget for their travel, or who have problems finding accommodation for free.
  We provide a new opportunity with this project we are working on.
  People traveling under this project will be able to stay free of charge and / or meet their basic needs by 
  doing the work that the landlords have chosen (garden maintenance, house cleaning, personal car cleaning, cooking, etc.) 
  under the headings we set. This way they will be able to travel around the world without 
  allocating a budget for accommodation and / or basic needs.

## The Construction Phase Of Host4Travel

  1.Content and details of the project determined. 
  2.Added required data tables and relationships to database. 
  3.The required ORM (Entity Framework) technology was determined for the project.
  4.The Entity layer of the project was created and a reference was added tothe BLL layer.
  5.Core layer was created for the auxiliary and common methods of the project. 
  6.In the core layer, classes such as Utility and Mapping are created. 
  7.Data Access Layer of the project was created and required repositories were implemented. 
  8.These repositories communicated with the database through Entity Framework. 
  9.Business Logic Layer of the project was created. 
  10.Fluent Validation library was used to control the operations for data in BLL.
  11.Dependency injections between BLL and DAL were configured in IoC Container.
  12.If the controls in BLL were successful, they were then directed to the DAL layer.
  13.NET Core API project was created for restful service. 
  14.Necessary routing conventions, Authentication (JWT Bearer Token) configurations were made in the project. 
  15.Controllers, Models and Response classes added. 
  16.Processes on the controller are directed to the required service (BLL Services)
  17.Token configuration is provided with .NET Identity Owin. 
  18.Data Transfer Object Classes were created for the transitions between API and UI Layer.
  19.AutoMapper library was used for mapping operations of these classes. The API has been published in Azure Cloud for testing.

