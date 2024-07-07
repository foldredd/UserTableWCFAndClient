using Art_Zvit.Interfaces; // Importing the IUserViewModel interface from Art_Zvit.Interfaces namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Zvit.Model {
    // Represents a view model for displaying and editing user data
    public class UserViewModel : IUserViewModel {
        // Default constructor
        public UserViewModel() { }

        // Parameterized constructor to initialize properties
        public UserViewModel(int iD, string fullName, string tIN, string email, string contactPhone, DateTime creationDate, DateTime lastModifiedDate) {
            ID = iD;
            FullName = fullName;
            TIN = tIN;
            Email = email;
            ContactPhone = contactPhone;
            CreationDate = creationDate;
            LastModifiedDate = lastModifiedDate;
        }

        // Properties of the user view model
        public int ID { get; set; } // Unique identifier for the user
        public string FullName { get; set; } // Full name of the user
        public string TIN { get; set; } // Tax Identification Number (TIN) of the user
        public string Email { get; set; } // Email address of the user
        public string ContactPhone { get; set; } // Contact phone number of the user
        public DateTime CreationDate { get; set; } // Date when the user was created
        public DateTime LastModifiedDate { get; set; } // Date when the user data was last modified

        // Method to update the current instance with data from another IUserViewModel instance
        IUserViewModel IUserViewModel.EditUser(IUserViewModel user) {
            // Update properties of the current instance with the provided IUserViewModel instance
            this.ID = user.ID;
            this.FullName = user.FullName;
            this.TIN = user.TIN;
            this.Email = user.Email;
            this.ContactPhone = user.ContactPhone;
            this.CreationDate = user.CreationDate;
            this.LastModifiedDate = user.LastModifiedDate;
            return this; // Return the updated instance
        }
    }
}
