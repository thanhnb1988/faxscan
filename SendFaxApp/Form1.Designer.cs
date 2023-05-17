namespace SendFaxApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblHostName = new Label();
            txtHostName = new TextBox();
            btnTestFAX = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lblFolderSelected = new Label();
            btnBrowserFolder = new Button();
            label11 = new Label();
            label4 = new Label();
            txtSenderCompany = new TextBox();
            label3 = new Label();
            txtSenderName = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            txtClientSecret = new TextBox();
            label14 = new Label();
            txtClientID = new TextBox();
            label13 = new Label();
            txtDomainHeader = new TextBox();
            label12 = new Label();
            txtApiUrl = new TextBox();
            label1 = new Label();
            lblWebSocketSatus = new Label();
            btnLogin = new Button();
            label5 = new Label();
            tabPage4 = new TabPage();
            lblSockeStatus = new Label();
            btnConnectSocket = new Button();
            btnRegisterChanel = new Button();
            bntConfigWebSocket = new Button();
            txtPhoneSocketChanel = new TextBox();
            label16 = new Label();
            label15 = new Label();
            txtWebSocketUrl = new TextBox();
            label6 = new Label();
            tabPage3 = new TabPage();
            lblInfoTest = new Label();
            btnOpenFileToSendFax = new Button();
            label8 = new Label();
            btnSendFaxTest = new Button();
            txtReiverName = new TextBox();
            label7 = new Label();
            txtFaxNumber = new TextBox();
            lblReceive = new Label();
            txtDocumentSubject = new TextBox();
            label9 = new Label();
            txtDocumentName = new TextBox();
            label10 = new Label();
            errorProviders = new ErrorProvider(components);
            foldersavefileDigalog = new FolderBrowserDialog();
            openFileToSendFax = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviders).BeginInit();
            SuspendLayout();
            // 
            // lblHostName
            // 
            lblHostName.AutoSize = true;
            lblHostName.Location = new Point(22, 54);
            lblHostName.Name = "lblHostName";
            lblHostName.Size = new Size(76, 15);
            lblHostName.TabIndex = 7;
            lblHostName.Text = "HOST NAME";
            // 
            // txtHostName
            // 
            txtHostName.Location = new Point(164, 54);
            txtHostName.Name = "txtHostName";
            txtHostName.Size = new Size(364, 23);
            txtHostName.TabIndex = 8;
            // 
            // btnTestFAX
            // 
            btnTestFAX.ForeColor = Color.FromArgb(0, 0, 192);
            btnTestFAX.Location = new Point(164, 254);
            btnTestFAX.Name = "btnTestFAX";
            btnTestFAX.Size = new Size(96, 28);
            btnTestFAX.TabIndex = 9;
            btnTestFAX.Text = "CONFIG FAX";
            btnTestFAX.UseVisualStyleBackColor = true;
            btnTestFAX.Click += btnTestFAX_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(-2, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(709, 348);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblFolderSelected);
            tabPage1.Controls.Add(btnBrowserFolder);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtSenderCompany);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtSenderName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(btnTestFAX);
            tabPage1.Controls.Add(txtHostName);
            tabPage1.Controls.Add(lblHostName);
            tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(701, 320);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Fax Config";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblFolderSelected
            // 
            lblFolderSelected.AutoSize = true;
            lblFolderSelected.BackColor = Color.Red;
            lblFolderSelected.Location = new Point(164, 227);
            lblFolderSelected.Name = "lblFolderSelected";
            lblFolderSelected.Size = new Size(0, 15);
            lblFolderSelected.TabIndex = 23;
            // 
            // btnBrowserFolder
            // 
            btnBrowserFolder.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBrowserFolder.ForeColor = Color.FromArgb(0, 0, 192);
            btnBrowserFolder.Location = new Point(164, 179);
            btnBrowserFolder.Name = "btnBrowserFolder";
            btnBrowserFolder.Size = new Size(183, 28);
            btnBrowserFolder.TabIndex = 22;
            btnBrowserFolder.Text = "Browser Folder To Save Files";
            btnBrowserFolder.UseVisualStyleBackColor = true;
            btnBrowserFolder.Click += btnBrowserFolder_Click_1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(22, 186);
            label11.Name = "label11";
            label11.Size = new Size(61, 15);
            label11.TabIndex = 21;
            label11.Text = " FOLDERS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.OrangeRed;
            label4.Location = new Point(158, 14);
            label4.Name = "label4";
            label4.Size = new Size(329, 25);
            label4.TabIndex = 14;
            label4.Text = "CLIENT FAX CONFIG INFORMATION";
            // 
            // txtSenderCompany
            // 
            txtSenderCompany.Location = new Point(164, 139);
            txtSenderCompany.Name = "txtSenderCompany";
            txtSenderCompany.Size = new Size(364, 23);
            txtSenderCompany.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 139);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 12;
            label3.Text = "SENDER COMPANY";
            // 
            // txtSenderName
            // 
            txtSenderName.Location = new Point(164, 88);
            txtSenderName.Name = "txtSenderName";
            txtSenderName.Size = new Size(364, 23);
            txtSenderName.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 88);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 10;
            label2.Text = "SENDER NAME";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(701, 320);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Authen Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtClientSecret);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtClientID);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txtDomainHeader);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtApiUrl);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblWebSocketSatus);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(667, 301);
            panel1.TabIndex = 0;
            // 
            // txtClientSecret
            // 
            txtClientSecret.Location = new Point(163, 180);
            txtClientSecret.Name = "txtClientSecret";
            txtClientSecret.Size = new Size(364, 23);
            txtClientSecret.TabIndex = 31;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(42, 188);
            label14.Name = "label14";
            label14.Size = new Size(90, 15);
            label14.TabIndex = 30;
            label14.Text = "CLIENT SECRET";
            // 
            // txtClientID
            // 
            txtClientID.Location = new Point(164, 144);
            txtClientID.Name = "txtClientID";
            txtClientID.Size = new Size(364, 23);
            txtClientID.TabIndex = 29;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(42, 152);
            label13.Name = "label13";
            label13.Size = new Size(59, 15);
            label13.TabIndex = 28;
            label13.Text = "CLIENTID";
            // 
            // txtDomainHeader
            // 
            txtDomainHeader.Location = new Point(164, 102);
            txtDomainHeader.Name = "txtDomainHeader";
            txtDomainHeader.Size = new Size(364, 23);
            txtDomainHeader.TabIndex = 27;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(45, 108);
            label12.Name = "label12";
            label12.Size = new Size(106, 15);
            label12.TabIndex = 26;
            label12.Text = "DOMAIN HEADER";
            // 
            // txtApiUrl
            // 
            txtApiUrl.Location = new Point(164, 54);
            txtApiUrl.Name = "txtApiUrl";
            txtApiUrl.Size = new Size(364, 23);
            txtApiUrl.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(45, 60);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 24;
            label1.Text = "API URL";
            // 
            // lblWebSocketSatus
            // 
            lblWebSocketSatus.AutoSize = true;
            lblWebSocketSatus.ForeColor = Color.Red;
            lblWebSocketSatus.Location = new Point(176, 42);
            lblWebSocketSatus.Name = "lblWebSocketSatus";
            lblWebSocketSatus.Size = new Size(0, 15);
            lblWebSocketSatus.TabIndex = 23;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.FromArgb(0, 0, 192);
            btnLogin.Location = new Point(164, 233);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(96, 28);
            btnLogin.TabIndex = 18;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.OrangeRed;
            label5.Location = new Point(164, 13);
            label5.Name = "label5";
            label5.Size = new Size(274, 21);
            label5.TabIndex = 15;
            label5.Text = "AUTHEN SETTINGS  INFORMATION";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lblSockeStatus);
            tabPage4.Controls.Add(btnConnectSocket);
            tabPage4.Controls.Add(btnRegisterChanel);
            tabPage4.Controls.Add(bntConfigWebSocket);
            tabPage4.Controls.Add(txtPhoneSocketChanel);
            tabPage4.Controls.Add(label16);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(txtWebSocketUrl);
            tabPage4.Controls.Add(label6);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(701, 320);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "WebSocket Settings";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblSockeStatus
            // 
            lblSockeStatus.AutoSize = true;
            lblSockeStatus.ForeColor = Color.Red;
            lblSockeStatus.Location = new Point(208, 69);
            lblSockeStatus.Name = "lblSockeStatus";
            lblSockeStatus.Size = new Size(111, 15);
            lblSockeStatus.TabIndex = 26;
            lblSockeStatus.Text = "lblWebSocketStatus";
            // 
            // btnConnectSocket
            // 
            btnConnectSocket.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnConnectSocket.ForeColor = Color.FromArgb(0, 0, 192);
            btnConnectSocket.Location = new Point(467, 141);
            btnConnectSocket.Name = "btnConnectSocket";
            btnConnectSocket.Size = new Size(127, 21);
            btnConnectSocket.TabIndex = 25;
            btnConnectSocket.Text = "CONNECT SOCKET";
            btnConnectSocket.UseVisualStyleBackColor = true;
            btnConnectSocket.Click += btnConnectSocket_Click;
            // 
            // btnRegisterChanel
            // 
            btnRegisterChanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegisterChanel.ForeColor = Color.FromArgb(0, 0, 192);
            btnRegisterChanel.Location = new Point(334, 141);
            btnRegisterChanel.Name = "btnRegisterChanel";
            btnRegisterChanel.Size = new Size(127, 21);
            btnRegisterChanel.TabIndex = 24;
            btnRegisterChanel.Text = "REGISTER CHANEL";
            btnRegisterChanel.UseVisualStyleBackColor = true;
            btnRegisterChanel.Click += btnRegisterChanel_Click;
            // 
            // bntConfigWebSocket
            // 
            bntConfigWebSocket.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bntConfigWebSocket.ForeColor = Color.FromArgb(0, 0, 192);
            bntConfigWebSocket.Location = new Point(205, 141);
            bntConfigWebSocket.Name = "bntConfigWebSocket";
            bntConfigWebSocket.Size = new Size(105, 21);
            bntConfigWebSocket.TabIndex = 23;
            bntConfigWebSocket.Text = "CONFIG";
            bntConfigWebSocket.UseVisualStyleBackColor = true;
            bntConfigWebSocket.Click += bntConfigWebSocket_Click;
            // 
            // txtPhoneSocketChanel
            // 
            txtPhoneSocketChanel.Location = new Point(205, 88);
            txtPhoneSocketChanel.Name = "txtPhoneSocketChanel";
            txtPhoneSocketChanel.Size = new Size(364, 23);
            txtPhoneSocketChanel.TabIndex = 22;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(54, 96);
            label16.Name = "label16";
            label16.Size = new Size(145, 15);
            label16.TabIndex = 21;
            label16.Text = "PHONE SOCKET CHANEL ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.OrangeRed;
            label15.Location = new Point(172, 3);
            label15.Name = "label15";
            label15.Size = new Size(302, 21);
            label15.TabIndex = 20;
            label15.Text = "WEBSOCKET SETTINGS  INFORMATION";
            // 
            // txtWebSocketUrl
            // 
            txtWebSocketUrl.Location = new Point(205, 40);
            txtWebSocketUrl.Name = "txtWebSocketUrl";
            txtWebSocketUrl.Size = new Size(364, 23);
            txtWebSocketUrl.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(54, 43);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 18;
            label6.Text = "WEBSOCKET URL";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(lblInfoTest);
            tabPage3.Controls.Add(btnOpenFileToSendFax);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(btnSendFaxTest);
            tabPage3.Controls.Add(txtReiverName);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(txtFaxNumber);
            tabPage3.Controls.Add(lblReceive);
            tabPage3.Controls.Add(txtDocumentSubject);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(txtDocumentName);
            tabPage3.Controls.Add(label10);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(701, 320);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Send Fax Test";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblInfoTest
            // 
            lblInfoTest.AutoSize = true;
            lblInfoTest.Location = new Point(218, 9);
            lblInfoTest.Name = "lblInfoTest";
            lblInfoTest.Size = new Size(61, 15);
            lblInfoTest.TabIndex = 25;
            lblInfoTest.Text = "lblInfoTest";
            // 
            // btnOpenFileToSendFax
            // 
            btnOpenFileToSendFax.Location = new Point(214, 121);
            btnOpenFileToSendFax.Name = "btnOpenFileToSendFax";
            btnOpenFileToSendFax.Size = new Size(160, 23);
            btnOpenFileToSendFax.TabIndex = 24;
            btnOpenFileToSendFax.Text = "Choose file to send fax";
            btnOpenFileToSendFax.UseVisualStyleBackColor = true;
            btnOpenFileToSendFax.Click += btnOpenFileToSendFax_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(85, 122);
            label8.Name = "label8";
            label8.Size = new Size(25, 15);
            label8.TabIndex = 23;
            label8.Text = "File";
            // 
            // btnSendFaxTest
            // 
            btnSendFaxTest.ForeColor = Color.FromArgb(0, 0, 192);
            btnSendFaxTest.Location = new Point(214, 255);
            btnSendFaxTest.Name = "btnSendFaxTest";
            btnSendFaxTest.Size = new Size(96, 28);
            btnSendFaxTest.TabIndex = 22;
            btnSendFaxTest.Text = "SEND FAX TEST";
            btnSendFaxTest.UseVisualStyleBackColor = true;
            btnSendFaxTest.Click += btnSendFaxTest_Click;
            // 
            // txtReiverName
            // 
            txtReiverName.Location = new Point(214, 205);
            txtReiverName.Name = "txtReiverName";
            txtReiverName.Size = new Size(364, 23);
            txtReiverName.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(85, 208);
            label7.Name = "label7";
            label7.Size = new Size(94, 15);
            label7.TabIndex = 20;
            label7.Text = "RECEIVER NAME";
            // 
            // txtFaxNumber
            // 
            txtFaxNumber.Location = new Point(214, 156);
            txtFaxNumber.Name = "txtFaxNumber";
            txtFaxNumber.Size = new Size(364, 23);
            txtFaxNumber.TabIndex = 19;
            // 
            // lblReceive
            // 
            lblReceive.AutoSize = true;
            lblReceive.Location = new Point(85, 164);
            lblReceive.Name = "lblReceive";
            lblReceive.Size = new Size(78, 15);
            lblReceive.TabIndex = 18;
            lblReceive.Text = "FAX NUMBER";
            // 
            // txtDocumentSubject
            // 
            txtDocumentSubject.Location = new Point(214, 35);
            txtDocumentSubject.Name = "txtDocumentSubject";
            txtDocumentSubject.Size = new Size(364, 23);
            txtDocumentSubject.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(85, 38);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 14;
            label9.Text = "SUBJECT";
            // 
            // txtDocumentName
            // 
            txtDocumentName.Location = new Point(214, 77);
            txtDocumentName.Name = "txtDocumentName";
            txtDocumentName.Size = new Size(364, 23);
            txtDocumentName.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(85, 80);
            label10.Name = "label10";
            label10.Size = new Size(109, 15);
            label10.TabIndex = 16;
            label10.Text = "DOCUMENT NAME";
            // 
            // errorProviders
            // 
            errorProviders.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 357);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Fax config";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviders).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblHostName;
        private TextBox txtHostName;
        private Button btnTestFAX;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label4;
        private TextBox txtSenderCompany;
        private Label label3;
        private TextBox txtSenderName;
        private Label label2;
        private TabPage tabPage2;
        private Panel panel1;
        private Label label5;
        private Button btnLogin;
        private TabPage tabPage3;
        private Button btnSendFaxTest;
        private TextBox txtReiverName;
        private Label label7;
        private TextBox txtFaxNumber;
        private Label lblReceive;
        private TextBox txtDocumentSubject;
        private Label label9;
        private TextBox txtDocumentName;
        private Label label10;
        private Button btnOpenFileToSendFax;
        private Label label8;
        private ErrorProvider errorProviders;
        private FolderBrowserDialog foldersavefileDigalog;
        private Label lblWebSocketSatus;
        private OpenFileDialog openFileToSendFax;
        private Label lblInfoTest;
        private Button btnBrowserFolder;
        private Label label11;
        private Label lblFolderSelected;
        private TextBox txtClientSecret;
        private Label label14;
        private TextBox txtClientID;
        private Label label13;
        private TextBox txtDomainHeader;
        private Label label12;
        private TextBox txtApiUrl;
        private Label label1;
        private TabPage tabPage4;
        private TextBox txtWebSocketUrl;
        private Label label6;
        private Label label15;
        private Button btnRegisterChanel;
        private Button bntConfigWebSocket;
        private TextBox txtPhoneSocketChanel;
        private Label label16;
        private Button btnConnectSocket;
        private Label lblWebSocketStatus;
        private Label lblSockeStatus;
    }
}