# Backend.NET-API_Muhd_Fahim_Aiman
Backend.NET API for Technical Assessment

Name : Muhammad Fahim Aiman Bin Mohamad Firdaus (Backend .NET Developer Assessment)

- After extracting, go to the directory where the project is stored in Command Prompt
- type "dotnet ef migrations add InitialCreate --project FreelancerApp.Infrastructure --startup-project FreelancerApp.Api"
- If migrations already exist then ignore
- type "dotnet ef database update --project FreelancerApp.Infrastructure --startup-project FreelancerApp.Api"
- type "cd FreelancerApp.Api"
- type "dotnet build"
- type "dotnet run"
- Can test using Swagger UI using "http://localhost:XXXX/swagger/index.html" for the functionalities

JSON Payload/ Example (POST)  
{ 
    "username": "nathan_drake", 
    "email": "nathan.drake@example.com", 
    "phoneNumber": "012-1031789", 
    "skillsets": 
    [ 
        { "name": "C#" }, 
        { "name": "ASP.NET Core" }, 
        { "name": "SQL" } ], 
        "hobbies": [ 
            { "name": "Photography" }, 
            { "name": "Cycling" } 
            ] 
            
    }
