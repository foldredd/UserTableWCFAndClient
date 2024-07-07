using Art_Zvit.Interfaces;
using Art_Zvit.Model;
using System.Windows.Forms;

namespace Art_Zvit.Forms {
    partial class EditUserForm {
        private IUserViewModel userToEdit;
        private IUserViewModel userData;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox EditName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EditTIN;
        private System.Windows.Forms.TextBox EditEmail;
        private System.Windows.Forms.TextBox EditPhone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        public EditUserForm(IUserViewModel user) {
            InitializeComponent();
            userToEdit = user;
            userData = user;
            // Initialize form controls with user data
            this.EditName.Text = user.FullName;
            this.EditTIN.Text = user.TIN;
            this.EditEmail.Text = user.Email;
            this.EditPhone.Text = user.ContactPhone;
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.EditName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EditTIN = new System.Windows.Forms.TextBox();
            this.EditEmail = new System.Windows.Forms.TextBox();
            this.EditPhone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditName
            // 
            this.EditName.Location = new System.Drawing.Point(125, 62);
            this.EditName.Name = "EditName";
            this.EditName.Size = new System.Drawing.Size(144, 22);
            this.EditName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "FullName";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "TIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone";
            // 
            // EditTIN
            // 
            this.EditTIN.Location = new System.Drawing.Point(125, 96);
            this.EditTIN.Name = "EditTIN";
            this.EditTIN.Size = new System.Drawing.Size(144, 22);
            this.EditTIN.TabIndex = 5;
            // 
            // EditEmail
            // 
            this.EditEmail.Location = new System.Drawing.Point(125, 133);
            this.EditEmail.Name = "EditEmail";
            this.EditEmail.Size = new System.Drawing.Size(144, 22);
            this.EditEmail.TabIndex = 6;
            // 
            // EditPhone
            // 
            this.EditPhone.Location = new System.Drawing.Point(125, 166);
            this.EditPhone.Name = "EditPhone";
            this.EditPhone.Size = new System.Drawing.Size(144, 22);
            this.EditPhone.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(59, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(217, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 327);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.EditPhone);
            this.Controls.Add(this.EditEmail);
            this.Controls.Add(this.EditTIN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditName);
            this.Name = "EditUserForm";
            this.Text = "EditUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        #endregion

        public void CloseForm() {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}