# Clean Architecture With Microservice/NET 6- DAPPER - EF CORE
Building Ocelot API Gateway Microservice on .Net platforms which used Asp.Net Web Application, Ocelot microservice with applying Gateway Routing Pattern.
  -Student APIs with / Sql-server /Dapper
  -Book APIs with / Sql-server / Ef core
Architecture -Project
_______________________

![Architecture-2](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/489164d8-21f2-4714-a5b2-8433eeb170b6)

Ocelot API Gateway
___________________________
CleanArchitectureWithMicroservic
Ocelot is basically a set of middlewares that you can apply in a specific order.

Ocelot is a lightweight API Gateway, recommended for simpler approaches. Ocelot is an Open Source .NET Core-based API Gateway especially made for microservices architectures that need unified points of entry into their systems. It’s lightweight, fast, and scalable and provides routing and authentication among many other features.

![Architecture-Application](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/b337760f-ceeb-4d1d-b4a7-5e4a22b1c733)

The main reason to choose Ocelot for our reference application is because Ocelot is a .NET Core lightweight API Gateway that you can deploy into the same application deployment environment where you’re deploying your microservices/containers, such as a Docker Host, Kubernetes, etc. And since it’s based on .NET Core, it’s cross-platform allowing you to deploy on Linux or Windows.
Ocelot is designed to work with ASP.NET Core only. You install Ocelot and its dependencies in your ASP.NET Core project with Ocelot’s NuGet package, from Visual Studio.

Analysis & Design
This project will be the REST APIs which basically perform Routing operations on Catalog, Basket and Ordering microservices.

We should define our Ocelot API Gateway use case analysis.

Our main use cases;

Route Student APIs with /Student path
Route Book APIs with / Book path

Ocelot.Local.json File Routing API
In order to use routing we sould create Ocelot.Local.json and put json objects.

The important part here is that each element we define in the Routes series represents a service.

In the DownstreamPathTemplate field, we define the url directory of the api application. In UpstreamPathTemplate, we specify which path the user writes to this api url.

Create Ocelot.Local.json file.

![ocelotjson](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/27aa89db-7e34-44ab-868d-13e0d1027108)
![ocelotjson2](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/97503a9e-9f23-444d-8267-78cae68b0cce)

These routes definition provide to open api to outside of the system and redirect these request into internal api calls.
Of course these requests will have token so Ocelot api gateway also carry this token when calling to internal systems.
Also as you can see that we had summarized the api calls remove api path and use only /Book path when exposing apis for the client application.

We have Develop and configured our Ocelot Api Gateway Microservices with seperating environment configurations.

Run Application
Now the API Gateway microservice Web application ready to run.

Book
http://localhost:5210/swagger/index.html

#Get API
![Get-Book-Api](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/74e51e98-4b1d-4bf7-a918-16ff1cc5b450)
![Get-Book-Api-Success](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/ff85668f-ab3e-4957-8a5a-8b3cbbc1527e)

#Post API
![AddBook-API](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/6e40af58-4c1b-42a7-a70b-5555afa199e6)
![AddBook-API-success](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/acbcee75-1c5c-4eb5-a340-9f457226e635)

Student
http://localhost:5255/swagger/index.html
![Created-Student-API](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/fa89800a-7077-4af8-8751-6447ce5ebf50)

Change the App URL to http://localhost:5053

Hit F5 on APIGateway project.
Exposed the APIGateways in our Microservices, you can test it over the chrome or Postman.

#Consummer Microservices Book http://localhost:5053/gateway/books
![Gateway-GetAllBook](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/64139fbf-cd4f-4346-afad-826e3166573c)

#Consummer Microservices Book  http://localhost:5053/gateway/books/4
![Gateway-GetByIdBook](https://github.com/HeritierMav-2023/CleanArchitectureWithMicroservice/assets/148790419/299b7c6a-46eb-45fc-a3d3-54bf55c9fa79)



