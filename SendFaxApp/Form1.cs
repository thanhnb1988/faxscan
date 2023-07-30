
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Security;
using System.Collections;
using SendFaxApp.Model.Fax;
using SendFaxApp.Utils.FaxUtils;
using SendFaxApp.Services;
using SendFaxApp.Model.LinQ;
using SendFaxApp.Model.MDO;
using Microsoft.IdentityModel.Tokens;
using Quobject.SocketIoClientDotNet.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Immutable;
using Newtonsoft.Json;
using System.Transactions;
using System.Drawing;
using Microsoft.VisualBasic.Logging;
using System.Net.WebSockets;
using FluentScheduler;
using NLog;
using WebSocketSharp;
using System.Configuration;

namespace SendFaxApp
{
    public partial class Form1 : Form
    {
        private String connectionStriong = System.Configuration.ConfigurationManager.
    ConnectionStrings["SendFaxApp.Properties.Settings.FaxConfigDBConnectionString"].ConnectionString;

        NLog.Logger logger = LogManager.GetCurrentClassLogger();

        private String fileFaxTest = "";

        private String inforMessage = "Có lỗi xảy ra -liên hệ quản trị viên";

        public Form1()
        {
            InitializeComponent();
            initDataConifg();
            clearOpenFileSendFaxTest();
            lblInfoTest.Text = Environment.MachineName;

            JobManager.Initialize();

            JobManager.AddJob(
                () => { DownloadFileAysn(); },
                s => s.ToRunEvery(GetDownLoadTimeInSecond()).Seconds()
            );

            JobManager.AddJob(
                () => { LoginAuthenAysn(); },
                s => s.ToRunEvery(GeLogInTimeInMinute()).Minutes()
            );

            JobManager.AddJob(
                () => { SendFaxAysn(); },
                s => s.ToRunEvery(GetSendTaxTimeInMinute()).Minutes()
            );

            JobManager.AddJob(
               () => { AutoConnectWebSocket(); },
               s => s.ToRunEvery(60).Minutes()
           );
        }


