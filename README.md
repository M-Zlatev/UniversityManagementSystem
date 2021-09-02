# University Management System
The system is capable of managing university resources and is suitable for both students and teachers. The system also has a forum where students and teachers can hold discussions and find everything they are interested in.
# Technology stack
• &nbsp; ASP.NET Core 5.0 <br>
• &nbsp; Entity Framework (EF) Core 5.0.2 <br>
• &nbsp; Razor View Engine <br>
• &nbsp; Microsoft SQL Server Express <br>
• &nbsp; ASP.NET Identity System (extended with custom application user, custom application roles, changed primary key from string to int for easier table relationship links) <br>
• &nbsp; MVC Areas (Identity - custom Sign In and Sign Up form with custom authentication layout, Admin area, Forum area) <br> 
• &nbsp; Partial View and View Components <br>
• &nbsp; Repository Pattern <br>
• &nbsp; Dependency Injection <br>
• &nbsp; AutoМapper <br>
• &nbsp; Data Validation - both Client-side and Server-side (in Models and Input View Models) <br>
• &nbsp; Automatic registration of services in Startup (can be found in UMS.Web.Infrastructure --- Extensions --- ServiceCollectionExtensions - AddConventionalServices method) <br>
• &nbsp; Automatic data seeding (on first startup) <br>
• &nbsp; Bootstrap <br>
• &nbsp; jQuery <br>
• &nbsp; TinyMCE (HTML editor designed to simplify website content creation - in our application it makes easier the writing of forum posts and responses) <br>
• &nbsp; HTML Sanitizer <br>
• &nbsp; StyleCop <br>
• &nbsp; xUnit <br>
• &nbsp; Moq
