using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Ninject;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalSmartCoding.Libraries;
using TotalCore.Repositories.Generals;
using TotalBase;
using TotalSmartCoding.Libraries.Helpers;


namespace TotalSmartCoding.Views.Mains
{
    public partial class ChangePassword : Form
    {
        public ChangePassword(bool checkPasswordOnly)
            : this()
        {
            this.buttonChange.Visible = false;
        }

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void PublicAuthenticationPassword_Load(object sender, EventArgs e)
        {
            try
            {
                UserAPIs userAPIs = new UserAPIs(CommonNinject.Kernel.Get<IUserAPIRepository>());
                this.textBoxCurrentPassword.Tag = userAPIs.GetPasswordHash(ContextAttributes.User.UserID);

                this.SetButtonEnabled();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private bool ValidPassword { get { return this.textBoxCurrentPassword.Text == (string)this.textBoxCurrentPassword.Tag; } }

        private void SetButtonEnabled()
        {
            this.buttonOK.Enabled = this.ValidPassword && this.textBoxCurrentPassword.Visible;
            this.buttonChange.Enabled = this.ValidPassword && this.textBoxNewPassword.Text == this.textBoxConfirmPassword.Text;
        }

        private void textBoxCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnabled();
        }

        private void textBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnabled();
        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnabled();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxCurrentPassword.Visible)
                {
                    this.textBoxCurrentPassword.Visible = false;
                    this.textBoxNewPassword.Visible = true;
                    this.textBoxConfirmPassword.Visible = true;
                    this.labelCurrentPassword.Visible = false;
                    this.labelNewPassword.Visible = true;
                    this.labelConfirmPassword.Visible = true;
                    this.SetButtonEnabled();
                    this.DialogResult = DialogResult.None;
                }
                //else
                //{
                //    SQLDatabase.ExecuteNonQuery("UPDATE ListEmployee SET Password = N'" + this.textBoxNewPassword.Text + "' WHERE EmployeeID = " + GlobalVariables.GlobalUserInformation.UserID);
                //}
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }



    }
}
