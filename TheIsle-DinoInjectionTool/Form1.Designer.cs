namespace TheIsle_DinoInjectionTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
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
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtSteamID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDinoList = new System.Windows.Forms.ComboBox();
            this.lblDinoType = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.rdoHerbi = new System.Windows.Forms.RadioButton();
            this.rdoCarni = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSandbox = new System.Windows.Forms.RadioButton();
            this.rdoSurvival = new System.Windows.Forms.RadioButton();
            this.cboProfile = new System.Windows.Forms.ComboBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cmdAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.cmdAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(314, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(227, 74);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtSteamID
            // 
            this.txtSteamID.Location = new System.Drawing.Point(82, 76);
            this.txtSteamID.Name = "txtSteamID";
            this.txtSteamID.Size = new System.Drawing.Size(132, 20);
            this.txtSteamID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Steam ID:";
            // 
            // cboDinoList
            // 
            this.cboDinoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDinoList.FormattingEnabled = true;
            this.cboDinoList.Location = new System.Drawing.Point(129, 178);
            this.cboDinoList.Name = "cboDinoList";
            this.cboDinoList.Size = new System.Drawing.Size(121, 21);
            this.cboDinoList.TabIndex = 7;
            // 
            // lblDinoType
            // 
            this.lblDinoType.AutoSize = true;
            this.lblDinoType.Location = new System.Drawing.Point(64, 181);
            this.lblDinoType.Name = "lblDinoType";
            this.lblDinoType.Size = new System.Drawing.Size(59, 13);
            this.lblDinoType.TabIndex = 6;
            this.lblDinoType.Text = "Dino Type:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(81, 221);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 8;
            this.lblGender.Text = "Gender:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(78, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(161, 265);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cboGender.Location = new System.Drawing.Point(129, 218);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(121, 21);
            this.cboGender.TabIndex = 9;
            // 
            // rdoHerbi
            // 
            this.rdoHerbi.AutoSize = true;
            this.rdoHerbi.Location = new System.Drawing.Point(82, 16);
            this.rdoHerbi.Name = "rdoHerbi";
            this.rdoHerbi.Size = new System.Drawing.Size(71, 17);
            this.rdoHerbi.TabIndex = 1;
            this.rdoHerbi.TabStop = true;
            this.rdoHerbi.Text = "Herbivore";
            this.rdoHerbi.UseVisualStyleBackColor = true;
            this.rdoHerbi.CheckedChanged += new System.EventHandler(this.rdoHerbi_CheckedChanged);
            // 
            // rdoCarni
            // 
            this.rdoCarni.AutoSize = true;
            this.rdoCarni.Location = new System.Drawing.Point(6, 16);
            this.rdoCarni.Name = "rdoCarni";
            this.rdoCarni.Size = new System.Drawing.Size(70, 17);
            this.rdoCarni.TabIndex = 0;
            this.rdoCarni.TabStop = true;
            this.rdoCarni.Text = "Carnivore";
            this.rdoCarni.UseVisualStyleBackColor = true;
            this.rdoCarni.CheckedChanged += new System.EventHandler(this.rdoCarni_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoHerbi);
            this.groupBox1.Controls.Add(this.rdoCarni);
            this.groupBox1.Location = new System.Drawing.Point(67, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 39);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSandbox);
            this.groupBox2.Controls.Add(this.rdoSurvival);
            this.groupBox2.Location = new System.Drawing.Point(67, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 39);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rdoSandbox
            // 
            this.rdoSandbox.AutoSize = true;
            this.rdoSandbox.Location = new System.Drawing.Point(82, 16);
            this.rdoSandbox.Name = "rdoSandbox";
            this.rdoSandbox.Size = new System.Drawing.Size(67, 17);
            this.rdoSandbox.TabIndex = 1;
            this.rdoSandbox.TabStop = true;
            this.rdoSandbox.Text = "Sandbox";
            this.rdoSandbox.UseVisualStyleBackColor = true;
            this.rdoSandbox.CheckedChanged += new System.EventHandler(this.rdoSandbox_CheckedChanged);
            // 
            // rdoSurvival
            // 
            this.rdoSurvival.AutoSize = true;
            this.rdoSurvival.Location = new System.Drawing.Point(6, 16);
            this.rdoSurvival.Name = "rdoSurvival";
            this.rdoSurvival.Size = new System.Drawing.Size(63, 17);
            this.rdoSurvival.TabIndex = 0;
            this.rdoSurvival.TabStop = true;
            this.rdoSurvival.Text = "Survival";
            this.rdoSurvival.UseVisualStyleBackColor = true;
            this.rdoSurvival.CheckedChanged += new System.EventHandler(this.rdoSurvival_CheckedChanged);
            // 
            // cboProfile
            // 
            this.cboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfile.FormattingEnabled = true;
            this.cboProfile.Items.AddRange(new object[] {
            "Profile 1",
            "Profile 2",
            "Profile 3",
            "Profile 4",
            "Profile 5"});
            this.cboProfile.Location = new System.Drawing.Point(97, 36);
            this.cboProfile.Name = "cboProfile";
            this.cboProfile.Size = new System.Drawing.Size(121, 21);
            this.cboProfile.TabIndex = 12;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(128, 249);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(58, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "lblProgress";
            this.lblProgress.Visible = false;
            // 
            // cmdAbout
            // 
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(52, 20);
            this.cmdAbout.Text = "&About";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(314, 309);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.cboProfile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblDinoType);
            this.Controls.Add(this.cboDinoList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSteamID);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Isle - Dino Injection Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtSteamID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDinoList;
        private System.Windows.Forms.Label lblDinoType;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.RadioButton rdoHerbi;
        private System.Windows.Forms.RadioButton rdoCarni;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSandbox;
        private System.Windows.Forms.RadioButton rdoSurvival;
        private System.Windows.Forms.ComboBox cboProfile;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ToolStripMenuItem cmdAbout;
    }
}

