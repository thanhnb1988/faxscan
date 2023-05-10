
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WebSocketSharp;
using System.Diagnostics;
using System.Security;
using FAXCOMEXLib;
using System.Collections;
using SendFaxApp.Model.Fax;

namespace SendFaxApp
{
    public partial class Form1 : Form
    {

        FaxLinQDataContext context = new FaxLinQDataContext();

        private WebSocket client;

        private String fileFaxTest = "";

        const string host = "ws://ablaze-sophisticated-sound.glitch.me";

        public Form1()
        {
            InitializeComponent();
            initDataConifg();
            onConnectWebSocket();
            clearOpenFileSendFaxTest();

            lblInfoTest.Text = Environment.MachineName;


        }

        private void clearOpenFileSendFaxTest()
        {
            fileFaxTest = string.Empty;
        }

        private void initDataConifg()
        {
            var config = GetDefaultFaxConfig();
            if (config != null)
            {
                txtIP.Text = config.IP;
                txtHostName.Text = config.HostName;
                txtSenderName.Text = config.SenderName;
                txtSenderCompany.Text = config.CompanyName;
                txtWebSocketUrl.Text = config.WebSocketUrl;
                lblFolderSelected.Text = config.FileSaveUrl;

            }
        }

        private FaxConfig? GetDefaultFaxConfig()
        {
            var faxConfig = context.FaxConfigs.FirstOrDefault();
            return faxConfig;
        }


        private void btnTestFAX_Click(object sender, EventArgs e)
        {
            bool isValidate = validateFaxClick();
            if (!isValidate)
            {
                return;
            }
            var config = GetDefaultFaxConfig();
            bool isInsert = false;
            if (config == null)
            {
                config = new FaxConfig();
                isInsert = true;

            }

            config.IP = txtIP.Text;
            config.HostName = txtHostName.Text;
            config.SenderName = txtSenderName.Text;
            config.CompanyName = txtSenderCompany.Text;

            if (isInsert)
            {
                context.FaxConfigs.InsertOnSubmit(config);
            }
            context.SubmitChanges();

            clearOpenFileSendFaxTest();

            MessageBox.Show("Update Fax Config Successfully");

        }

