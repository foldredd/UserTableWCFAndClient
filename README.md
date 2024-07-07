# UserTableWCFAndClient

This repository contains 2 programs:

- **UserService**: WCF Service responsible for managing user data.
- **Art-Zvit**: Win Forms App client that interacts with UserService.

## Features Implemented:

### Win Forms App (Art-Zvit)

- Displaying a grid with user attributes: Full Name, TIN, Email, Contact Phone, Creation Date, Last Modified Date.
- Modal forms for editing and adding new users.
- Communication exclusively through the WCF Service to access and modify user data.

### WCF Service (UserService)

- Hosting on IIS for data exchange between the Win Forms App and the MSSQL database.
- Utilization of MSSQL without third-party components like BLToolkit for database access.
