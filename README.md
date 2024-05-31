============================$$ Read Me File $$============================

# Project Name: ProgPoe_MVC_AgriEnergyConnect

==========================================================================

# GitHub Repository Link: 

	https://github.com/ST10025374/ProgPoe_MVC_AgriEnergyConnect

==========================================================================
##-------------------------- Description --------------------------##
==========================================================================

This project is an ASP.NET Core web application developed using .NET 6.0.
Development was done while utilising SSMS.
Database was Migrated from SSMS to Azure. 
Azure SQL database is connected and running.

==========================================================================
##-------------------------- Installation ------------------------------##
==========================================================================

Before running this application, ensure you have the following installed:

- .NET 6.0 
- Visual Studio 2022

==========================================================================
##-------------------------- Instructions ------------------------------##
==========================================================================

1. Build the application

2. Run the application

3. Access the application in your web browser at Eg: http://localhost:0000

==========================================================================
##---------------------- Accounts, Roles and functions -----------------##
==========================================================================

User must login to have access to functions and pre-populated data

	--------------------------------------------------------------------------------		
	-------------- Stored Accounts -------------	--------- Functions  -----------
	--------------------------------------------	--------------------------------
	*Admin("Employee") Account Login Credentials*   ->Employee Account<-
							*Employee can view all profiles and delete if desired
	Email: 		admin@gmail.com			*Employee can view all products and filter by category and date and delete if desired	
	Password:	Miguel@1234?			*Employee can register account for farmer
	--------------------------------------------	--------------------------------
	--------------------------------------------    --------------------------------
	*User_1("Farmer") Account Login Credentials*	->Farmer Accounts<-
    							*Farmer can login to account if created by employee
	Email: 		easym16@hotmail.com		*Farmer can create a profile with his data and upload profile picture
	Password:	Coding@1234?			*Farmer can create products and upload product picture
	--------------------------------------------	*Farmer can edit his profile including profile picture
	--------------------------------------------	*Farmer can edit a existing product 
	*User_2("Farmer") Account Login Credentials*	*Farmer can delete a product if desired
							*Farmer can Log Out from account
	Email: 		alexbrown@gmail.com
	Password:	WRdT231@$	
	--------------------------------------------
	--------------------------------------------
	*User_3("Farmer") Account Login Credentials*

	Email: 		jorgemanuel@gmail.com
	Password:	23rt3A##w@	
	--------------------------------------------
	--------------------------------------------
	
==========================================================================	
##-------------------------- Configuration -----------------------------##
==========================================================================

- **Azure Database Connection String**: The connection string for Azure 
Database is configured in the `appsettings.json`.

================================$$ END $$=================================
