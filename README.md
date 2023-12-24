# Hệ thống dịch vụ sinh viên
## Introduction
The student service website assists in the management and resolution of student requests.

## Technologies Used
- ASP.NET 6 MVC: The core framework for building web applications with Model-View-Controller architecture.

- Entity Framework Core: An object-relational mapping (ORM) framework for .NET used for database interactions.

- C#: The primary programming language for building the application logic.

- HTML5 and CSS3: For structuring and styling the web pages.

- Bootstrap: A front-end framework for designing responsive and visually appealing user interfaces.

- JavaScript: Used for client-side scripting to enhance user interactions.

- SQL Server: The database management system employed for storing and managing data.

- Git: Version control system for tracking changes in the source code.

## Installation
1. Begin by cloning the project with the following command:
   `https://github.com/thevi31415/HeThongDichVuSinhVien_ASP.NET6_MVC.git`
2. Navigate to the  `appsettings.json` file and ensure the connection string is updated as follows:

    "ConnectionStrings": { "conn": "data source=your_server;initial  catalog=hethongdichvusinhvien;integrated security=true;TrustServerCertificate=True;encrypt=false" }
3. Remove the  `Migrations` folder from the project.
4. Open Tools > Package Manager > Package manager console
5. Execute the following two commands:
    ```
     (i) add-migration init
     (ii) update-database
     ````
6. You are now ready to launch the project.

## License

Copyright © 2023, [Nguyen Duong The Vi](https://github.com/thevi31415).
## References
- ASP.NET Documentation
- Entity Framework Core Documentation
- Bootstrap Documentation
