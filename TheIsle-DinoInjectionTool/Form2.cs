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
            cboServerType.SelectedItem = "PingPerfect";
        }
        string strUsername;
        string strPassword;
        string strPort;
        string strFTPAddress;
        string strConnectPort;
        string strSelectedFolder;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboServerType.SelectedIndex != 2)
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
                    strSelectedFolder = txtSelectedFolder.Text;

                    ResetLabels();
                    ProfileSelect();
                    this.Hide();
                    return;
                }
            }            
            else
            {
                strUsername = txtUsername.Text;
                strPassword = txtPassword.Text;
                strPort = txtPort.Text;
                strFTPAddress = txtFTPAddress.Text;
                strConnectPort = txtConnectPort.Text;
                strSelectedFolder = txtSelectedFolder.Text;

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
                txtSelectedFolder.Clear();
                cboServerType.SelectedItem = "PingPerfect";
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
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType1 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer1 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 1:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe2 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer2 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 2:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe3 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer3 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 3:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe4 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer4 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Save();
                        break;

                    case 4:
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Port5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Username5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.Password5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe5 = false;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType5 = null;
                        TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer5 = null;
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
            txtSelectedFolder.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer1;

            if (TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType1 == null)
            {
                cboServerType.SelectedIndex = 0;
            }
            else
            {
                cboServerType.SelectedItem = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType1;
            }
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
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType1 = cboServerType.SelectedItem.ToString();
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer1 = txtSelectedFolder.Text;
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
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType2 = cboServerType.SelectedItem.ToString();
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer2 = txtSelectedFolder.Text;
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
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType3 = cboServerType.SelectedItem.ToString();
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer3 = txtSelectedFolder.Text;
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
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType4 = cboServerType.SelectedItem.ToString();
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer4 = txtSelectedFolder.Text;
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
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType5 = cboServerType.SelectedItem.ToString();
                    TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer5 = txtSelectedFolder.Text;
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
                    cboServerType.SelectedItem = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType1;
                    txtSelectedFolder.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer1;
                    break;

                case 1:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress2;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port2;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username2;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password2;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe2;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort2;
                    cboServerType.SelectedItem = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType2;
                    txtSelectedFolder.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer2;
                    break;

                case 2:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress3;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port3;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username3;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password3;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe3;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort3;
                    cboServerType.SelectedItem = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType3;
                    txtSelectedFolder.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer3;
                    break;

                case 3:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress4;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port4;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username4;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password4;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe4;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort4;
                    cboServerType.SelectedItem = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType4;
                    txtSelectedFolder.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer4;
                    break;

                case 4:
                    txtFTPAddress.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress5;
                    txtPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port5;
                    txtUsername.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username5;
                    txtPassword.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password5;
                    chkRememberMe.Checked = TheIsle_DinoInjectionTool.Properties.Settings.Default.RememberMe5;
                    txtConnectPort.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort5;
                    cboServerType.SelectedItem = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType5;
                    txtSelectedFolder.Text = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer5;
                    break;
            }

        }

        private void CboServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServerType.SelectedIndex == 2)
            {
                lblConnectPort.Visible = false;
                lblFTP.Visible = false;
                lblPassword.Visible = false;
                lblPort.Visible = false;
                lblRequired.Visible = false;
                lblUsername.Visible = false;
                txtConnectPort.Visible = false;
                txtFTPAddress.Visible = false;
                txtPassword.Visible = false;
                txtPort.Visible = false;
                txtUsername.Visible = false;

                btnSelectFolder.Visible = true;
                txtSelectedFolder.Visible = true;
            }
            else
            {
                lblConnectPort.Visible = true;
                lblFTP.Visible = true;
                lblPassword.Visible = true;
                lblPort.Visible = true;
                lblRequired.Visible = true;
                lblUsername.Visible = true;
                txtConnectPort.Visible = true;
                txtFTPAddress.Visible = true;
                txtPassword.Visible = true;
                txtPort.Visible = true;
                txtUsername.Visible = true;

                btnSelectFolder.Visible = false;
                txtSelectedFolder.Visible = false;
            }
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSelectedFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
