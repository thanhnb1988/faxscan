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
            label1 = new Label();
            txtIP = new TextBox();
            lblHostName = new Label();
            txtHostName = new TextBox();
            btnTestFAX = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label4 = new Label();
            txtSenderCompany = new TextBox();
            label3 = new Label();
            txtSenderName = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            btnConfigWebSocket = new Button();
            txtWebSocketUrl = new TextBox();
            label6 = new Label();
            label5 = new Label();
            tabPage3 = new TabPage();
            btnSendFaxTest = new Button();
            txtReiverName = new TextBox();
            label7 = new Label();
            txtFaxNumber = new TextBox();
            lblReceive = new Label();
            txtDocumentSubject = new TextBox();
            label9 = new Label();
            txtDocumentName = new TextBox();
            label10 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 71);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "IP  FAX";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(158, 68);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(364, 23);
            txtIP.TabIndex = 6;
            // 
            // lblHostName
            // 
            lblHostName.AutoSize = true;
            lblHostName.Location = new Point(29, 113);
            lblHostName.Name = "lblHostName";
            lblHostName.Size = new Size(76, 15);
            lblHostName.TabIndex = 7;
            lblHostName.Text = "HOST NAME";
            // 
            // txtHostName
            // 
            txtHostName.Location = new Point(158, 110);
            txtHostName.Name = "txtHostName";
            txtHostName.Size = new Size(364, 23);
            txtHostName.TabIndex = 8;
            // 
            // btnTestFAX
            // 
            btnTestFAX.ForeColor = Color.FromArgb(0, 0, 192);
            btnTestFAX.Location = new Point(158, 247);
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
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(685, 334);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtSenderCompany);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtSenderName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtIP);
            tabPage1.Controls.Add(btnTestFAX);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtHostName);
            tabPage1.Controls.Add(lblHostName);
            tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(677, 306);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "FAX CONFIG";
            tabPage1.UseVisualStyleBackColor = true;
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
            txtSenderCompany.Location = new Point(158, 203);
            txtSenderCompany.Name = "txtSenderCompany";
            txtSenderCompany.Size = new Size(364, 23);
            txtSenderCompany.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 206);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 12;
            label3.Text = "SENDER COMPANY";
            // 
            // txtSenderName
            // 
            txtSenderName.Location = new Point(158, 154);
            txtSenderName.Name = "txtSenderName";
            txtSenderName.Size = new Size(364, 23);
            txtSenderName.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 162);
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
            tabPage2.Size = new Size(677, 306);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnConfigWebSocket);
            panel1.Controls.Add(txtWebSocketUrl);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(667, 301);
            panel1.TabIndex = 0;
            // 
            // btnConfigWebSocket
            // 
            btnConfigWebSocket.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfigWebSocket.ForeColor = Color.FromArgb(0, 0, 192);
            btnConfigWebSocket.Location = new Point(164, 103);
            btnConfigWebSocket.Name = "btnConfigWebSocket";
            btnConfigWebSocket.Size = new Size(96, 28);
            btnConfigWebSocket.TabIndex = 18;
            btnConfigWebSocket.Text = "CONFIG";
            btnConfigWebSocket.UseVisualStyleBackColor = true;
            btnConfigWebSocket.Click += btnConfigWebSocket_Click;
            // 
            // txtWebSocketUrl
            // 
            txtWebSocketUrl.Location = new Point(164, 58);
            txtWebSocketUrl.Name = "txtWebSocketUrl";
            txtWebSocketUrl.Size = new Size(364, 23);
            txtWebSocketUrl.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(35, 61);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 16;
            label6.Text = "WEBSOCKET URL";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.OrangeRed;
            label5.Location = new Point(164, 13);
            label5.Name = "label5";
            label5.Size = new Size(304, 21);
            label5.TabIndex = 15;
            label5.Text = "WEB SOCKET CONNECT INFORMATION";
            // 
            // tabPage3
            // 
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
            tabPage3.Size = new Size(677, 306);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Send Fax Test";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSendFaxTest
            // 
            btnSendFaxTest.ForeColor = Color.FromArgb(0, 0, 192);
            btnSendFaxTest.Location = new Point(214, 228);
            btnSendFaxTest.Name = "btnSendFaxTest";
            btnSendFaxTest.Size = new Size(96, 28);
            btnSendFaxTest.TabIndex = 22;
            btnSendFaxTest.Text = "SEND FAX TEST";
            btnSendFaxTest.UseVisualStyleBackColor = true;
            btnSendFaxTest.Click += btnSendFaxTest_Click;
            // 
            // txtReiverName
            // 
            txtReiverName.Location = new Point(214, 170);
            txtReiverName.Name = "txtReiverName";
            txtReiverName.Size = new Size(364, 23);
            txtReiverName.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(85, 173);
            label7.Name = "label7";
            label7.Size = new Size(94, 15);
            label7.TabIndex = 20;
            label7.Text = "RECEIVER NAME";
            // 
            // txtFaxNumber
            // 
            txtFaxNumber.Location = new Point(214, 121);
            txtFaxNumber.Name = "txtFaxNumber";
            txtFaxNumber.Size = new Size(364, 23);
            txtFaxNumber.TabIndex = 19;
            // 
            // lblReceive
            // 
            lblReceive.AutoSize = true;
            lblReceive.Location = new Point(85, 129);
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
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox txtIP;
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
        private TextBox txtWebSocketUrl;
        private Label label6;
        private Button btnConfigWebSocket;
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
    }
}