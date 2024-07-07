using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.DTO;

namespace UserService.Interfaces {

    internal interface IUserRequest {
        // Creates a new user in the database.
        bool CreateUser(IDatabase database, IUser user);

        // Retrieves a list of all users from the database.
        List<User> ReadUsers(IDatabase database);

        // Updates an existing user's information in the database.
        bool UpdateUsers(IDatabase database, IUser user);

        // Deletes a user from the database by their ID.
        bool DeleteUsers(IDatabase database, int id);
    }
}
