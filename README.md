# Loan Repayment API
A back-end project built with C# / ASP.NET Core and a small C++ module.
# What it does 
- Stores loans in a SQlite database (Entity Framework Core)
- Rest endpoints to add and view loans
- Automatically calculates the monthly repayment
- A C++ command-line calculator that does the same repayment calculation
# Tech used
C#, .Net 10, ASP.NET Core Web API, Entity Framework Core, SQLite, C++, Git
# Run the API
cd LoanApi
dotnet run
Open http://localhost:5192/api/loans
# Endpoints
- GET /api/loans - list all loans
- GET /api/loans/{id} - get one loan
- POST /api/loans - add a loan
# Run the C++ calculator
cd CppCalculator
g++ loancalc.cpp -o loancalc
loancalc 500000 18 12
# Author
Akunna Susan Sunday