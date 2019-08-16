using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Reflection;
using System.Threading;

namespace TheIsle_DinoInjectionTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            if (IsAlreadyRunning() == true)
            {
                MessageBox.Show("There is already an instance of DIT runnning.");
                Application.Exit();
            }
            rdoCarni.Checked = true;
            rdoSurvival.Checked = true;
            cboProfile.SelectedIndex = 0;
        }

        #region Global Variables
        string strFTPAddress = "";
        string strPassword = "";
        string strPort = "";
        string strUsername = "";
        string strConnectPort = "";
        string strSteamId = "";
        string strServerType = "";
        string strCustomServerFolder = "";

        string strClass = "";
        string strGrowth = "1.0";
        string strHunger = "99999";
        string strThirst = "99999";
        string strStam = "99999";
        string strHealth = "99999";
        string strBleedRate = "0";
        string strGender = "";
        string strLegBreak = "false";
        string strYPosition = "";
        decimal decYPosition = 0;
        bool bIsOpen = false;

        string strNewClass = "";
        string strNewGender = "";
        string strNewYPosition = "";

        //registry locations
        #endregion

        #region Routines
        private void EditSave()
        {
            GetCurrentSettings();
            try
            {
                string strDownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheIsle\\" + strSteamId + ".json";
                if (strServerType == "Custom Server")
                {
                    strDownloadPath = strCustomServerFolder + "\\" + strSteamId + ".json";
                }
                string text = File.ReadAllText(strDownloadPath);
                text = text.Replace(strClass, strNewClass);
                text = text.Replace("\t\"bGender\": " + strGender + ",", "\t\"bGender\": " + strNewGender + ",");
                text = text.Replace("\t\"Growth\": \"" + strGrowth + "\",", "\t\"Growth\": \"1.0\",");
                text = text.Replace("\t\"Hunger\": \"" + strHunger + "\",", "\t\"Hunger\": \"99999\",");
                text = text.Replace("\t\"Thirst\": \"" + strThirst + "\",", "\t\"Thirst\": \"99999\",");
                text = text.Replace("\t\"Stamina\": \"" + strStam + "\",", "\t\"Stamina\": \"99999\",");
                text = text.Replace("\t\"Health\": \"" + strHealth + "\",", "\t\"Health\": \"99999\",");
                text = text.Replace("\t\"BleedingRate\": \"" + strBleedRate + "\",", "\t\"BleedingRate\": \"0\",");
                text = text.Replace("\t\"bBrokenLegs\": " + strLegBreak + ",", "\t\"bBrokenLegs\": false,");
                text = text.Replace(strYPosition, strNewYPosition);
                File.WriteAllText(strDownloadPath, text);

                UploadSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Editing Save " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UploadSave()
        {
            string strPath = "";
            if (strServerType == "Custom Server")
            {
                bIsOpen = false;
                lblProgress.Text = "Upload Complete!";
            }
            else
            {
                if (strServerType == "Nitrado")
                {
                    strPath = "ftp://" + strUsername + "@" + strFTPAddress + "/theisle/TheIsle/Saved/Databases/Survival/Players/" + strSteamId + ".json";
                }
                else if (strServerType == "PingPerfect")
                {
                    strPath = "ftp://" + strFTPAddress + ":" + strPort + "/" + strFTPAddress + "_" + strConnectPort + "/TheIsle/Saved/Databases/Survival/Players/" + strSteamId + ".json";
                }
                string strDownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheIsle\\" + strSteamId + ".json";
                try
                {
                    FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(strPath);
                    ftpRequest.Credentials = new NetworkCredential(strUsername, strPassword);
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                    byte[] fileContent;

                    using (StreamReader sr = new StreamReader(strDownloadPath))
                    {
                        fileContent = Encoding.UTF8.GetBytes(sr.ReadToEnd());
                    }

                    using (Stream sw = ftpRequest.GetRequestStream())
                    {
                        sw.Write(fileContent, 0, fileContent.Length);
                    }

                    ftpRequest.GetResponse();

                    bIsOpen = false;
                    lblProgress.Text = "Upload Complete!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Uploading to FTP Server. Ensure Server Information and Steam ID is Correct " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        private void GetCurrentSettings()
        {
            switch (cboDinoList.SelectedItem)
            {
                case "Acro":
                    strNewClass = "Acro";
                    break;
                case "Albert":
                    strNewClass = "Albert";
                    break;
                case "Bary":
                    strNewClass = "Bary";
                    break;
                case "Herrera":
                    strNewClass = "Herrera";
                    break;
                case "Spino":
                    strNewClass = "Spino";
                    break;
                case "Velociraptor":
                    strNewClass = "Velociraptor";
                    break;
                case "Anky":
                    strNewClass = "Anky";
                    break;
                case "Austro":
                    strNewClass = "Austro";
                    break;
                case "Ava":
                    strNewClass = "Ava";
                    break;
                case "Camara":
                    strNewClass = "Camara";
                    break;
                case "Oro":
                    strNewClass = "Oro";
                    break;
                case "Taco":
                    strNewClass = "Taco";
                    break;
                case "Puerta":
                    strNewClass = "Puerta";
                    break;
                case "Shant":
                    strNewClass = "Shant";
                    break;
                case "Stego":
                    strNewClass = "Stego";
                    break;
                case "Theri":
                    strNewClass = "Theri";
                    break;
                case "Allo - Adult":
                    strNewClass = "AlloAdultS";
                    break;
                case "Allo - Juvie":
                    strNewClass = "AlloJuvS";
                    break;
                case "Allo - Hatchling":
                    strNewClass = "AlloHatchS";
                    break;
                case "Carno - Adult":
                    strNewClass = "CarnoAdultS";
                    break;
                case "Carno - Sub":
                    strNewClass = "CarnoSubS";
                    break;
                case "Carno - Juvie":
                    strNewClass = "CarnoJuvS";
                    break;
                case "Carno - Hatchling":
                    strNewClass = "CarnoHatchS";
                    break;
                case "Cerato - Adult":
                    strNewClass = "CeratoAdultS";
                    break;
                case "Cerato - Juvie":
                    strNewClass = "CeratoJuvS";
                    break;
                case "Cerato - Hatchling":
                    strNewClass = "CeratoHatchS";
                    break;
                case "Dilo - Adult":
                    strNewClass = "DiloAdultS";
                    break;
                case "Dilo - Juvie":
                    strNewClass = "DiloJuvS";
                    break;
                case "Dilo - Hatchling":
                    strNewClass = "DiloHatchS";
                    break;
                case "Giga - Adult":
                    strNewClass = "GigaAdultS";
                    break;
                case "Giga - Sub":
                    strNewClass = "GigaSubS";
                    break;
                case "Giga - Juvie":
                    strNewClass = "GigaJuvS";
                    break;
                case "Giga - Hatchling":
                    strNewClass = "GigaHatchS";
                    break;
                case "Sucho - Adult":
                    strNewClass = "SuchoAdultS";
                    break;
                case "Sucho - Juvie":
                    strNewClass = "SuchoJuvS";
                    break;
                case "Sucho - Hatchling":
                    strNewClass = "SuchoHatchS";
                    break;
                case "Rex - Adult":
                    strNewClass = "RexAdultS";
                    break;
                case "Rex - Sub":
                    strNewClass = "RexSubS";
                    break;
                case "Rex - Juvie":
                    strNewClass = "RexJuvS";
                    break;
                case "Utah - Adult":
                    strNewClass = "UtahAdultS";
                    break;
                case "Utah - Juvie":
                    strNewClass = "UtahJuvS";
                    break;
                case "Utah - Hatchling":
                    strNewClass = "UtahHatchS";
                    break;
                case "Diablo - Adult":
                    strNewClass = "DiabloAdultS";
                    break;
                case "Diablo - Juvie":
                    strNewClass = "DiabloJuvS";
                    break;
                case "Diablo - Hatchling":
                    strNewClass = "DiabloHatchS";
                    break;
                case "Dryo - Adult":
                    strNewClass = "DryoAdultS";
                    break;
                case "Dryo - Juvie":
                    strNewClass = "DryoJuvS";
                    break;
                case "Dryo - Hatchling":
                    strNewClass = "DryoHatchS";
                    break;
                case "Galli - Adult":
                    strNewClass = "GalliAdultS";
                    break;
                case "Galli - Juvie":
                    strNewClass = "GalliJuvS";
                    break;
                case "Galli - Hatchling":
                    strNewClass = "GalliHatchS";
                    break;
                case "Maia - Adult":
                    strNewClass = "MaiaAdultS";
                    break;
                case "Maia - Juvie":
                    strNewClass = "MaiaJuvS";
                    break;
                case "Maia - Hatchling":
                    strNewClass = "MaiaHatchS";
                    break;
                case "Pachy - Adult":
                    strNewClass = "PachyAdultS";
                    break;
                case "Pachy - Juvie":
                    strNewClass = "PachyJuvS";
                    break;
                case "Pachy - Hatchling":
                    strNewClass = "PachyHatchS";
                    break;
                case "Para - Adult":
                    strNewClass = "ParaAdultS";
                    break;
                case "Para - Juvie":
                    strNewClass = "ParaJuvS";
                    break;
                case "Para - Hatchling":
                    strNewClass = "ParaHatchS";
                    break;
                case "Trike - Adult":
                    strNewClass = "TrikeAdultS";
                    break;
                case "Trike - Sub":
                    strNewClass = "TrikeSubS";
                    break;
                case "Trike - Juvie":
                    strNewClass = "TrikeJuvS";
                    break;
                case "Trike - Hatchling":
                    strNewClass = "TrikeHatchS";
                    break;
            }

            switch (cboGender.SelectedItem)
            {
                case "Male":
                    strNewGender = "false";
                    break;
                case "Female":
                    strNewGender = "true";
                    break;
            }
        }
        private void ConnectToServer()
        {
            strSteamId = txtSteamID.Text;
            strSteamId = strSteamId.Trim(new char[] { ' ', '.' });
            string strDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheIsle";
            Directory.CreateDirectory(strDirPath);
            string strPath = "";
            if (strServerType == "Nitrado")
            {
                strPath = "ftp://" + strUsername + "@" + strFTPAddress + "/theisle/TheIsle/Saved/Databases/Survival/Players/" + strSteamId + ".json";
            }
            else if (strServerType == "PingPerfect")
            {
                strPath = "ftp://" + strFTPAddress + ":" + strPort + "/" + strFTPAddress + "_" + strConnectPort + "/TheIsle/Saved/Databases/Survival/Players/" + strSteamId + ".json";
            }
            string strDownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheIsle\\" + strSteamId + ".json";
            try
            {
                lblProgress.Visible = true;
                lblProgress.Text = "Downloading...";
                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential(strUsername, strPassword);
                    byte[] fileData = request.DownloadData(strPath);

                    using (FileStream file = File.Create(strDownloadPath))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                }
                ReadFile(strDownloadPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connecting to FTP Server. Ensure Server Information and Steam ID is Correct " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        private void ReadFile(string strPath)
        {
            try
            {
                lblProgress.Text = "Reading...";
                List<string> found = new List<string>();
                string line;
                using (StreamReader file = new StreamReader(strPath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("CharacterClass"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("bGender"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("Location"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("Growth"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("Hunger"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("Thirst"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("Stamina"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("Health"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("BleedingRate"))
                        {
                            found.Add(line);
                        }
                        if (line.Contains("bBrokenLegs"))
                        {
                            found.Add(line);
                        }
                    }
                }
                strClass = found[0];
                strGender = found[8];
                strYPosition = found[1];
                strGrowth = found[2];
                strHunger = found[3];
                strThirst = found[4];
                strStam = found[5];
                strHealth = found[6];
                strBleedRate = found[7];
                strLegBreak = found[9];

                FormatClass();
                FormatGender();
                FormatY();
                FormatGrowth();
                FormatHunger();
                FormatThirst();
                FormatStam();
                FormatHealth();
                FormatBleedRate();
                FormatLeg();
                SetControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading save file!" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetControls()
        {
            switch (strClass)
            {
                //Survival Carnivores
                case "AlloAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 0;
                    break;
                case "AlloJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 1;
                    break;
                case "AlloHatchS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 2;
                    break;
                case "CarnoAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 3;
                    break;
                case "CarnoSubS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 4;
                    break;
                case "CarnoJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 5;
                    break;
                case "CarnoHatchS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 6;
                    break;
                case "CeratoAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 7;
                    break;
                case "CeratoJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 8;
                    break;
                case "CeratoHatchS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 9;
                    break;
                case "DiloAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 10;
                    break;
                case "DiloJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 11;
                    break;
                case "DiloHatchS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 12;
                    break;
                case "GigaAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 13;
                    break;
                case "GigaSubS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 14;
                    break;
                case "GigaJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 15;
                    break;
                case "GigaHatchS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 16;
                    break;
                case "SuchoAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 17;
                    break;
                case "SuchoJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 18;
                    break;
                case "SuchoHatchS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 19;
                    break;
                case "RexAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 20;
                    break;
                case "RexSubS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 21;
                    break;
                case "RexJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 22;
                    break;
                case "UtahAdultS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 23;
                    break;
                case "UtahJuvS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 24;
                    break;
                case "UtahHatchS":
                    rdoCarni.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 25;
                    break;


                //Survival Herbies

                case "DiabloAdultS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 0;
                    break;
                case "DiabloJuvS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 1;
                    break;
                case "DiabloHatchS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 2;
                    break;
                case "DryoAdultS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 3;
                    break;
                case "DryoJuvS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 4;
                    break;
                case "DryoHatchS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 5;
                    break;
                case "GalliAdultS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 6;
                    break;
                case "GalliJuvS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 7;
                    break;
                case "GalliHatchS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 8;
                    break;
                case "MaiaAdult":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 9;
                    break;
                case "MaiaJuvS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 10;
                    break;
                case "MaiaHatchS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 11;
                    break;
                case "PachyAdultS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 12;
                    break;
                case "PachyJuvS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 13;
                    break;
                case "PachyHatchS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 14;
                    break;
                case "ParaAdultS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 15;
                    break;
                case "ParaJuvS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 16;
                    break;
                case "ParaHatchS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 17;
                    break;
                case "TrikeAdultS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 18;
                    break;
                case "TrikeSubS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 19;
                    break;
                case "TrikeJuvS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 20;
                    break;
                case "TrikeHatchS":
                    rdoHerbi.Checked = true;
                    rdoSurvival.Checked = true;
                    cboDinoList.SelectedIndex = 21;
                    break;

                //Non-Survival Carnis

                case "Acro":
                    rdoCarni.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 0;
                    break;
                case "Albert":
                    rdoCarni.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 1;
                    break;
                case "Austro":
                    rdoCarni.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 2;
                    break;
                case "Bary":
                    rdoCarni.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 3;
                    break;
                case "Herrera":
                    rdoCarni.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 4;
                    break;
                case "Spino":
                    rdoCarni.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 5;
                    break;
                case "Velociraptor":
                    rdoCarni.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 6;
                    break;

                //Non-Survival Herbis

                case "Anky":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 0;
                    break;
                case "Ava":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 1;
                    break;
                case "Camara":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 2;
                    break;
                case "Oro":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 3;
                    break;
                case "Taco":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 4;
                    break;
                case "Puerta":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 5;
                    break;
                case "Shant":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 6;
                    break;
                case "Stego":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 7;
                    break;
                case "Theri":
                    rdoHerbi.Checked = true;
                    rdoSandbox.Checked = true;
                    cboDinoList.SelectedIndex = 8;
                    break;

            }

            switch (strGender)
            {
                case "false":
                    cboGender.SelectedIndex = 0;
                    break;
                case "true":
                    cboGender.SelectedIndex = 1;
                    break;

            }
            bIsOpen = true;
            lblProgress.Visible = true;
            lblProgress.Text = "Save Opened!";
        }        
        #endregion

        #region String Formatting
        private void FormatClass()
        {
            string strRemoveStart = "\t\"CharacterClass\": \"";
            string strRemoveEnd = "\",";
            strClass = strClass.Replace(strRemoveStart, "");
            strClass = strClass.Replace(strRemoveEnd, "");
        }
        private void FormatGender()
        {
            string strRemoveStart = "\t\"bGender\": ";
            string strRemoveEnd = ",";
            strGender = strGender.Replace(strRemoveStart, "");
            strGender = strGender.Replace(strRemoveEnd, "");
        }
        private void FormatY()
        {
            bool b = strYPosition.Contains("Y=-");

            if (b)
            {
                int index = strYPosition.IndexOf("Y=-");
                string strSub;
                strSub = strYPosition.Substring(index + 3, 6);
                if (strSub.Contains("."))
                {
                    int i = strSub.LastIndexOf(".");
                    if (i > 0)
                    {
                        strSub = strSub.Substring(0, i);
                    }
                }
                int len = strSub.Length;
                bool dec = Decimal.TryParse(strSub, out decYPosition);

                decYPosition = decYPosition + 3;

                strNewYPosition = strYPosition.Replace(strYPosition.Substring(index + 2, len), decYPosition.ToString());
            }
            else
            {
                int index = strYPosition.IndexOf("Y=");
                string strSub;
                strSub = strYPosition.Substring(index + 2, 6);
                if (strSub.Contains("."))
                {
                    int i = strSub.LastIndexOf(".");
                    if (i > 0)
                    {
                        strSub = strSub.Substring(0, i);
                    }
                }
                int len = strSub.Length;
                bool dec = Decimal.TryParse(strSub, out decYPosition);

                decYPosition = decYPosition + 3;

                strNewYPosition = strYPosition.Replace(strYPosition.Substring(index + 2, len), decYPosition.ToString());
            }
        }
        private void FormatGrowth()
        {
            string strRemoveStart = "\t\"Growth\": \"";
            string strRemoveEnd = "\",";
            strGrowth = strGrowth.Replace(strRemoveStart, "");
            strGrowth = strGrowth.Replace(strRemoveEnd, "");
        }
        private void FormatHunger()
        {
            string strRemoveStart = "\t\"Hunger\": \"";
            string strRemoveEnd = "\",";
            strHunger = strHunger.Replace(strRemoveStart, "");
            strHunger = strHunger.Replace(strRemoveEnd, "");
        }
        private void FormatThirst()
        {
            string strRemoveStart = "\t\"Thirst\": \"";
            string strRemoveEnd = "\",";
            strThirst = strThirst.Replace(strRemoveStart, "");
            strThirst = strThirst.Replace(strRemoveEnd, "");
        }
        private void FormatStam()
        {
            string strRemoveStart = "\t\"Stamina\": \"";
            string strRemoveEnd = "\",";
            strStam = strStam.Replace(strRemoveStart, "");
            strStam = strStam.Replace(strRemoveEnd, "");
        }
        private void FormatHealth()
        {
            string strRemoveStart = "\t\"Health\": \"";
            string strRemoveEnd = "\",";
            strHealth = strHealth.Replace(strRemoveStart, "");
            strHealth = strHealth.Replace(strRemoveEnd, "");
        }
        private void FormatBleedRate()
        {
            string strRemoveStart = "\t\"BleedingRate\": \"";
            string strRemoveEnd = "\",";
            strBleedRate = strBleedRate.Replace(strRemoveStart, "");
            strBleedRate = strBleedRate.Replace(strRemoveEnd, "");
        }
        private void FormatLeg()
        {
            string strRemoveStart = "\t\"bBrokenLegs\": ";
            string strRemoveEnd = ",";
            strLegBreak = strGrowth.Replace(strRemoveStart, "");
            strLegBreak = strGrowth.Replace(strRemoveEnd, "");
        }
        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            Mutex mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }
        #endregion

        #region Radio Buttons
        private void rdoSandbox_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSandbox.Checked == true && rdoCarni.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Acro");
                cboDinoList.Items.Add("Albert");
                cboDinoList.Items.Add("Austro");
                cboDinoList.Items.Add("Bary");
                cboDinoList.Items.Add("Herrera");
                cboDinoList.Items.Add("Spino");
                cboDinoList.Items.Add("Velociraptor");
            }
            if (rdoSandbox.Checked == true && rdoHerbi.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Anky");
                cboDinoList.Items.Add("Ava");
                cboDinoList.Items.Add("Camara");
                cboDinoList.Items.Add("Oro");
                cboDinoList.Items.Add("Taco");
                cboDinoList.Items.Add("Puerta");
                cboDinoList.Items.Add("Shant");
                cboDinoList.Items.Add("Stego");
                cboDinoList.Items.Add("Theri");
            }
        }

        private void rdoSurvival_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSurvival.Checked == true && rdoCarni.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Allo - Adult");
                cboDinoList.Items.Add("Allo - Juvie");
                cboDinoList.Items.Add("Allo - Hatchling");
                cboDinoList.Items.Add("Carno - Adult");
                cboDinoList.Items.Add("Carno - Sub");
                cboDinoList.Items.Add("Carno - Juvie");
                cboDinoList.Items.Add("Carno - Hatchling");
                cboDinoList.Items.Add("Cerato - Adult");
                cboDinoList.Items.Add("Cerato - Juvie");
                cboDinoList.Items.Add("Cerato - Hatchling");
                cboDinoList.Items.Add("Dilo - Adult");
                cboDinoList.Items.Add("Dilo - Juvie");
                cboDinoList.Items.Add("Dilo - Hatchling");
                cboDinoList.Items.Add("Giga - Adult");
                cboDinoList.Items.Add("Giga - Sub");
                cboDinoList.Items.Add("Giga - Juvie");
                cboDinoList.Items.Add("Giga - Hatchling");
                cboDinoList.Items.Add("Sucho - Adult");
                cboDinoList.Items.Add("Sucho - Juvie");
                cboDinoList.Items.Add("Sucho - Hatchling");
                cboDinoList.Items.Add("Rex - Adult");
                cboDinoList.Items.Add("Rex - Sub");
                cboDinoList.Items.Add("Rex - Juvie");
                cboDinoList.Items.Add("Utah - Adult");
                cboDinoList.Items.Add("Utah - Juvie");
                cboDinoList.Items.Add("Utah - Hatchling");
            }
            if (rdoSurvival.Checked == true && rdoHerbi.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Diablo - Adult");
                cboDinoList.Items.Add("Diablo - Juvie");
                cboDinoList.Items.Add("Diablo - Hatchling");
                cboDinoList.Items.Add("Dryo - Adult");
                cboDinoList.Items.Add("Dryo - Juvie");
                cboDinoList.Items.Add("Dryo - Hatchling");
                cboDinoList.Items.Add("Galli - Adult");
                cboDinoList.Items.Add("Galli - Juvie");
                cboDinoList.Items.Add("Galli - Hatchling");
                cboDinoList.Items.Add("Maia - Adult");
                cboDinoList.Items.Add("Maia - Juvie");
                cboDinoList.Items.Add("Maia - Hatchling");
                cboDinoList.Items.Add("Pachy - Adult");
                cboDinoList.Items.Add("Pachy - Juvie");
                cboDinoList.Items.Add("Pachy - Hatchling");
                cboDinoList.Items.Add("Para - Adult");
                cboDinoList.Items.Add("Para - Juvie");
                cboDinoList.Items.Add("Para - Hatchling");
                cboDinoList.Items.Add("Trike - Adult");
                cboDinoList.Items.Add("Trike - Sub");
                cboDinoList.Items.Add("Trike - Juvie");
                cboDinoList.Items.Add("Trike - Hatchling");
            }
        }

        private void rdoCarni_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCarni.Checked == true && rdoSandbox.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Acro");
                cboDinoList.Items.Add("Albert");
                cboDinoList.Items.Add("Austro");
                cboDinoList.Items.Add("Bary");
                cboDinoList.Items.Add("Herrera");
                cboDinoList.Items.Add("Spino");
                cboDinoList.Items.Add("Velociraptor");
            }
            if (rdoCarni.Checked == true && rdoSurvival.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Allo - Adult");
                cboDinoList.Items.Add("Allo - Juvie");
                cboDinoList.Items.Add("Allo - Hatchling");
                cboDinoList.Items.Add("Carno - Adult");
                cboDinoList.Items.Add("Carno - Sub");
                cboDinoList.Items.Add("Carno - Juvie");
                cboDinoList.Items.Add("Carno - Hatchling");
                cboDinoList.Items.Add("Cerato - Adult");
                cboDinoList.Items.Add("Cerato - Juvie");
                cboDinoList.Items.Add("Cerato - Hatchling");
                cboDinoList.Items.Add("Dilo - Adult");
                cboDinoList.Items.Add("Dilo - Juvie");
                cboDinoList.Items.Add("Dilo - Hatchling");
                cboDinoList.Items.Add("Giga - Adult");
                cboDinoList.Items.Add("Giga - Sub");
                cboDinoList.Items.Add("Giga - Juvie");
                cboDinoList.Items.Add("Giga - Hatchling");
                cboDinoList.Items.Add("Sucho - Adult");
                cboDinoList.Items.Add("Sucho - Juvie");
                cboDinoList.Items.Add("Sucho - Hatchling");
                cboDinoList.Items.Add("Rex - Adult");
                cboDinoList.Items.Add("Rex - Sub");
                cboDinoList.Items.Add("Rex - Juvie");
                cboDinoList.Items.Add("Utah - Adult");
                cboDinoList.Items.Add("Utah - Juvie");
                cboDinoList.Items.Add("Utah - Hatchling");
            }
        }

        private void rdoHerbi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHerbi.Checked == true && rdoSandbox.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Anky");
                cboDinoList.Items.Add("Ava");
                cboDinoList.Items.Add("Camara");
                cboDinoList.Items.Add("Oro");
                cboDinoList.Items.Add("Taco");
                cboDinoList.Items.Add("Puerta");
                cboDinoList.Items.Add("Shant");
                cboDinoList.Items.Add("Stego");
                cboDinoList.Items.Add("Theri");
            }
            if (rdoHerbi.Checked == true && rdoSurvival.Checked == true)
            {
                cboDinoList.Items.Clear();
                cboDinoList.Items.Add("Diablo - Adult");
                cboDinoList.Items.Add("Diablo - Juvie");
                cboDinoList.Items.Add("Diablo - Hatchling");
                cboDinoList.Items.Add("Dryo - Adult");
                cboDinoList.Items.Add("Dryo - Juvie");
                cboDinoList.Items.Add("Dryo - Hatchling");
                cboDinoList.Items.Add("Galli - Adult");
                cboDinoList.Items.Add("Galli - Juvie");
                cboDinoList.Items.Add("Galli - Hatchling");
                cboDinoList.Items.Add("Maia - Adult");
                cboDinoList.Items.Add("Maia - Juvie");
                cboDinoList.Items.Add("Maia - Hatchling");
                cboDinoList.Items.Add("Pachy - Adult");
                cboDinoList.Items.Add("Pachy - Juvie");
                cboDinoList.Items.Add("Pachy - Hatchling");
                cboDinoList.Items.Add("Para - Adult");
                cboDinoList.Items.Add("Para - Juvie");
                cboDinoList.Items.Add("Para - Hatchling");
                cboDinoList.Items.Add("Trike - Adult");
                cboDinoList.Items.Add("Trike - Sub");
                cboDinoList.Items.Add("Trike - Juvie");
                cboDinoList.Items.Add("Trike - Hatchling");
            }
        }

        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bIsOpen == false)
            {
                MessageBox.Show("Error: Open the Steam ID first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                EditSave();
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            lblProgress.Visible = false;
            switch (cboProfile.SelectedIndex)
            {
                case 0:
                    strUsername = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username;
                    strPassword = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password;
                    strPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port;
                    strFTPAddress = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress;
                    strConnectPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort;
                    strServerType = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType1;
                    strCustomServerFolder = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer1;
                    break;
                case 1:
                    strUsername = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username2;
                    strPassword = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password2;
                    strPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port2;
                    strFTPAddress = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress2;
                    strConnectPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort2;
                    strServerType = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType2;
                    strCustomServerFolder = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer2;
                    break;
                case 2:
                    strUsername = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username3;
                    strPassword = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password3;
                    strPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port3;
                    strFTPAddress = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress3;
                    strConnectPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort3;
                    strServerType = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType3;
                    strCustomServerFolder = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer3;
                    break;
                case 3:
                    strUsername = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username4;
                    strPassword = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password4;
                    strPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port4;
                    strFTPAddress = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress4;
                    strConnectPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort4;
                    strServerType = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType4;
                    strCustomServerFolder = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer4;
                    break;
                case 4:
                    strUsername = TheIsle_DinoInjectionTool.Properties.Settings.Default.Username5;
                    strPassword = TheIsle_DinoInjectionTool.Properties.Settings.Default.Password5;
                    strPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.Port5;
                    strFTPAddress = TheIsle_DinoInjectionTool.Properties.Settings.Default.FTPAddress5;
                    strConnectPort = TheIsle_DinoInjectionTool.Properties.Settings.Default.ConnectPort5;
                    strServerType = TheIsle_DinoInjectionTool.Properties.Settings.Default.ServerType5;
                    strCustomServerFolder = TheIsle_DinoInjectionTool.Properties.Settings.Default.CustomServer5;
                    break;
            }

            if (strServerType != "Custom Server" && (string.IsNullOrWhiteSpace(strUsername) || string.IsNullOrWhiteSpace(strPort) || string.IsNullOrWhiteSpace(strFTPAddress) || string.IsNullOrWhiteSpace(strPassword) || string.IsNullOrWhiteSpace(strConnectPort)))
            {
                Form options = new frmOptions();
                options.StartPosition = FormStartPosition.CenterParent;
                options.ShowDialog();
            }
            else if (strServerType == "Custom Server" && string.IsNullOrWhiteSpace(strCustomServerFolder))
            {
                Form options = new frmOptions();
                options.StartPosition = FormStartPosition.CenterParent;
                options.ShowDialog();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtSteamID.Text))
                {
                    MessageBox.Show("Enter Steam ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (strServerType == "Custom Server")
                {
                    strSteamId = txtSteamID.Text;
                    strSteamId = strSteamId.Trim(new char[] { ' ', '.' });
                    ReadFile(strCustomServerFolder + "\\" + strSteamId + ".json");
                }
                else
                {
                    ConnectToServer();
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form options = new frmOptions();
            options.StartPosition = FormStartPosition.CenterParent;
            options.ShowDialog();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblProgress.Visible = false;
            rdoCarni.Checked = true;
            rdoSurvival.Checked = true;
            cboDinoList.SelectedIndex = 0;
            cboGender.SelectedIndex = 0;
            txtSteamID.Clear();
            txtSteamID.Focus();
            bIsOpen = false;
        }
        private void cmdAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DIT - Dino Injection Tool" + Environment.NewLine + "By Phobia#0001" + Environment.NewLine + "App Version: 1.3", "About");
        }
        private void youtubeTutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=hON9ov5zt_Q");
        }
        private void officialDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/dtHw4gn");
        }

        #endregion


    }

}
