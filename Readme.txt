1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
  Update-Database -Context Restaurant_Ratings_IdentityContext 


5. On the console execute the following command

 Update-Database -Context Restaurant_Ratings_DataContext



6. After migration is successful Run the project 

7 if you login as admin  from the following credentials will be able to see the Customers,  
Restaurants  and Ratings Links. 

User : admin@restaurants.com
Password: 1qaz2wsX@

8. Also you can login with the following credentials to visit the site as a Customer
 Can View and rate restaurants. You can also register a customer with Customer sign up link . A customer can rate one restaurant once only.

 User : jack@gmail.com
Password: 1qaz2wsX@



9 if you need to create another  admin login with the admin credentials on step 7 above and
Click in "Create rating admin" register a new admin 





The identity  authentication code used in the project were obtained by following URLS

Introduction to Identity on ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.0&tabs=visual-studio
