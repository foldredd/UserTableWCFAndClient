using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Zvit.Interfaces {
    // Interface defining properties and methods for a user view model
    public interface IUserViewModel {
        int ID { get; set; } // Unique identifier for the user
        string FullName { get; set; } // Full name of the user
        string TIN { get; set; } // Tax Identification Number (TIN) of the user
        string Email { get; set; } // Email address of the user
        string ContactPhone { get; set; } // Contact phone number of the user
        DateTime CreationDate { get; set; } // Date when the user was created
        DateTime LastModifiedDate { get; set; } // Date when the user data was last modified

        // Method to update the current instance with data from another IUserViewModel instance
        IUserViewModel EditUser(IUserViewModel user);
    }
}
