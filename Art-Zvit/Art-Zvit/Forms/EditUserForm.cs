using Art_Zvit.Interfaces;
using Art_Zvit.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art_Zvit.Forms {
    public partial class EditUserForm : Form {
        public EditUserForm() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void btnSave_Click(object sender, EventArgs e) {
            try
            {
                // Check if all fields are filled
                if (string.IsNullOrWhiteSpace(EditName.Text) ||
                    string.IsNullOrWhiteSpace(EditTIN.Text) ||
                    string.IsNullOrWhiteSpace(EditEmail.Text) ||
                    string.IsNullOrWhiteSpace(EditPhone.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                IUserServer server = new WcfService();

                // Update userToEdit with new values
                userToEdit.FullName = EditName.Text.Trim();
                userToEdit.TIN = EditTIN.Text.Trim();
                userToEdit.Email = EditEmail.Text.Trim();
                userToEdit.ContactPhone = EditPhone.Text.Trim();

                // Call the server to update the user
                bool result = server.UpdateUser(userToEdit);

                if (result)
                {
                    MessageBox.Show("User updated successfully.");
                    CloseForm();
                }
                else
                {
                    MessageBox.Show("Failed to update user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e) {

        }
    }
}
