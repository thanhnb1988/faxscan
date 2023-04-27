
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

        FaxLinQDataContext context = new FaxLinQDataContext();

        public Form1()
        {
            InitializeComponent();
            initDataConifg();
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

            }
        }



        private FaxConfig? GetDefaultFaxConfig()
        {
            var faxConfig = context.FaxConfigs.FirstOrDefault();
            return faxConfig;
        }


        private void btnTestFAX_Click(object sender, EventArgs e)
        {
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

        }

        private void btnConfigWebSocket_Click(object sender, EventArgs e)
        {
            var config = GetDefaultFaxConfig();
            bool isInsert = false;
            if (config == null)
            {
                config = new FaxConfig();
                isInsert = true;

            }

            config.WebSocketUrl = txtWebSocketUrl.Text;

            if (isInsert)
            {
                context.FaxConfigs.InsertOnSubmit(config);
            }
            context.SubmitChanges();
        }

        private void btnSendFaxTest_Click(object sender, EventArgs e)
        {
            var config = GetDefaultFaxConfig();
            FaxSender faxSender = new FaxSender(config.HostName);

            FaxSenderInfo faxSenderInfo = new FaxSenderInfo();
            faxSenderInfo.Name = config.SenderName;
            faxSenderInfo.CompanyName = config.CompanyName;
            faxSenderInfo.Subject = txtDocumentSubject.Text;

            FaxDocInfo faxDocInfo = new FaxDocInfo();
            faxDocInfo.DocumentName = txtDocumentName.Text;
            faxDocInfo.Body = "Test";

            FaxRecipientsInfo faxRecipientsInfo = new FaxRecipientsInfo();
            faxRecipientsInfo.bstrFaxNumber = txtFaxNumber.Text;
            faxRecipientsInfo.bstrRecipientName = txtReiverName.Text;

            faxSender.SendFax(faxSenderInfo, faxDocInfo, faxRecipientsInfo);


        }
    }
}