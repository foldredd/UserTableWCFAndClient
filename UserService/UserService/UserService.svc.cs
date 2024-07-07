using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UserService.DB;
using UserService.DTO;
using UserService.Interfaces;

namespace UserService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService {

        public string testingConnect() {
            IDatabase db = new DatabaseConnect();
            UserRequestService userRequestService = new UserRequestService();
           return userRequestService.TestingDB(db);
        }

        /*public int CountUser() {
            DatabaseConnect database = new DatabaseConnect();
            UserRequestService userRequestService = new UserRequestService();
           return userRequestService.CountUser(database);
        }
        public string testing() {
            DatabaseConnect database = new DatabaseConnect();
            return database.testc();
        }*/
        public string GetData(int value) {
            return string.Format("You entered: {0}", value);
        }
        public List<User> GetUsers() {
            IDatabase database = new DatabaseConnect();
            UserRequestService userRequestService = new UserRequestService();
           return userRequestService.ReadUsers(database);

        }
        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool Update(int id, string fullName, string tin, string email, string contactPhone) {
           IDatabase db = new DatabaseConnect();
            User user = new User(id,fullName,tin,email,contactPhone);
            UserRequestService userRequest = new UserRequestService();
            return userRequest.UpdateUsers(db, user);
        }

        public bool Create(string fullName, string tin, string email, string contactPhone) {
            IDatabase db = new DatabaseConnect();
            User user = new User(fullName,tin,email,contactPhone);
            UserRequestService userRequest = new UserRequestService();
           return userRequest.CreateUser(db, user);
        }

        public bool Delete(int id) {
            IDatabase db= new DatabaseConnect();
            UserRequestService userRequest = new UserRequestService();
            return userRequest.DeleteUsers(db, id);
        }
    }
}
