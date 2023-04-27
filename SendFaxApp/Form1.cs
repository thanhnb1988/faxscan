
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
    }
}