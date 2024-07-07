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

![image](https://github.com/foldredd/UserTableWCFAndClient/assets/141770191/08f54553-c58a-440b-a1fc-54347591490e)
Main form with list of users 
![image](https://github.com/foldredd/UserTableWCFAndClient/assets/141770191/e82c942d-aa32-4d2a-9d55-c97fb87df150)
Add New Users

IIS:
![image](https://github.com/foldredd/UserTableWCFAndClient/assets/141770191/df41f43b-d52f-484b-8d73-1fdce9834383)

![image](https://github.com/foldredd/UserTableWCFAndClient/assets/141770191/ca1e6973-3398-47f1-8909-b7a0d6c7482e)

Database:
![image](https://github.com/foldredd/UserTableWCFAndClient/assets/141770191/947a5b0a-53d6-4bcd-86c9-2bb4957e2c9c)
Table Users




