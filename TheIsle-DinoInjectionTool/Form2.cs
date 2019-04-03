using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheIsle_DinoInjectionTool
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
            txtFTPAddress.Focus();
            cboProfile.SelectedIndex = 0;
        }
        string strUsername;
        string strPassword;
        string strPort;
        string strFTPAddress;
        string strConnectPort;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFTPAddress.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPort.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtConnectPort.Text))
            {
                lblRequired.Visible = true;
                if (string.IsNullOrWhiteSpace(txtFTPAddress.Text))
                {
                    lblFTP.Text = "*FTP IP:";
                    lblFTP.ForeColor = Color.Red;
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblPassword.Text = "*Password:";
                    lblPassword.ForeColor = Color.Red;
                }
                if (string.IsNullOrWhiteSpace(txtPort.Text))
                {
                    lblPort.Text = "*FTP Port:";
                    lblPort.ForeColor = Color.Red;
                }
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    lblUsername.Text = "*Username:";
                    lblUsername.ForeColor = Color.Red;
                }
                if (string.IsNullOrWhiteSpace(txtConnectPort.Text))
                {
                    lblConnectPort.Text = "*Connection Port:";
                    lblConnectPort.ForeColor = Color.Red;
                }
            }
            else
            {
                strUsername = txtUsername.Text;
                strPassword = txtPassword.Text;
                strPort = txtPort.Text;
                strFTPAddress = txtFTPAddress.Text;
                strConnectPort = txtConnectPort.Text;

                ResetLabels();
                ProfileSelect();                
                this.Hide();
            }
        }

        private void ResetLabels()
        {
            lblRequired.Visible = false;
            lblFTP.Text = "FTP IP:";
            lblFTP.ForeColor = Color.Black;
            lblPassword.Text = "Password:";
            lblPassword.ForeColor = Color.Black;
            lblPort.Text = "FTP Port:";
            lblPort.ForeColor = Color.Black;
            lblUsername.Text = "Username:";
            lblUsername.ForeColor = Color.Black;
            lblConnectPort.Text = "Connection Port:";
            lblConnectPort.ForeColor = Color.Black;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetLabels();
            DialogResult result = MessageBox.Show("Do you want to delete this profile?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                txtFTPAddress.Clear();
                txtPassword.Clear();
                txtPort.Clear();
                txtUsername.Clear();
                txtFTPAddress.Focus();
                chkRememberMe.CheckState = CheckState.Unchecked;

                switch(cboProfile.SelectedIndex)
                {
                    case 0:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 1:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe2 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 2:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe3 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 3:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe4 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 4:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe5 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;
                }
                
            }
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress;
            txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port;
            txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username;
            txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password;
            chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe;
            txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort;
        }

        private void ProfileSelect()
        {
            switch (cboProfile.SelectedIndex)
            {
                case 0:
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress = strFTPAddress;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Port = strPort;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Username = strUsername;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Password = strPassword;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort = strConnectPort;
                    if (chkRememberMe.Checked)
                    {
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe = true;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                    }
                    break;

                case 1:
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress2 = strFTPAddress;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Port2 = strPort;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Username2 = strUsername;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Password2 = strPassword;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort2 = strConnectPort;
                    if (chkRememberMe.Checked)
                    {
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe2 = true;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                    }
                    break;

                case 2:
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress3 = strFTPAddress;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Port3 = strPort;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Username3 = strUsername;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Password3 = strPassword;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort3 = strConnectPort;
                    if (chkRememberMe.Checked)
                    {
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe3 = true;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                    }
                    break;

                case 3:
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress4 = strFTPAddress;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Port4 = strPort;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Username4 = strUsername;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Password4 = strPassword;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort4 = strConnectPort;
                    if (chkRememberMe.Checked)
                    {
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe4 = true;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                    }
                    break;

                case 4:
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress5 = strFTPAddress;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Port5 = strPort;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Username5 = strUsername;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.Password5 = strPassword;
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort5 = strConnectPort;
                    if (chkRememberMe.Checked)
                    {
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe5 = true;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                    }
                    break;
            }
        }

        private void cboProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboProfile.SelectedIndex)
            {
                case 0:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort;
                    break;

                case 1:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress2;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port2;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username2;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password2;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe2;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort2;
                    break;

                case 2:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress3;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port3;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username3;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password3;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe3;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort3;
                    break;

                case 3:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress4;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port4;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username4;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password4;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe4;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort4;
                    break;

                case 4:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress5;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port5;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username5;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password5;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe5;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort5;
                    break;
            }

        }
    }
}
