using Art_Zvit.Interfaces;
using Art_Zvit.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserService.DTO;

namespace Art_Zvit.Services {
    // Implementation of IUserServer interface for WCF service operations
    internal class WcfService : IUserServer {
        // Creates a new user using data from IUserViewModel
        public bool CreateUser(IUserViewModel userModel) {
            // Using the UserServiceClient to interact with the WCF service
            using (var client = new UserServiceClient())
            {
                User user = new User
                {
                    FullName = userModel.FullName,
                    TIN = userModel.TIN,
                    Email = userModel.Email,
                    ContactPhone = userModel.ContactPhone
                };
                // Call the Create method on the WCF service client
                return client.Create(userModel.FullName, userModel.TIN, userModel.Email, userModel.ContactPhone);
            }
        }

        // Deletes a user by ID
        public bool DeleteUser(int id) {
            // Using the UserServiceClient to interact with the WCF service
            using (var client = new UserServiceClient())
            {
                // Call the Delete method on the WCF service client
                return client.Delete(id);
            }
        }

        // Tests the connection to the WCF service
        public string TestingConnect() {
            // Using the UserServiceClient to interact with the WCF service
            using (var client = new UserServiceClient())
            {
                // Call the testingConnect method on the WCF service client
                string result = client.testingConnect();
                return result;
            }
        }

        // Retrieves a list of IUserViewModel from the WCF service
        public List<IUserViewModel> getUsers() {
            List<IUserViewModel> userViewModels = new List<IUserViewModel>();
            try
            {
                // Using the UserServiceClient to interact with the WCF service
                using (var client = new UserServiceClient())
                {
                    // Call the GetUsers method on the WCF service client
                    var users = client.GetUsers();
                    foreach (var user in users)
                    {
                        // Map each User DTO to IUserViewModel
                        IUserViewModel viewModel = new UserViewModel
                        {
                            ID = user.ID,
                            FullName = user.FullName,
                            TIN = user.TIN,
                            Email = user.Email,
                            ContactPhone = user.ContactPhone,
                            CreationDate = user.CreationDate,
                            LastModifiedDate = user.LastModifiedDate
                        };
                        userViewModels.Add(viewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Display error message in case of exception
            }
            return userViewModels;
        }

        // Updates an existing user using data from IUserViewModel
        public bool UpdateUser(IUserViewModel userModel) {
            // Check if userModel is null
            if (userModel == null)
                return false;

            // Using the UserServiceClient to interact with the WCF service
            using (var client = new UserServiceClient())
            {
                User user = new User
                {
                    ID = userModel.ID,
                    FullName = userModel.FullName,
                    TIN = userModel.TIN,
                    Email = userModel.Email,
                    ContactPhone = userModel.ContactPhone,
                    CreationDate = userModel.CreationDate,
                    LastModifiedDate = DateTime.Now
                };
                // Call the Update method on the WCF service client
                bool result = client.Update(userModel.ID, userModel.FullName, userModel.TIN, userModel.Email, userModel.ContactPhone);
                return result;
            }
        }
    }
}
