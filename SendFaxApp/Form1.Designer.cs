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
            txtIpRange = new TextBox();
            btnScan = new Button();
            lblIpRange = new Label();
            dataGridViewScanner = new DataGridView();
            ArpIP = new DataGridViewTextBoxColumn();
            ArpName = new DataGridViewTextBoxColumn();
            ArpStatus = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            backgroundWorkerScanner = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            txtIP = new TextBox();
            lblHostName = new Label();
            txtHostName = new TextBox();
            btnTestFAX = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewScanner).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtIpRange
            // 
            txtIpRange.Location = new Point(147, 23);
            txtIpRange.Name = "txtIpRange";
            txtIpRange.Size = new Size(240, 23);
            txtIpRange.TabIndex = 0;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(428, 22);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(75, 23);
            btnScan.TabIndex = 1;
            btnScan.Text = "Scan ";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // lblIpRange
            // 
            lblIpRange.AutoSize = true;
            lblIpRange.FlatStyle = FlatStyle.Popup;
            lblIpRange.Location = new Point(88, 27);
            lblIpRange.Name = "lblIpRange";
            lblIpRange.Size = new Size(53, 15);
            lblIpRange.TabIndex = 2;
            lblIpRange.Text = "IP Range";
            // 
            // dataGridViewScanner
            // 
            dataGridViewScanner.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewScanner.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewScanner.Columns.AddRange(new DataGridViewColumn[] { ArpIP, ArpName, ArpStatus });
            dataGridViewScanner.Dock = DockStyle.Fill;
            dataGridViewScanner.Location = new Point(0, 0);
            dataGridViewScanner.Name = "dataGridViewScanner";
            dataGridViewScanner.RowTemplate.Height = 25;
            dataGridViewScanner.Size = new Size(699, 308);
            dataGridViewScanner.TabIndex = 3;
            dataGridViewScanner.CellClick += dataGridViewScanner_CellClick;
            // 
            // ArpIP
            // 
            ArpIP.FillWeight = 99.4923859F;
            ArpIP.HeaderText = "Ip Address";
            ArpIP.Name = "ArpIP";
            // 
            // ArpName
            // 
            ArpName.FillWeight = 99.4923859F;
            ArpName.HeaderText = "HostName";
            ArpName.Name = "ArpName";
            // 
            // ArpStatus
            // 
            ArpStatus.FillWeight = 99.4923859F;
            ArpStatus.HeaderText = "Status";
            ArpStatus.Name = "ArpStatus";
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridViewScanner);
            panel1.Location = new Point(12, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(699, 308);
            panel1.TabIndex = 4;
            // 
            // backgroundWorkerScanner
            // 
            backgroundWorkerScanner.DoWork += backgroundWorkerScanner_DoWork;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 408);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 5;
            label1.Text = "IP ";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(130, 408);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(192, 23);
            txtIP.TabIndex = 6;
            // 
            // lblHostName
            // 
            lblHostName.AutoSize = true;
            lblHostName.Location = new Point(58, 450);
            lblHostName.Name = "lblHostName";
            lblHostName.Size = new Size(64, 15);
            lblHostName.TabIndex = 7;
            lblHostName.Text = "HostName";
            // 
            // txtHostName
            // 
            txtHostName.Location = new Point(130, 442);
            txtHostName.Name = "txtHostName";
            txtHostName.Size = new Size(192, 23);
            txtHostName.TabIndex = 8;
            // 
            // btnTestFAX
            // 
            btnTestFAX.Location = new Point(386, 408);
            btnTestFAX.Name = "btnTestFAX";
            btnTestFAX.Size = new Size(71, 57);
            btnTestFAX.TabIndex = 9;
            btnTestFAX.Text = "TEST FAX";
            btnTestFAX.UseVisualStyleBackColor = true;
            btnTestFAX.Click += btnTestFAX_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 523);
            Controls.Add(btnTestFAX);
            Controls.Add(txtHostName);
            Controls.Add(lblHostName);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(lblIpRange);
            Controls.Add(btnScan);
            Controls.Add(txtIpRange);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewScanner).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIpRange;
        private Button btnScan;
        private Label lblIpRange;
        private DataGridView dataGridViewScanner;
        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerScanner;
        private DataGridViewTextBoxColumn ArpIP;
        private DataGridViewTextBoxColumn ArpName;
        private DataGridViewTextBoxColumn ArpStatus;
        private Label label1;
        private TextBox txtIP;
        private Label lblHostName;
        private TextBox txtHostName;
        private Button btnTestFAX;
    }
}