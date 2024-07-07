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
    public partial class DeleteUserForm : Form {
       
      

        private void label1_Click(object sender, EventArgs e) {

        }

        private void btnYes_Click(object sender, EventArgs e) {
            WcfService wcfService = new WcfService();
            wcfService.DeleteUser(id);
            CloseForm();
        }

        private void btnNo_Click(object sender, EventArgs e) {
            CloseForm();
        }
    }
}
