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

    Content and details of the project determined. 
    Added required data tables and relationships to database. 
    The required ORM (Entity Framework) technology was determined for the project.
    The Entity layer of the project was created and a reference was added tothe BLL layer.
    Core layer was created for the auxiliary and common methods of the project. 
    In the core layer, classes such as Utility and Mapping are created. 
    Data Access Layer of the project was created and required repositories were implemented. 
    These repositories communicated with the database through Entity Framework. 
    Business Logic Layer of the project was created. 
    Fluent Validation library was used to control the operations for data in BLL.
    Dependency injections between BLL and DAL were configured in IoC Container.
    If the controls in BLL were successful, they were then directed to the DAL layer.
    NET Core API project was created for restful service. 
    Necessary routing conventions, Authentication (JWT Bearer Token) configurations were made in the project. 
    Controllers, Models and Response classes added. 
    Processes on the controller are directed to the required service (BLL Services)
    Token configuration is provided with .NET Identity Owin. 
    Data Transfer Object Classes were created for the transitions between API and UI Layer.
    AutoMapper library was used for mapping operations of these classes. The API has been published in Azure Cloud for testing.

