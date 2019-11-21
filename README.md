# OpenBank
 
The Api was created using Sql Server, DDD and entity framework core (with a generic repository aproach);

As usually banks use their own criptography methods, I choose to create a class to criptography the password and check the validation of it, instead of using identy framework form dotnet;

I also used dotnet entity framework migrations to generate and update the database;

I implemented swagger to use as a minimal documentation for API use;

To change database connection you need to the paths ".\OpenBank\OpenBank\OpenBank.Infra.Data\Context\MyContext.cs" and ".\OpenBank\OpenBank\CrossingCutting\DependencyInjection\ConfigureRepository.cs" and change the connection strings.
