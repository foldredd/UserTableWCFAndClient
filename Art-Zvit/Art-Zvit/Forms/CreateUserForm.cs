using Art_Zvit.Interfaces;
using Art_Zvit.Model;
using Art_Zvit.Services;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art_Zvit.Forms {
    public partial class CreateUserForm : Form {
        private readonly IUserViewModel userViewModel;
        public CreateUserForm() {
            InitializeComponent();
        }
        private void btnCreate_Click(object sender, EventArgs e) {
            try
            {
                // Check if all fields are filled
                if (string.IsNullOrWhiteSpace(CreateName.Text) ||
                    string.IsNullOrWhiteSpace(CreateTIN.Text) ||
                    string.IsNullOrWhiteSpace(CreateEmail.Text) ||
                    string.IsNullOrWhiteSpace(CreatePhone.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Validate TIN (9 digits)
                if (!IsTinValid(CreateTIN.Text.Trim()))
                {
                    MessageBox.Show("TIN must be 9 digits long.");
                    return;
                }

                // Validate phone number format 
                if (!IsPhoneNumberValid(CreatePhone.Text.Trim()))
                {
                    MessageBox.Show("Phone number must be in the format +X (XXX) XXX-XXXX.");
                    return;
                }


                IUserServer server = new WcfService();

                // Create a new IUserViewModel object with the entered data
                IUserViewModel user = new UserViewModel
                {
                    FullName = CreateName.Text.Trim(),
                    TIN = CreateTIN.Text.Trim(),
                    Email = CreateEmail.Text.Trim(),
                    ContactPhone = CreatePhone.Text.Trim(),
                    CreationDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                };

                // Call the server to create the user
                server.CreateUser(user);

                MessageBox.Show("User created successfully.");
                CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsTinValid(string tin) {
            return tin.Length == 9 && tin.All(char.IsDigit);
        }

        private bool IsPhoneNumberValid(string phoneNumber) {
            // Expected format: +1 (555) 123-4567
            string pattern = @"^\+\d \(\d{3}\) \d{3}-\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }



        private void btnCancel_Click(object sender, EventArgs e) {
            CloseForm();
        }
    }
}