        private bool validateFaxClick()
        {
            try
            {
                clearValidate();

                validateIPFax();

                validateHostName();

                validateSenderName();

                validateCompanyName();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private void clearValidate()
        {
            errorProviders.Clear();
        }

        private void validateIPFax()
        {
            if (txtIP.Text == string.Empty)
            {
                errorProviders.SetError(txtIP, "Must input the IP fax");

                throw new Exception();
            }
        }

        private void validateHostName()
        {
            if (txtHostName.Text == string.Empty)
            {
                errorProviders.SetError(txtHostName, "Must input the HostName fax");

                throw new Exception();
            }
        }

        private void validateSenderName()
        {
            if (txtSenderName.Text == string.Empty)
            {
                errorProviders.SetError(txtSenderName, "Must input the Sender Name");

                throw new Exception();
            }
        }

        private void validateCompanyName()
        {
            if (txtSenderCompany.Text == string.Empty)
            {
                errorProviders.SetError(txtSenderCompany, "Must input the Company Name");

                throw new Exception();
            }
        }

        private void btnConfigWebSocket_Click(object sender, EventArgs e)
        {
            bool isValidate = validateSettings();
            if (!isValidate)
            {
                return;
            }
            var config = GetDefaultFaxConfig();
            bool isInsert = false;
            if (config == null)
            {
                config = new FaxConfig();
                isInsert = true;

            }
            onConnectWebSocket();

            config.WebSocketUrl = txtWebSocketUrl.Text;
            config.FileSaveUrl = lblFolderSelected.Text;

            if (isInsert)
            {
                context.FaxConfigs.InsertOnSubmit(config);
            }
            context.SubmitChanges();

            clearOpenFileSendFaxTest();

            MessageBox.Show("Update Settings Successfully");
        }

        private bool validateSettings()
        {
            try
            {
                clearValidate();

                validateWebSocketUrl();
                validateSelectedFolder();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void validateWebSocketUrl()
        {
            if (txtWebSocketUrl.Text == string.Empty)
            {
                errorProviders.SetError(txtWebSocketUrl, "Must input the web socket url");

                throw new Exception();
            }
        }

        private void validateSelectedFolder()
        {
            if (lblFolderSelected.Text == string.Empty)
            {
                errorProviders.SetError(btnBrowserFolder, "Must input folder selected");

                throw new Exception();
            }
        }


        private bool onConnectWebSocket()
        {
            bool isConnectSuccess = true;
            try
            {
                client = new WebSocket(host);
                client.OnOpen += (ss, ee) =>
                {
                    isConnectSuccess = true;
                    onWebSocketOpen(ss, ee);
                };
                client.OnMessage += (ss, ee) =>
                {
                    isConnectSuccess = false;
                    lblWebSocketSatus.Text = " Data: " + ee.Data;
                };

                client.OnError += (ss, ee) =>
                {
                    isConnectSuccess = false;
                    lblWebSocketSatus.Text = " Error: " + ee.Message;
                };

                client.OnClose += (ss, ee) =>
                {
                    isConnectSuccess = false;
                    lblWebSocketSatus.Text = (string.Format("Disconnected with {0}", host));
                };

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private void onWebSocketOpen(object sender, EventArgs ee)
        {
            lblWebSocketSatus.Text = (string.Format("Connected to {0} successfully", host));
        }

        private void onWebSockeError()
        {
            lblWebSocketSatus.Text = (string.Format("Error  {0} successfully", host));
        }

        private void btnSendFaxTest_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fileFaxTest))
            {
                MessageBox.Show("Choose file to send fax");
                return;
            }



            var config = GetDefaultFaxConfig();
            Model.FaxSender faxSender = new Model.FaxSender(config.HostName);

            FaxSenderInfo faxSenderInfo = new FaxSenderInfo();
            faxSenderInfo.Name = config.SenderName;
            faxSenderInfo.CompanyName = config.CompanyName;
            faxSenderInfo.Subject = txtDocumentSubject.Text;

            FaxDocInfo faxDocInfo = new FaxDocInfo();
            faxDocInfo.DocumentName = txtDocumentName.Text;
          
            faxDocInfo.Bodies.Add(@"C:\Users\admin\Desktop\Fax Auto\TEST.pdf");
            faxDocInfo.Bodies.Add(@"C:\Users\admin\Desktop\Fax Auto\TEST_2.pdf");

            FaxRecipientsInfo faxRecipientsInfo = new FaxRecipientsInfo();
            faxRecipientsInfo.listFaxRecipientsItem = new List<FaxRecipientsItem>();
            faxRecipientsInfo.listFaxRecipientsItem.Add(new FaxRecipientsItem() { Number = txtFaxNumber.Text, Name =txtReiverName.Text });
            faxRecipientsInfo.listFaxRecipientsItem.Add(new FaxRecipientsItem() { Number="2222",Name=""});
            clearOpenFileSendFaxTest();
            faxSender.SendFaxMultiFilesAndMultiUers(faxSenderInfo, faxDocInfo, faxRecipientsInfo);


        }

        private void btnBrowserFolder_Click(object sender, EventArgs e)
        {
            if (foldersavefileDigalog.ShowDialog() == DialogResult.OK)
            {
                lblFolderSelected.Text = foldersavefileDigalog.SelectedPath;

            }
        }


        /**
         * Run task in back ground with timespam
         * 
         * */
        async Task RunInBackground(TimeSpan timeSpan, Action action)
        {
            var periodicTimer = new PeriodicTimer(timeSpan);
            while (await periodicTimer.WaitForNextTickAsync())
            {
                action();
            }
        }

        private void btnWebSocketConnect_Click(object sender, EventArgs e)
        {
            if (client.IsAlive)
            {
                client.Close();
            }
            client.Connect();
        }

        private void btnOpenFileToSendFax_Click(object sender, EventArgs e)
        {
            if (openFileToSendFax.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileFaxTest = openFileToSendFax.FileName;

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

        }
    }
}