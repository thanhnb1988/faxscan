
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
using System.Collections;
using SendFaxApp.Model.Fax;
using SendFaxApp.Utils.FaxUtils;
using SendFaxApp.Services;
using SendFaxApp.Model.LinQ;
using SendFaxApp.Model.MDO;

namespace SendFaxApp
{
    public partial class Form1 : Form
    {

        DbFaxContext context = new DbFaxContext(System.Configuration.ConfigurationManager.
    ConnectionStrings["SendFaxApp.Properties.Settings.FaxConfigDBConnectionString"].ConnectionString);

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

                txtHostName.Text = config.HostName;
                txtSenderName.Text = config.SenderName;
                txtSenderCompany.Text = config.CompanyName;
                lblFolderSelected.Text = config.FileSaveUrl;

            }
            else
            {
                txtHostName.Text = Environment.MachineName;
            }
            var authen = GetDefaultMDOAuthen();
            if (authen != null)
            {
                txtApiUrl.Text = authen.ApiUrl;
                txtDomainHeader.Text = authen.Domain;
                txtClientID.Text = authen.ClientId;
                txtClientSecret.Text = authen.ClientSecret;
                txtWebSocketUrl.Text = authen.WebSocketUrl;
                txtPhoneSocketChanel.Text = authen.WebSocketChanel;
            }
        }

        private FaxConfig? GetDefaultFaxConfig()
        {
            var faxConfig = context.FaxConfigs.FirstOrDefault();
            return faxConfig;
        }

        private AuthenMdo? GetDefaultMDOAuthen()
        {
            var authen = context.AuthenMdos.FirstOrDefault();
            return authen;
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

            config.HostName = txtHostName.Text;
            config.SenderName = txtSenderName.Text;
            config.CompanyName = txtSenderCompany.Text;

            config.FileSaveUrl = lblFolderSelected.Text;

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

                validateHostName();

                validateSenderName();

                validateCompanyName();

                validateSelectedFolder();

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isValidate = validateLoginSettings();
            if (!isValidate)
            {
                return;
            }
            var authen = GetDefaultMDOAuthen();
            bool isInsert = false;
            if (authen == null)
            {
                authen = new AuthenMdo();
                isInsert = true;

            }
            authen.Domain = txtDomainHeader.Text.Trim();
            authen.ClientSecret = txtClientSecret.Text.Trim();
            authen.ClientId = txtClientID.Text.Trim();
            authen.ApiUrl = txtApiUrl.Text.Trim();

            var authenApiResponse = GetMDOAuthenToken(authen.ApiUrl, authen.Domain, authen.ClientId, authen.ClientSecret);
            if (authenApiResponse != null)
            {
                authen.Token = authenApiResponse.Data.Token;
                authen.TokenTimeout = authenApiResponse.Data.TokenTimeout.ToString();
                authen.TokentExpiredAt = authenApiResponse.Data.TokenExpiredAt.ToString();
            }

            if (isInsert)
            {
                context.AuthenMdos.InsertOnSubmit(authen);
            }
            context.SubmitChanges();

            clearOpenFileSendFaxTest();

            MessageBox.Show("Update Authen Settings Successfully");
        }

        private bool validateLoginSettings()
        {
            try
            {
                clearValidate();

                validateApiUrl();

                validateDomainHeader();

                validateClientID();

                validateClientSecret();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void validateApiUrl()
        {
            if (txtApiUrl.Text == string.Empty)
            {
                errorProviders.SetError(txtApiUrl, "Must input API url");

                throw new Exception();
            }
        }

        private void validateDomainHeader()
        {
            if (txtDomainHeader.Text == string.Empty)
            {
                errorProviders.SetError(txtDomainHeader, "Must input Domain Header");

                throw new Exception();
            }
        }

        private void validateClientID()
        {
            if (txtClientID.Text == string.Empty)
            {
                errorProviders.SetError(txtClientID, "Must input Client ID");

                throw new Exception();
            }
        }

        private void validateClientSecret()
        {
            if (txtClientSecret.Text == string.Empty)
            {
                errorProviders.SetError(txtClientID, "Must input Client Secret");

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

        private LoginRespone GetMDOAuthenToken(string baseUrl, string domain, string clientID, string Secret)
        {
            AuthenService service = new AuthenService(baseUrl, domain);
            return service.login(new Model.MDO.LoginRequest() { ClientId = clientID, ClientSecret = Secret }).Result;
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



            //var authen = GetDefaultFaxConfig();
            //FaxSenderHelper faxSender = new FaxSenderHelper(authen.HostName);

            //FaxSenderInfo faxSenderInfo = new FaxSenderInfo();
            //faxSenderInfo.Name = authen.SenderName;
            //faxSenderInfo.CompanyName = authen.CompanyName;
            //faxSenderInfo.Subject = txtDocumentSubject.Text;

            //FaxDocInfo faxDocInfo = new FaxDocInfo();
            //faxDocInfo.DocumentName = txtDocumentName.Text;

            //faxDocInfo.Bodies.Add(@"C:\Users\admin\Desktop\Fax Auto\TEST.pdf");
            //faxDocInfo.Bodies.Add(@"C:\Users\admin\Desktop\Fax Auto\TEST_2.pdf");

            //FaxRecipientsInfo faxRecipientsInfo = new FaxRecipientsInfo();
            //faxRecipientsInfo.listFaxRecipientsItem = new List<FaxRecipientsItem>();
            //faxRecipientsInfo.listFaxRecipientsItem.Add(new FaxRecipientsItem() { Number = txtFaxNumber.Text, Name = txtReiverName.Text });
            //faxRecipientsInfo.listFaxRecipientsItem.Add(new FaxRecipientsItem() { Number = "2222", Name = "" });
            //clearOpenFileSendFaxTest();
            //faxSender.SendFaxMultiFilesAndMultiUers(faxSenderInfo, faxDocInfo, faxRecipientsInfo);


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
            //if (client.IsAlive)
            //{
            //    client.Close();
            //}
            //client.Connect();

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

        private void btnBrowserFolder_Click_1(object sender, EventArgs e)
        {
            if (foldersavefileDigalog.ShowDialog() == DialogResult.OK)
            {
                lblFolderSelected.Text = foldersavefileDigalog.SelectedPath;

            }
        }

        private void bntConfigWebSocket_Click(object sender, EventArgs e)
        {
            bool isValidate = validateWebSocketForms();
            if (!isValidate)
            {
                return;
            }
            var authen = GetDefaultMDOAuthen();
            bool isInsert = false;
            if (authen == null)
            {
                authen = new AuthenMdo();
                isInsert = true;

            }
            authen.WebSocketUrl = txtWebSocketUrl.Text.Trim();
            authen.WebSocketChanel = txtPhoneSocketChanel.Text.Trim();

            if (isInsert)
            {
                context.AuthenMdos.InsertOnSubmit(authen);
            }
            context.SubmitChanges();

            clearOpenFileSendFaxTest();

            MessageBox.Show("Update Web Socket Successfully");
        }

        private bool validateWebSocketForms()
        {
            try
            {
                clearValidate();

                validateWebSocketUrl();

                validatePhoneChanelWebSocket();

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
                errorProviders.SetError(txtWebSocketUrl, "Must input WebSocket url");

                throw new Exception();
            }
        }

        private void validatePhoneChanelWebSocket()
        {
            if (txtWebSocketUrl.Text == string.Empty)
            {
                errorProviders.SetError(txtWebSocketUrl, "Must input Phone Chanel Web socket");

                throw new Exception();
            }
        }

        private void btnRegisterChanel_Click(object sender, EventArgs e)
        {

        }
    }
}