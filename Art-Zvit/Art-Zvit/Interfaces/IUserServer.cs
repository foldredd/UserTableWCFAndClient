using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Zvit.Interfaces {
    internal interface IUserServer {

        bool CreateUser(IUserViewModel user);

        bool DeleteUser(int id);

        List<IUserViewModel> getUsers();

         bool UpdateUser(IUserViewModel user);
    }
}
