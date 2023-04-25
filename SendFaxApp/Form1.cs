
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using SendFaxApp.Model;
using Microsoft.VisualBasic;

namespace SendFaxApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorkerScanner_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            Ping ping;
            IPAddress ipAddr;
            PingReply pingReply;
            IPHostEntry host;
            string name;

            Parallel.For(0, 254, (i, loopState) =>
            {
                ping = new Ping();
                pingReply = ping.Send(txtIpRange.Text + i.ToString());



                this.BeginInvoke((Action)delegate ()
                {
                    if (pingReply.Status == IPStatus.Success)
                    {
                        try
                        {
                            ipAddr = IPAddress.Parse(txtIpRange.Text + i.ToString());
                            host = Dns.GetHostEntry(ipAddr);
                            name = host.HostName;



                            int nRowIndex = dataGridViewScanner.Rows.Add();
                            dataGridViewScanner.Rows[nRowIndex].Cells[0].Value = txtIpRange.Text + i.ToString();
                            dataGridViewScanner.Rows[nRowIndex].Cells[1].Value = name;

                            dataGridViewScanner.Rows[nRowIndex].Cells[2].Value = "Active";


                            DataGridViewButtonColumn btnChoiseFax = new DataGridViewButtonColumn();
                            btnChoiseFax.Name = "btnChoiseFax_column";
                            btnChoiseFax.HeaderText = "Action";
                            btnChoiseFax.Text = "Chọn máy Fax";
                            btnChoiseFax.UseColumnTextForButtonValue = true;
                            dataGridViewScanner.Columns.Add(btnChoiseFax);



                        }
                        catch (Exception ex)
                        {
                            name = "?";
                        }


                    }

                });
            });

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
          
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addr = hostEntry.AddressList;
            var ip = addr.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                         .FirstOrDefault();
            var localIP = ip.ToString() ?? "";
            string[] parts = localIP.Split('.');
            //
            txtIpRange.Text = String.Format("{0}.{1}.{2}.", parts[0], parts[1], parts[2]);

            backgroundWorkerScanner.RunWorkerAsync();
        }

        private void dataGridViewScanner_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                txtIP.Text = dataGridViewScanner.CurrentRow.Cells[0].Value.ToString();
                txtHostName.Text = dataGridViewScanner.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnTestFAX_Click(object sender, EventArgs e)
        {
            string hostName = txtHostName.Text;
            var faxSender = new FaxSender(hostName);

            var faxSenderInfo = new FaxSenderInfo() { Name = "Sender Name", CompanyName = "SenderComanpany Name", Subject = "Fax Subject" };
           
            var faxDocInfor = new FaxDocInfo();
            faxDocInfor.DocumentName = "Document Name";
            string[] s = { "\\bin" };
            string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\lib\\TestPDFFilewithMultiPage.pdf";
            faxDocInfor.Body = path;


            var faxReipentsInfo = new FaxRecipientsInfo();
            faxReipentsInfo.bstrFaxNumber = "12345678912";
            faxReipentsInfo.bstrRecipientName = "TestReceipent-001";
            
            faxSender.SendFax(faxSenderInfo, faxDocInfor, faxReipentsInfo);
        }
    }
}