        private int GetDownLoadTimeInSecond()
        {
            try
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("DownLoadTimeInSeconds")??"40");
            }catch(Exception ex)
            {
                return 40;
            }
           
        }

        private int GeLogInTimeInMinute()
        {
            try
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("LoginTimeinMinute") ?? "10");
            }
            catch (Exception ex)
            {
                return 10;
            }

        }

        private int GetSendTaxTimeInMinute()
        {
            try
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("SendFaxTimeinMinute") ?? "10");
            }
            catch (Exception ex)
            {
                return 10;
            }

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
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    var faxConfig = context.FaxConfigs.FirstOrDefault();
                    return faxConfig;
                }
            }catch(Exception ex)
            {
                logger.Error("GetDefaultFaxConfig:" + ex.Message);
                return null;
            }
            
        }

        private AuthenMdo? GetDefaultMDOAuthen()
        {
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    var authen = context.AuthenMdos.FirstOrDefault();
                    return authen;
                }
            }catch(Exception ex)
            {
                logger.Error("GetDefaultMDOAuthen:" + ex.Message);
                return null;
            }
           
        }

        private void btnTestFAX_Click(object sender, EventArgs e)
        {
            bool isValidate = validateFaxClick();
            if (!isValidate)
            {
                return;
            }
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    var config = context.FaxConfigs.FirstOrDefault();
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
                }
                clearOpenFileSendFaxTest();

                MessageBox.Show("Update Fax Config Successfully");
            }catch(Exception ex)
            {
                logger.Error("btnTestFAX_Click:"+ex.Message);
                MessageBox.Show(inforMessage);
            }
            
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
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    var authen = context.AuthenMdos.FirstOrDefault();
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
                        if (isInsert)
                        {
                            context.AuthenMdos.InsertOnSubmit(authen);
                        }

                        context.SubmitChanges();

                        MessageBox.Show("Update Authen Settings Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Connect to authen api fail");
                    }

                }

                clearOpenFileSendFaxTest();

            }
            catch (Exception ex)
            {
                logger.Error("btnLogin_Click:"+ex.Message);
                MessageBox.Show(inforMessage);
            }
            

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

        private LoginRespone? GetMDOAuthenToken(string baseUrl, string domain, string clientID, string Secret)
        {
            try
            {
                AuthenService service = new AuthenService(baseUrl, domain);
                return service.login(new Model.MDO.LoginRequest() { ClientId = clientID, ClientSecret = Secret }).Result;
            }catch(Exception ex)
            {
                logger.Error("GetMDOAuthenToken:"+ex.Message);
                return null;
            }
        
        }

        private void btnSendFaxTest_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(fileFaxTest))
                {
                    MessageBox.Show("Choose file to send fax");
                    return;
                }
                var authen = GetDefaultFaxConfig();
                if ((authen==null))
                {
                    MessageBox.Show("Not config fax in tab config");
                    return;
                }
                FaxSenderHelper faxSender = new FaxSenderHelper(authen.HostName);

                FaxSenderInfo faxSenderInfo = new FaxSenderInfo();
                faxSenderInfo.Name = authen.SenderName;
                faxSenderInfo.CompanyName = authen.CompanyName;
                faxSenderInfo.Subject = txtDocumentSubject.Text;

                FaxDocInfo faxDocInfo = new FaxDocInfo();
                faxDocInfo.DocumentName = txtDocumentName.Text;

                faxDocInfo.Bodies.Add(fileFaxTest);


                FaxRecipientsInfo faxRecipientsInfo = new FaxRecipientsInfo();
                faxRecipientsInfo.listFaxRecipientsItem = new List<FaxRecipientsItem>();
                faxRecipientsInfo.listFaxRecipientsItem.Add(new FaxRecipientsItem() { Number = txtFaxNumber.Text, Name = txtReiverName.Text });

                clearOpenFileSendFaxTest();
                faxSender.SendFaxMultiFilesAndMultiUers(faxSenderInfo, faxDocInfo, faxRecipientsInfo);
            }
            catch(Exception ex)
            {
                logger.Error("btnSendFaxTest_Click:"+ex.Message);
                MessageBox.Show(inforMessage);
            }

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
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    var authen = context.AuthenMdos.FirstOrDefault();
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
                }

                clearOpenFileSendFaxTest();

                MessageBox.Show("Update Web Socket Successfully");
            }
            catch(Exception ex)
            {
                logger.Error("bntConfigWebSocket_Click:"+ex.Message);
                MessageBox.Show(inforMessage);
            }
          
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
            try
            {
                var authen = GetDefaultMDOAuthen();
                if (IsAuthenInValid(authen))
                {
                    MessageBox.Show("Not login or config authen");
                    return;
                }
                WebSocketService serivce = new WebSocketService(authen.ApiUrl, authen.Domain);
                var response = serivce.registerChanel(authen.WebSocketChanel, authen.Token);

                if (response!=null&& response.Result!=null&&response.Result.Status == 200)
                {
                    MessageBox.Show("Register Channel Sucessfully");
                }
                else
                {
                    MessageBox.Show("Error:" + response.Result.Message);
                }
            }
            catch(Exception ex)
            {
                logger.Error("btnRegisterChanel_Click:"+ex.Message);
                MessageBox.Show(inforMessage);
            }
            
        }

        private bool IsAuthenInValid(AuthenMdo? authen)
        {
            return (authen == null
                || String.IsNullOrEmpty(authen.WebSocketUrl)
                || String.IsNullOrEmpty(authen.Domain)
                || String.IsNullOrEmpty(authen.Token));
        }

        private void AutoConnectWebSocket()
        {
            var authen = GetDefaultMDOAuthen();
            if (!IsAuthenInValid(authen))
            {
                onConnectWebSocket(authen.ApiUrl,authen.WebSocketUrl, authen.Token, authen.Token, authen.WebSocketChanel);
                return;
            }
           
        }

        private void btnConnectSocket_Click(object sender, EventArgs e)
        {
            try
            {
                var authen = GetDefaultMDOAuthen();
                if (IsAuthenInValid(authen))
                {
                    MessageBox.Show("Not login or config authen");
                    return;
                }
               var isSuccess= onConnectWebSocket(authen.ApiUrl, authen.WebSocketUrl, authen.Domain, authen.Token, authen.WebSocketChanel);
                if (isSuccess)
                {
                    MessageBox.Show("Web socket connect successfully");
                }
                else
                {
                    MessageBox.Show("Web socket connect fail");
                }
               
            }
            catch(Exception ex)
            {
                logger.Error("btnConnectSocket_Click:"+ex.Message);
                MessageBox.Show(inforMessage);
            }
           

        }

        private bool onConnectWebSocket(string apiUrl,string host,string domain, String token, String chanel)
        {
            Socket socket;
            int i = 0;
            bool isConnectSuccess = true;

            try
            {
                var options = new IO.Options
                {
                    Query = new Dictionary<string, string>
                    {
                        { "token", token },
                    },
                    Reconnection = true,
                    AutoConnect = true,
                    ReconnectionAttempts = 10,
                   
                    ReconnectionDelay = 600,

                };

                socket = IO.Socket(host, options);
                socket.On(Socket.EVENT_CONNECT, () =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lblSockeStatus.Text = " WebSocket Connect: ";
                    }));

                });

                socket.On(Socket.EVENT_DISCONNECT, (data) =>
                {
                    if (data.ToString() == "io server disconnect")
                    {

                        onConnectWebSocket(apiUrl,host, domain, token, chanel);
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            lblSockeStatus.Text = data.ToString();
                        }));
                        //var action = new Action(() => {
                        //    onConnectWebSocket(apiUrl,host,domain, token, chanel);
                        //});
                        //SetTimeout(action, 1000);
                    }

                  

                });

                socket.On(chanel, (data) =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lblSockeStatus.Text = " Number of data: " + (i++);
                    }));
                    parseFaxRequestData(apiUrl,domain,token,data.ToString());
                });

               var sConnect= socket.Connect();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SetTimeout(Action action, int timeout)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = timeout;
            timer.Tick += (s, e) =>
            {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        private void parseFaxRequestData(string apiUrl, string domain, string token, string data)
        {
            logger.Info("Socket data:" + data);

            var jsonFax = tryToParseFaxDataObj(data);

            if (jsonFax == null || String.IsNullOrEmpty(jsonFax.Id))
            {
                return;
            }
            var isExistRequest = isExistRequestRecord(jsonFax.Id);

            if (isExistRequest)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    lblSockeStatus.Text = " Gửi trùng data request Id: " + jsonFax.Id;
                }));
                return;
            }
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    using (var transaction = new TransactionScope())
                    {

                        var faxRequest = new FaxRequest();
                        faxRequest.RequestId = jsonFax.Id;
                        faxRequest.Subject = jsonFax.Subject;
                        faxRequest.Domain = jsonFax.Domain;
                        faxRequest.Address = string.Join(",", jsonFax.Address);
                        faxRequest.Status = (int)FaxStatusDef.Pending;

                        context.FaxRequests.InsertOnSubmit(faxRequest);
                        context.SubmitChanges();
                        if (jsonFax.AttachFiles != null && jsonFax.AttachFiles.Any())
                        {
                            List<FaxRequestAttachFile> listFile = new List<FaxRequestAttachFile>();
                            foreach (var item in jsonFax.AttachFiles)
                            {
                                FaxRequestAttachFile fileAttach = new FaxRequestAttachFile();
                                fileAttach.Domain = item.Domain;
                                fileAttach.FileName = item.FileName;
                                fileAttach.FilePath = item.FilePath;
                                fileAttach.FaxRequestId = faxRequest.Id;
                                fileAttach.Storage = item.Storage;
                                fileAttach.Status = (int)FaxStatusDef.Pending;
                                listFile.Add(fileAttach);
                            }
                            context.FaxRequestAttachFiles.InsertAllOnSubmit(listFile);
                            context.SubmitChanges();
                            transaction.Complete();
                        }
                    }
                }

                SocketDataStatusService socketDataStatusService = new SocketDataStatusService(apiUrl, domain);
                socketDataStatusService.SendStatusSuccess(jsonFax.Id, token);
            }catch(Exception ex)
            {
                logger.Error("parseFaxRequestData:"+ex.Message);
            }
        }

        private FaxData tryToParseFaxDataObj(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<FaxData>(data);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private bool isExistRequestRecord(string requestID)
        {
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    return context.FaxRequests.Any(c => c.RequestId.Equals(requestID));
                }
            }
            catch (Exception ex)
            {
                return true;
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

        private void DownloadFileAysn()
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 1000;
            try
            {
                var authen = GetDefaultMDOAuthen();
                if (IsAuthenInValid(authen))
                {
                    MessageBox.Show("Not login or config authen");
                    return;
                }

                var config = GetDefaultFaxConfig();
                if (config != null && !String.IsNullOrEmpty(config.FileSaveUrl))
                {
                    using (var context = new DbFaxContext(connectionStriong))
                    {
                        var faxRequest = context.FaxRequests.Where(c => c.Status == (int)FaxStatusDef.Pending).FirstOrDefault();
                        if (faxRequest != null)
                        {

                            var fileDownloads = context.FaxRequestAttachFiles.Where(c => c.FaxRequestId == faxRequest.Id && c.Status == (int)FaxStatusDef.Pending).ToList();
                            DownloadServicecs downloadServicecs = new DownloadServicecs(authen.ApiUrl, authen.Domain);
                            downloadServicecs.Token = authen.Token;
                            foreach (var item in fileDownloads)
                            {
                                var file = downloadServicecs.download(item.Storage, item.FilePath, item.FileName);
                                if (file == null)
                                {
                                    logger.Info(String.Format("Could not download file storage:{0}_file path:{1}_fileName :{2}", item.Storage, item.FilePath, item.FileName));
                                    item.Status = (int)FaxStatusDef.DownloadError;

                                }
                                else
                                {
                                    FileService fileService = new FileService();
                                    file.Position = 0;
                                    string realPath = String.Format("{0}_{1}", faxRequest.Id, item.FileName);
                                    fileService.saveFile(config.FileSaveUrl, realPath, file);
                                    file.Flush();
                                    item.Status = (int)FaxStatusDef.Downloading;
                                    item.FaxRealPath = String.Format("{0}\\{1}", config.FileSaveUrl, realPath);
                                }


                            }
                            faxRequest.Status = (int)FaxStatusDef.Downloading;
                            context.SubmitChanges();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                logger.Error("DownloadFileAysn:" + ex.Message);
            }
          
        }

        private void LoginAuthenAysn()
        {
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    var authen = context.AuthenMdos.FirstOrDefault();
                    if (authen != null)
                    {
                        var authenApiResponse = GetMDOAuthenToken(authen.ApiUrl, authen.Domain, authen.ClientId, authen.ClientSecret);
                        if (authenApiResponse != null)
                        {
                            authen.Token = authenApiResponse.Data.Token;
                            authen.TokenTimeout = authenApiResponse.Data.TokenTimeout.ToString();
                            authen.TokentExpiredAt = authenApiResponse.Data.TokenExpiredAt.ToString();
                            context.SubmitChanges();
                        }
                    }

                }
            }catch(Exception ex)
            {
                logger.Error("LoginAuthenAysn:" + ex.Message);
            }
           
        }

        private void SendFaxAysn()
        {
            try
            {
                using (var context = new DbFaxContext(connectionStriong))
                {
                    var authen = GetDefaultMDOAuthen();
                    if (authen == null)
                    {
                        logger.Error("SendFaxAysn Get Authen is null");
                        return;
                    }

                    var faxConfig = GetDefaultFaxConfig();
                    if (faxConfig == null)
                    {
                        logger.Error("SendFaxAysn GetDefaultFaxConfig is null");
                        return;
                    }

                    var faxRequest = context.FaxRequests.Where(c => c.Status == (int)FaxStatusDef.Downloading).FirstOrDefault();
                    var isExistErrorFile = context.FaxRequestAttachFiles.Any(c => c.Status == (int)FaxStatusDef.DownloadError);
                    if (authen != null && faxConfig != null && !isExistErrorFile)
                    {
                        if (faxRequest != null)
                        {
                            var fileDownloads = context.FaxRequestAttachFiles.Where(c => c.FaxRequestId == faxRequest.Id).ToList();

                            FaxSenderHelper faxSender = new FaxSenderHelper(faxConfig.HostName);

                            FaxSenderInfo faxSenderInfo = new FaxSenderInfo();
                            faxSenderInfo.Name = faxConfig.SenderName;
                            faxSenderInfo.CompanyName = faxConfig.CompanyName;
                            faxSenderInfo.Subject = faxRequest.Subject;

                            FaxDocInfo faxDocInfo = new FaxDocInfo();
                            faxDocInfo.DocumentName = faxRequest.Subject;
                            foreach (var item in fileDownloads)
                            {
                                faxDocInfo.Bodies.Add(item.FaxRealPath);
                                item.Status = (int)FaxStatusDef.Faxing;

                            }
                            faxRequest.Status = (int)FaxStatusDef.Faxing;
                            context.SubmitChanges();

                            FaxRecipientsInfo faxRecipientsInfo = new FaxRecipientsInfo();
                            faxRecipientsInfo.listFaxRecipientsItem = new List<FaxRecipientsItem>();
                            var listRecipients = faxRequest.Address.Split(',');
                            foreach (var item in listRecipients)
                            {
                                faxRecipientsInfo.listFaxRecipientsItem.Add(new FaxRecipientsItem() { Number = item });
                            }
                            clearOpenFileSendFaxTest();
                            var sendFaxResult = faxSender.SendFaxMultiFilesAndMultiUers(faxSenderInfo, faxDocInfo, faxRecipientsInfo);

                            logger.Info(String.Format("Send fax_ RequestId:{0}_address:{1}_result:{2}", faxRequest.RequestId, faxRequest.Address, sendFaxResult));

                            FaxSendStatusService faxSendStatusService = new FaxSendStatusService(authen.ApiUrl, authen.Domain);
                            faxSendStatusService.SendStatus(faxRequest.RequestId, authen.Token, listRecipients.ToList());


                        }
                    }
                   
                }

            }
            catch(Exception ex)
            {
                logger.Error("SendFaxAysn:"+ex.Message);

            }
          

        }
    }
}