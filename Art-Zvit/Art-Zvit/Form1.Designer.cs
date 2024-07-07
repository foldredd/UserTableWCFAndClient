using Art_Zvit.Forms;
using Art_Zvit.Interfaces;
using Art_Zvit.Model;
using Art_Zvit.Services;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Art_Zvit {
    partial class Form1 : Form {
        private System.ComponentModel.IContainer components = null;
        private List<IUserViewModel> users;


        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitializeDataGridView();
            InitializeDataGridViewEvents();
            LoadUsers();
        }

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeDataGridView() {
            dataGridView1.AutoGenerateColumns = false;
            //Table creation
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Full name",
                DataPropertyName = "FullName",
                Name = "FullName"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TIN",
                DataPropertyName = "TIN",
                Name = "TIN"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                Name = "Email"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Contact phone",
                DataPropertyName = "ContactPhone",
                Name = "ContactPhone"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Creation date",
                DataPropertyName = "CreationDate",
                Name = "CreationDate"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Last Modified Date",
                DataPropertyName = "LastModifiedDate",
                Name = "LastModifiedDate"
            });

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Name = "EditButtonColumn",
                Text = "Изменить",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Name = "DeleteButtonColumn",
                Text = "Удалить",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(deleteButtonColumn);
        }

        private void LoadUsers() {
            try
            {
                IUserServer wcfService = new WcfService();
                users = wcfService.getUsers();
                dataGridView1.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeDataGridViewEvents() {
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            // Check if the clicked cell's row index is valid (greater than or equal to zero).
            if (e.RowIndex >= 0)
            {
                // Get the selected user from the bound data of the DataGridView row.
                var selectedUser = dataGridView1.Rows[e.RowIndex].DataBoundItem as UserViewModel;

                // Perform actions based on the clicked column name.
                switch (dataGridView1.Columns[e.ColumnIndex].Name)
                {
                    case "EditButtonColumn":
                        EditUser(selectedUser);
                        break;
                    case "DeleteButtonColumn":
                        DeleteUser(selectedUser.ID);
                        break;
                    default:
                        // Show a message box if a user (not an action button) cell is clicked.
                        if (selectedUser != null)
                        {
                            MessageBox.Show($"You have selected a user: {selectedUser.FullName}");
                        }
                        break;
                }
            }
        }


        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCreateUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1140, 372);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(166, 24);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(276, 44);
            this.btnCreateUser.TabIndex = 1;
            this.btnCreateUser.Text = "CreateUser";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 450);
            this.Controls.Add(this.btnCreateUser);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private void btnCreateUser_Click(object sender, EventArgs e) {
            CreateUser();
        }

        private void CreateUser() {
            using (var createForm = new CreateUserForm())
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                   
                }
            }
            LoadUsers(); 
        }

        private void DeleteUser(int id) {
            using (var deleteForm = new DeleteUserForm(id))
            {
                if (deleteForm.ShowDialog() == DialogResult.OK)
                {
                }
            }
            LoadUsers();
        }

        private void EditUser(IUserViewModel user) {
            using (var editForm = new EditUserForm(user))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // Updating the list after a change
                }
            }
        }

        private Button btnCreateUser;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
